public class Card : ICard
{
    private const string _cardInfoPath = @"Enter the path of the card information file";
    private const int _cardNumber_Length = 16;
    private const int _cvv2_Length = 4;
    private const int _expireDate_Length = 5;
    private const char _expireDate_Separator = '/';

    public string CardNumber { get; set; }
    public string Cvv2 { get; set; }
    public string ExpireDate { get; set; }

    public void GetCardInfo()
    {
        Console.WriteLine("Enter the card number : ");
        CardNumber = Console.ReadLine();
        Console.WriteLine("Enter Cvv2 : ");
        Cvv2 = Console.ReadLine();
        Console.WriteLine("Enter Expiration Date : ");
        ExpireDate = Console.ReadLine();
    }
    public void AddCard()
    {
        GetCardInfo();
        var validInfo = CardInfoValidation(CardNumber, Cvv2, ExpireDate);
        if (validInfo)
        {
            MyFile.WriteInfo(_cardInfoPath, CardNumber, Cvv2, ExpireDate);
            Console.WriteLine("Card saved successfully.");
        }
    }
    public void EditCard()
    {
        var lines = MyFile.ReadInfo(_cardInfoPath);
        showCardNumbersList();

        Console.WriteLine("\nEnter a Card number to upadte:");
        var inputCardNumber = Console.ReadLine();

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines.Contains(inputCardNumber))
            {
                Console.Clear();
                Console.WriteLine($"Card number : {lines[i]}");
                Console.WriteLine($"Cvv2 : {lines[i + 1]}");
                Console.WriteLine($"Expiration date : {lines[i + 2]}");
                Console.WriteLine("\nEnter an item to edit:");
                Console.WriteLine("\t1)Card number");
                Console.WriteLine("\t2)Cvv2");
                Console.WriteLine("\t3)Expire date");

                var selectedNum = Console.ReadLine();

                switch (selectedNum)
                {
                    case "1":
                        Console.WriteLine("Enter the correct card number :");
                        var number = Console.ReadLine();
                        lines[i] = number;
                        break;
                    case "2":
                        Console.WriteLine("Enter the correct cvv2 :");
                        var newCvv2 = Console.ReadLine();
                        lines[i + 1] = newCvv2;
                        break;
                    case "3":
                        Console.WriteLine("Enter the correnct expiration date :");
                        var newDate = Console.ReadLine();
                        lines[i + 2] = newDate;
                        break;
                    default:
                        throw new Exception("You entered wrong item.");
                }
                var validInfo = CardInfoValidation(lines[i], lines[i + 1], lines[i + 2]);
                if (validInfo)
                {
                    File.WriteAllLines(_cardInfoPath, lines);
                    Console.WriteLine("Changes applied successfully.");
                }
                else Console.WriteLine("Please try again.");
                break;
            }
            else Console.WriteLine("Input card number does not exist.");
        }
    }
    public void RemoveCard()
    {
        var lines = MyFile.ReadInfo(_cardInfoPath);

        showCardNumbersList();
        var myList = lines.ToList();

        Console.WriteLine("\nEnter a Card number to remove:");
        var inputNumber = Console.ReadLine();

        for (int i = 0; i < myList.Count; i++)
        {
            if (lines[i] == inputNumber)
            {
                myList.Remove(lines[i]);
                myList.Remove(lines[i + 1]);
                myList.Remove(lines[i + 2]);
                myList.Remove(lines[i + 3]);
            }
            else if (lines[i] != inputNumber && i == lines.Length - 1)
            {
                throw new Exception("Input card number does not exist!");
            }
            else if (inputNumber.Length == 0)
            {
                throw new Exception("You did not enter a card number!");
            }
        }
        File.WriteAllLines(_cardInfoPath, myList);
    }
    public void ShowCardsList()
    {
        var lines = MyFile.ReadInfo(_cardInfoPath);
        int i = 0;
        foreach (var line in lines)
        {
            if (line.Length == _cardNumber_Length)
            {
                Console.WriteLine($"Card {i + 1}");
                i++;
            }
            if (line.Length == _cardNumber_Length) Console.Write("Card number : ");
            else if (line.Length == _cvv2_Length) Console.Write("Cvv2 : ");
            else if (line.Length == _expireDate_Length) Console.Write("Expiration Date : ");
            Console.WriteLine(line);
        }
    }
    public void showCardNumbersList()
    {
        var lines = MyFile.ReadInfo(_cardInfoPath);
        int j = 0;
        var cardNumbersList = lines.Where(line => line.Length == _cardNumber_Length).ToList();
        foreach (var item in cardNumbersList)
        {
            Console.WriteLine($"Card {j + 1}");
            Console.WriteLine(item);
            Console.WriteLine("---");
            j++;
        }
    }
    public bool CardInfoValidation(string cardNumber, string cvv2, string exDate)
    {
        var checkExDate = true;
        if (exDate.Length != _expireDate_Length
        || exDate[2] != _expireDate_Separator
        || !Char.IsDigit(exDate[0])
        || !Char.IsDigit(exDate[1])
        || !Char.IsDigit(exDate[3])
        || !Char.IsDigit(exDate[4]))
        {
            checkExDate = false;
        }
        if (cardNumber.Length != _cardNumber_Length || !cardNumber.All(x => Char.IsDigit(x))) Console.WriteLine("Card number must be 16 digits!");
        else if (cvv2.Length != _cvv2_Length || !cvv2.All(x => Char.IsDigit(x))) Console.WriteLine("Cvv2 must be 4 digits!");
        else if (!checkExDate) Console.WriteLine("The expiration date must be in this format : year/month");
        else
        {
            return true;
        }
        return false;
    }
}