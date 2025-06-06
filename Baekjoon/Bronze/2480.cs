class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        string[] s = sr.ReadLine().Split();
        int a = int.Parse(s[0]);
        int b = int.Parse(s[1]);
        int c = int.Parse(s[2]);

        if (a == b && b == c)
            sw.WriteLine(10000 + a * 1000);
        else if (a == b || b == c || c == a)
            sw.WriteLine(1000 + (a == b ? a : c) * 100);
        else
            sw.WriteLine(Math.Max(a, Math.Max(b, c)) * 100);

        sw.Flush();
    }
}