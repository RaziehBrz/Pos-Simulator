class Pos : Ipos
{
    public string CardNumber { get; set; }
    public string PurchaseAmount { get; set; }
    private readonly int _cardNumberLength = 16;
    public string _cvv2;
    public string _expirationDate;
    public string _password;
    public string _cardFilePath = @"Enter the path of your card information file";
    public string _passwordFilePath = @"Enter the path of your password file";
    public string _transactionFilePath = @"Enter the path of your transaction file";
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
    public void ValidateInfo()
    {
        var passwordData = MyFile.ReadData(_passwordFilePath);
        var cardInfo = MyFile.ReadData(_cardFilePath);
        var transaction = new Transaction();

        for (int i = 0; i < cardInfo.Length; i += 4)
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
        }
        if (!transaction.Status) Console.WriteLine("You entered wrong item!");

        var transactionStatus = transaction.Status ? "successful" : "unsuccessful";
        MyFile.WriteTransactionInfo(CardNumber, PurchaseAmount, transaction.Status);
        Console.WriteLine("Transaction was " + transactionStatus);
    }
    public void PrintTransactions()
    {
        var transactionData = MyFile.ReadData(_transactionFilePath);
        int i = 0;
        foreach (var line in transactionData)
        {
            if (line.Length == _cardNumberLength)
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
