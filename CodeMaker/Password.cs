class Password : IPassword
{
    private readonly string _passInfoPath = @"Enter the path of your password file";
    private readonly string _cardInfoPath = @"Enter the path of your card information file";
    public void CreatePassword()
    {
        ICard card = new Card();
        var lines = MyFile.ReadInfo(_cardInfoPath);
        card.ShowCardNumbersList();

        Console.WriteLine("Enter a card number to generate a dynamic password:");
        var inputCardNumber = Console.ReadLine();

        if (lines.Any(line => line == inputCardNumber))
        {
            var password = GeneratePassword();
            MyFile.WriteInfo(_passInfoPath, inputCardNumber, password);
            Console.WriteLine("\nPassword : " + password);
        }
        else
        {
            throw new Exception("Input card number does not exist!");
        }
    }
    public string GeneratePassword()
    {
        Random random = new Random();
        return random.Next(100000, 1000000).ToString();
    }
}