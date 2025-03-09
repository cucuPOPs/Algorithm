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
            int repeat = int.Parse(s[0]);
            string ss = s[1];

            foreach (char ch in ss)
            {
                for (int i = 0; i < repeat; i++)
                {
                    sw.Write(ch);
                }
            }
            sw.Write('\n');
        }
        sw.Flush();
    }
}