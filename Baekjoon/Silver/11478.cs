class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        string s = sr.ReadLine();
        HashSet<string> set = new HashSet<string>();


        int count = 0;
        for (int len = 1; len <= s.Length; len++)
        {
            set.Clear();
            for (int i = 0; i <= s.Length - len; i++)
            {
                set.Add(s.Substring(i, len));
            }

            count += set.Count;
        }

        sw.WriteLine(count);
        sw.Flush();
    }
}