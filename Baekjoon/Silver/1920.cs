class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        //int n = int.Parse(sr.ReadLine());
        sr.ReadLine();
        int[] arrA = sr.ReadLine().Split().Select(int.Parse).ToArray();
        //int m = int.Parse(sr.ReadLine());
        sr.ReadLine();
        int[] arrB = sr.ReadLine().Split().Select(int.Parse).ToArray();
        HashSet<int> set = new HashSet<int>(arrA);
        foreach (int t in arrB)
        {
            sw.WriteLine(set.Contains(t) ? 1 : 0);
        }

        sw.Flush();
    }
}