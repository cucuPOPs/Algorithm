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
            int[] a = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            string s1 = ((a[2] % a[0])).ToString();
            string s2 = ((a[2] / a[0]) + 1).ToString("D2");
            if (a[2] % a[0] == 0)
            {
                s1 = a[0].ToString();
                s2 = (a[2] / a[0]).ToString("D2");
            }

            sw.WriteLine(s1 + s2);
        }
        sw.Flush();
    }
}