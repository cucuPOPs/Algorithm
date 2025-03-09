class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int a = int.Parse(sr.ReadLine());
        if (a == 0) sw.WriteLine("1");
        else
        {
            int res = 1;
            for (int i = 1; i <= a; i++)
            {
                res *= i;
            }
            sw.WriteLine(res);
        }
        sw.Flush();
    }
}