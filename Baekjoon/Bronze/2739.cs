class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int a = int.Parse(sr.ReadLine());
        for (int i = 1; i <= 9; i++)
        {
            sw.WriteLine("{0} * {1} = {2}", a, i, a * i);
        }
        sw.Flush();
    }
}