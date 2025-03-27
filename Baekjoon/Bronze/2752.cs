class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int[] a = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        Array.Sort(a);
        for (int i = 0; i < a.Length; i++)
        {
            sw.Write(a[i] + " ");
        }
        sw.Flush();
    }
}