class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        int tc = int.Parse(sr.ReadLine());
        while (tc-- > 0)
        {
            int n = int.Parse(sr.ReadLine());
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] s = sr.ReadLine().Split();
                if (!dic.ContainsKey(s[1]))
                {
                    dic[s[1]] = 1;
                }
                else
                {
                    dic[s[1]]++;
                }
            }

            int result = 1;
            foreach (var item in dic)
            {
                result *= item.Value + 1;
            }

            result--;

            sw.WriteLine(result);
        }


        sw.Flush();
    }
}