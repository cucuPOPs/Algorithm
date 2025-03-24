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
            int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            arr[i] = (input[0], input[1]);
        }
        Array.Sort(arr);

        foreach (var t in arr)
        {
            sw.WriteLine($"{t.x} {t.y}");
        }

        sw.Flush();
    }
}