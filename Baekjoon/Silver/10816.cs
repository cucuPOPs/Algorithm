class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        sr.ReadLine();
        int[] n = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        sr.ReadLine();
        int[] m = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for (int i = 0; i < n.Length; i++)
        {
            if (dic.ContainsKey(n[i]))
                dic[n[i]]++;
            else
                dic.Add(n[i], 1);
        }
        for (int i = 0; i < m.Length; i++)
        {
            if (dic.ContainsKey(m[i]))
                sw.Write($"{dic[m[i]]} ");
            else
                sw.Write("0 ");
        }
        sw.Flush();
    }
}