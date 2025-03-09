class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        string[] s = sr.ReadLine().Split();
        int h = int.Parse(s[0]);
        int m = int.Parse(s[1]);

        //45분빼기.
        m -= 45;

        if (m < 0)
        {
            m += 60;
            h -= 1;
            if (h < 0)
            {
                h += 24;
            }
        }
        sw.WriteLine("{0} {1}", h, m);
        sw.Flush();
    }
}