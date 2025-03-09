class Program
{
    private const int bufferSize = 131072;
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        sw.WriteLine("         ,r'\"7");
        sw.WriteLine("r`-_   ,'  ,/");
        sw.WriteLine(" \\. \". L_r'");
        sw.WriteLine("   `~\\/");
        sw.WriteLine("      |");
        sw.WriteLine("      |");
        sw.Flush();
    }
}