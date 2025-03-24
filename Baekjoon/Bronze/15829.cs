class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int l = int.Parse(sr.ReadLine());
        string s = sr.ReadLine();
        long hash = 0;
        long r = 31;
        long m = 1234567891;
        long power = 1;

        for (int i = 0; i < l; i++)
        {
            int a = s[i] - 'a' + 1;

            //오버플로방지 %m
            //hash %= m;
            //hash += (a * power) % m;
            hash = (hash + (a * power) % m) % m;

            //power *= r % m;
            power = (power * r) % m;
        }

        sw.WriteLine(hash);
        sw.Flush();
    }
}