class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        string[] s = sr.ReadLine().Split();
        int n = int.Parse(s[0]);
        int m = int.Parse(s[1]);

        Dictionary<string, int> dic = new Dictionary<string, int>();
        for (int i = 0; i < m; i++)
        {
            string ss = sr.ReadLine();
            dic[ss] = i;
        }

        var pair = dic.ToArray();
        Array.Sort(pair, (a, b) => a.Value.CompareTo(b.Value));

        for (int i = 0; i < n && i < pair.Length; i++)
        {
            sw.WriteLine(pair[i].Key);
        }

        sw.Flush();
    }
}