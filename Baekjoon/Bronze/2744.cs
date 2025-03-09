class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        string s = sr.ReadLine();
        foreach (char c in s)
        {
            sw.Write(c < 97 ? (char)(c + 32) : (char)(c - 32));
        }
        sw.Flush();
    }
}