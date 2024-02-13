internal class Program
{
    private static void Main(string[] args)
    {
        bool Exit = false;
        var pos = new Pos();

        do
        {
            Console.Clear();
            try
            {
                var inputOption = printMenu();
                switch (inputOption)
                {
                    case "1":
                        Console.Clear();
                        pos.GetData();
                        pos.ValidateInfo();
                        break;
                    case "2":
                        Console.Clear();
                        pos.PrintTransactions();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Good bye :)");
                        Exit = true;
                        Environment.Exit(0);
                        break;
                    default:
                        throw new Exception("That was an valid option");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            Console.Clear();
        } while (!Exit);
    }
    static string printMenu()
    {
        Console.WriteLine("Welcome ^_^");
        Console.WriteLine("1)Buy an item");
        Console.WriteLine("2)Show successfull transactions");
        Console.WriteLine("3)Exit");
        Console.WriteLine("Enter a number to execute: ");
        Console.Write("--> ");
        return Console.ReadLine();
    }
}
