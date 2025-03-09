class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int[] nx = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        foreach (string s in Console.ReadLine().Split())
        {
            int i = int.Parse(s);
            if (i < nx[1])
            {
                sw.Write(i);
                sw.Write(' ');
            }
        }
        sw.Flush();
    }
}