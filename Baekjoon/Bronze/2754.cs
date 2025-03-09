class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        string s = sr.ReadLine();
        switch (s[0])
        {
            case 'A':
                if (s[1] == '+') sw.WriteLine("4.3");
                if (s[1] == '0') sw.WriteLine("4.0");
                if (s[1] == '-') sw.WriteLine("3.7");
                break;
            case 'B':
                if (s[1] == '+') sw.WriteLine("3.3");
                if (s[1] == '0') sw.WriteLine("3.0");
                if (s[1] == '-') sw.WriteLine("2.7");
                break;
            case 'C':
                if (s[1] == '+') sw.WriteLine("2.3");
                if (s[1] == '0') sw.WriteLine("2.0");
                if (s[1] == '-') sw.WriteLine("1.7");
                break;
            case 'D':
                if (s[1] == '+') sw.WriteLine("1.3");
                if (s[1] == '0') sw.WriteLine("1.0");
                if (s[1] == '-') sw.WriteLine("0.7");
                break;
            case 'F':
                sw.WriteLine("0.0");
                break;
        }
        sw.Flush();
    }
}