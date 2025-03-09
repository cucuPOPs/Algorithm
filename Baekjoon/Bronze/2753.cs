class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int a = int.Parse(sr.ReadLine());
        bool condition1 = (a % 4 == 0) && (a % 100 != 0);
        bool condition2 = a % 400 == 0;
        if (condition1 | condition2)
            sw.WriteLine("1");
        else
            sw.WriteLine("0");
        sw.Flush();
    }
}