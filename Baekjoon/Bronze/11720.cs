class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        string s = sr.ReadLine();

        int sum = 0;
        for (int i = 0; i < s.Length; i++)
        {
            sum += s[i] - 48; //48 = '0', 49 = '1'
        }
        sw.WriteLine(sum);
        sw.Flush();
    }
}