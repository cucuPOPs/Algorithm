class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        (int x, int y)[] arr = new (int, int)[n];
        for (int i = 0; i < n; i++)
        {
            string[] s = sr.ReadLine().Split();
            arr[i] = (int.Parse(s[0]), int.Parse(s[1]));
        }

        Array.Sort(arr, (a, b) =>
        {
            if (a.y == b.y)
            {
                return a.x.CompareTo(b.x);
            }
            return a.y.CompareTo(b.y);
        });

        for (int i = 0; i < n; i++)
        {
            sw.WriteLine($"{arr[i].x} {arr[i].y}");
        }

        sw.Flush();
    }
}