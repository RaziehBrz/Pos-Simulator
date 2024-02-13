public class MyFile
{
    private static string _transactionFilePath = @"Enter the path of your transaction file";
    public static void WriteTransactionInfo(string cardNumber, string amount, bool status)
    {
        using (var sw = new StreamWriter(_transactionFilePath, true))
        {
            sw.WriteLine(cardNumber);
            sw.WriteLine(amount);
            sw.WriteLine(status);
            sw.WriteLine("---");
        }
    }
    public static string[] ReadData(string path)
    {
        var fileContent = File.ReadAllText(path);
        return fileContent.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
    }
}