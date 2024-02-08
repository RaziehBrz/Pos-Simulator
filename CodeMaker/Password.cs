class Password : IPassword
{
    private string _passInfoPath = @"C:\Users\FAHA\Desktop\Pos-Simulator\Code Maker\Password.txt";
    private string _cardInfoPath = @"C:\Users\FAHA\Desktop\Pos-Simulator\Code Maker\Card.txt";
    public void CreatePassword()
    {
        ICard myCard = new Card();
        var lines = MyFile.ReadInfo(_cardInfoPath);
        myCard.showCardNumbersList();

        Console.WriteLine("Enter a card number to generate a dynamic password:");
        var inputCardNumber = Console.ReadLine();
        var cardNumber = lines.Where(line => line == inputCardNumber).Select(line => line);

        if (cardNumber.Count() == 1)
        {
            Random random = new Random();
            var password = random.Next(100000, 1000000).ToString();
            MyFile.WriteInfo(_passInfoPath, inputCardNumber, password);
            Console.WriteLine("\nPassword : " + password);
        }
        else throw new Exception("Input card number does not exist!");
    }
}