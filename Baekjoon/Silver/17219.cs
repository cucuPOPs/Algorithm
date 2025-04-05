class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        string[] nm = sr.ReadLine().Split();
        int n = int.Parse(nm[0]);
        int m = int.Parse(nm[1]);
        
        Dictionary<string, string> dic = new Dictionary<string, string>();
        for (int i = 0; i < n; i++)
        {
            string[] s = sr.ReadLine().Split();
            dic[s[0]] = s[1];
        }

        for (int i = 0; i < m; i++)
        {
            sw.WriteLine(dic[sr.ReadLine()]);
        }

        sw.Flush();
    }
}