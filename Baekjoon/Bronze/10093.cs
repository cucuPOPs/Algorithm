class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        string[] s = sr.ReadLine().Split();
        long a = long.Parse(s[0]);
        long b = long.Parse(s[1]);

        if (a > b)
        {
            long temp = a;
            a = b;
            b = temp;
        }

        if (b - a > 1)
        {
            sw.WriteLine(b - a - 1);
            for (long i = a + 1; i < b; i++)
            {
                sw.Write(i + " ");
            }
        }
        else
        {
            sw.WriteLine(0);
        }
        sw.Flush();
    }
}