public class Card : ICard
{
    public string CardNumber { get; set; }
    public string Cvv2 { get; set; }
    public string ExpirationDate { get; set; }
    private string _cardInfoPath = @"Enter your card.txt file path.";
    public void GetCardInfo()
    {
        Console.WriteLine("Enter the card number : ");
        CardNumber = Console.ReadLine();
        Console.WriteLine("Enter Cvv2 : ");
        Cvv2 = Console.ReadLine();
        Console.WriteLine("Enter Expiration Date : ");
        ExpirationDate = Console.ReadLine();
    }
    public void AddCard()
    {
        GetCardInfo();
        var validation = CardInfoValidation(CardNumber, Cvv2, ExpirationDate);
        if (validation)
        {
            MyFile.WriteInfo(_cardInfoPath, CardNumber, Cvv2, ExpirationDate);
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
            if (lines[i] == inputCardNumber)
            {
                Console.Clear();
                Console.WriteLine($"Card number : {lines[i]}");
                Console.WriteLine($"Cvv2 : {lines[i + 1]}");
                Console.WriteLine($"Expiration date : {lines[i + 2]}");
                Console.WriteLine("\nEnter an item to edit:");
                Console.WriteLine("\t1)Card number");
                Console.WriteLine("\t2)Cvv2");
                Console.WriteLine("\t3)Expiration date");

                var selectedItem = Console.ReadLine();

                switch (selectedItem)
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
                var validation = CardInfoValidation(lines[i], lines[i + 1], lines[i + 2]);
                if (validation)
                {
                    File.WriteAllLines(_cardInfoPath, lines);
                    Console.WriteLine("Changes applied successfully.");
                }
                else
                {
                    Console.WriteLine("Please try again.");
                }
                break;
            }
            else if (i == lines.Length - 1)
            {
                Console.WriteLine("Input card number does not exist.");

            }
        }
    }
    public void RemoveCard()
    {
        var lines = MyFile.ReadInfo(_cardInfoPath);

        showCardNumbersList();
        var myList = lines.ToList();

        Console.WriteLine("\nEnter a Card number to remove:");
        var inputNumber = Console.ReadLine();

        for (int i = 0; i < lines.Length; i++)
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
            if (line.Length == 16)
            {
                Console.WriteLine($"Card {i + 1}");
                i++;
            }
            if (line.Length == 16) Console.Write("Card number : ");
            else if (line.Length == 4) Console.Write("Cvv2 : ");
            else if (line.Length == 5) Console.Write("Expiration Date : ");
            Console.WriteLine(line);
        }
    }
    public void showCardNumbersList()
    {
        var lines = MyFile.ReadInfo(_cardInfoPath);
        int j = 0;
        var cardNumbersList = lines.Where(line => line.Length == 16).ToList();
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
        var cardNumberValidationList = cardNumber.Where(x => char.IsDigit(x));
        var cvv2ValidationList = cvv2.Where(x => char.IsDigit(x));
        var checkExDate = true;

        if (exDate.Length != 5
        || exDate[2] != '/'
        || !(char.IsDigit(exDate[0]))
        || !(char.IsDigit(exDate[1]))
        || !(char.IsDigit(exDate[3]))
        || !(char.IsDigit(exDate[4])))
            checkExDate = false;
        if (cardNumber.Length != 16 || cardNumberValidationList.Count() != 16) Console.WriteLine("Card number must be 16 digits!");
        else if (cvv2.Length != 4 || cvv2ValidationList.Count() != 4) Console.WriteLine("Cvv2 must be 4 digits!");
        else if (!checkExDate)
            Console.WriteLine("The expiration date must be in this format : year/month");
        else
        {
            return true;
        }
        return false;
    }
}