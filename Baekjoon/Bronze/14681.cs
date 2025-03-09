class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int a = int.Parse(sr.ReadLine());
        int b = int.Parse(sr.ReadLine());

        bool xPlus = a > 0 ? true : false;
        bool yPlus = b > 0 ? true : false;

        if (xPlus & yPlus) sw.WriteLine("1");
        if (!xPlus & yPlus) sw.WriteLine("2");
        if (xPlus & !yPlus) sw.WriteLine("4");
        if (!xPlus & !yPlus) sw.WriteLine("3");
        sw.Flush();
    }
}