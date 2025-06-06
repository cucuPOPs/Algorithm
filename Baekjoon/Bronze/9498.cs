class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int score = int.Parse(sr.ReadLine());
        if (score >= 90)
        {
            sw.WriteLine("A");
        }
        else if (score >= 80)
        {
            sw.WriteLine("B");
        }
        else if (score >= 70)
        {
            sw.WriteLine("C");
        }
        else if (score >= 60)
        {
            sw.WriteLine("D");
        }
        else
        {
            sw.WriteLine("F");
        }
        sw.Flush();
    }
}