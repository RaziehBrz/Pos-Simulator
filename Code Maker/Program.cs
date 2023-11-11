internal class Program
{
    private static void Main(string[] args)
    {
        Random random = new Random();
        bool Exit = false;
        var myCard = new Card();
        var myPass = new Password();

        do
        {
            printMenu();
            try
            {
                Console.WriteLine("Enter a number to continue : ");
                var inputNumber = Console.ReadLine();
                Console.Clear();

                switch (inputNumber)
                {
                    case "1":
                        myCard.AddCard();
                        break;
                    case "2":
                        myCard.EditCard();
                        break;
                    case "3":
                        myCard.RemoveCard();
                        break;
                    case "4":
                        myCard.ShowCardsList();
                        break;
                    case "5":
                        myPass.CreatePassword();
                        break;
                    case "6":
                        Exit = true;
                        Console.WriteLine("Good bye :)");
                        Environment.Exit(0);
                        break;
                    default:
                        throw new Exception("You entered wrong item. Try again.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var myKey = Console.ReadKey();
        } while (!Exit);
    }
    static void printMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Welcome to the code maker application :");
        Console.ResetColor();
        Console.WriteLine("\t1)Add a new card");
        Console.WriteLine("\t2)Update a card");
        Console.WriteLine("\t3)Remove a card");
        Console.WriteLine("\t4)Show cards list");
        Console.WriteLine("\t5)Make a dynamic password");
        Console.WriteLine("\t6)Exit");
    }
}


