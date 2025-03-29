class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        int[] a = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int x = int.Parse(sr.ReadLine());

        bool[] b = new bool[2_000_001];


        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (x - a[i] > 0 && b[x - a[i]])
            {
                count++;
            }

            b[a[i]] = true;
        }

        sw.WriteLine(count);
        sw.Flush();
    }
}