class Program
{
    private const int bufferSize = 131072;
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        sw.WriteLine("|\\_/|");
        sw.WriteLine("|q p|   /}");
        sw.WriteLine("( 0 )\"\"\"\\");
        sw.WriteLine("|\"^\"`    |");
        sw.WriteLine("||_/=\\\\__|");
        sw.Flush();
    }
}