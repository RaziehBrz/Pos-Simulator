class Password : IPassword
{
    private string _passInfoPath = @"Enter your password.txt file path.";
    private string _cardInfoPath = @"Enter your card.txt file path.";
    public void CreatePassword()
    {
        ICard myCard = new Card();
        var lines = MyFile.ReadInfo(_cardInfoPath);
        myCard.showCardNumbersList();

        Console.WriteLine("Enter a card number to generate a dynamic password:");
        var inputCardNumber = Console.ReadLine();
        var cardNumber = lines.Where(line => line == inputCardNumber);

        if (cardNumber.Count() != 0)
        {
            Random random = new Random();
            var password = random.Next(100000, 1000000).ToString();
            MyFile.WriteInfo(_passInfoPath, inputCardNumber, password);
            Console.WriteLine("\nPassword : " + password);
        }
        else throw new Exception("Input card number does not exist!");
    }
}