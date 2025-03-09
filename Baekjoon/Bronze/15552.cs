class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int tc = int.Parse(sr.ReadLine());
        while (tc-- > 0)
        {
            string[] s = sr.ReadLine().Split();
            int a = int.Parse(s[0]);
            int b = int.Parse(s[1]);
            sw.WriteLine(a + b);
        }
        sw.Flush();
    }
}