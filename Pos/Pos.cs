class Pos : Ipos
{
    public string CardNumber { get; set; }
    public string PurchaseAmount { get; set; }
    public string _cvv2;
    public string _expirationDate;
    public string _password;
    public string _cardFilePath = @"C:\\Users\\FAHA\\Desktop\\Pos-Simulator\\Code Maker\\Card.txt";
    public string _passwordFilePath = @"C:\\Users\\FAHA\\Desktop\\Pos-Simulator\\Code Maker\\Password.txt";
    public string _transactionFilePath = @"C:\\Users\\FAHA\\Desktop\\Pos-Simulator\\Pos\\Transaction.txt";

    public void GetData()
    {
        Console.WriteLine("Enter the purchase amount :");
        PurchaseAmount = Console.ReadLine();

        Console.WriteLine("Enter the card number :");
        CardNumber = Console.ReadLine();

        Console.WriteLine("Enter Cvv2 :");
        _cvv2 = Console.ReadLine();

        Console.WriteLine("Enter the Expiration Date :");
        _expirationDate = Console.ReadLine();

        Console.WriteLine("Enter the dynamic password :");
        _password = Console.ReadLine();

    }
    public void Validation()
    {

        var passwordData = MyFile.ReadData(_passwordFilePath);
        var cardInfo = MyFile.ReadData(_cardFilePath);
        var transaction = new Transaction();

        for (int i = 0; i < cardInfo.Length; i++)
        {
            if (cardInfo[i] == CardNumber
             && cardInfo[i + 1] == _cvv2
             && cardInfo[i + 2] == _expirationDate
             && passwordData[0] == CardNumber
             && passwordData[1] == _password)
            {
                transaction.Status = true;
                break;
            }
            else if (i == cardInfo.Length - 1)
            {
                transaction.Status = false;
                Console.WriteLine("You entered wrong item!");
            }
        }
        var transactionStatus = transaction.Status == true ? "successfull" : "unsuccessfull";
        MyFile.WriteTransactionInfo(CardNumber, PurchaseAmount, transaction.Status);
        Console.WriteLine("Transaction was " + transactionStatus);
    }
    public void PrintTransactions()
    {
        var transactionData = MyFile.ReadData(_transactionFilePath);
        int i = 0;
        foreach (var line in transactionData)
        {
            if (line.Length == 16)
            {
                i++;
                Console.WriteLine("Transaction " + i);
                Console.WriteLine("Card number : " + line);
            }
            if (line.StartsWith('$')) Console.WriteLine("Purchase amount : " + line);
            if (line == true.ToString() || line == false.ToString())
            {
                var status = line == true.ToString() ? "successfull" : "unsuccessfull";
                Console.WriteLine("Status : " + status);
                Console.WriteLine("----");
            }
        }
    }
}
