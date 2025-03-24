class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        while (true)
        {
            string s = sr.ReadLine();
            if (s == "0") break;

            bool isEqual = true;
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[s.Length - 1 - i] != s[i])
                {
                    isEqual = false;
                    break;
                }
            }
            sw.WriteLine(isEqual ? "yes" : "no");
        }
        sw.Flush();
    }
}