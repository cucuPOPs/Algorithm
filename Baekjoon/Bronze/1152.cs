class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        string s = sr.ReadLine().Trim();
        if (s.Length == 0) sw.WriteLine(0);//특이케이스
        else
        {
            string[] ss = s.Split();
            sw.WriteLine(ss.Length);
        }
        sw.Flush();
    }
}