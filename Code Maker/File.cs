public class MyFile
{
    public static void WriteInfo(string path, string cardNumber, string cvv2, string expirationDate)
    {
        using (StreamWriter str = new StreamWriter(path, true))
        {
            str.WriteLine(cardNumber);
            str.WriteLine(cvv2);
            str.WriteLine(expirationDate);
            str.WriteLine("---");
        }
    }
    public static void WriteInfo(string path, string cardNumber, string password)
    {
        using (StreamWriter str = new StreamWriter(path))
        {
            str.WriteLine(cardNumber);
            str.WriteLine(password);
            str.WriteLine("---");
        }
    }
    public static string[] ReadInfo(string path)
    {
        var fileContent = File.ReadAllText(path);
        return fileContent.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
    }
}