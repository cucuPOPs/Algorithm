class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        string[] s = new string[n];
        for (int i = 0; i < n; i++)
        {
            s[i] = sr.ReadLine();
        }

        //정렬.
        Array.Sort(s, (a, b) =>
        {
            if (a.Length == b.Length)
            {
                return a.CompareTo(b);
            }
            return a.Length - b.Length;
        });


        for (int i = 0; i < n; i++)
        {
            //중복은 건너뜀.
            if (i != 0 && s[i - 1] == s[i]) continue;
            sw.WriteLine(s[i]);
        }
        sw.Flush();
    }
}