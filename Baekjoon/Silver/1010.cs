using System.Numerics;

class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static long[,] comb = new long[31, 31];

    static void Main()
    {
        int tc = int.Parse(sr.ReadLine());

        while (tc-- > 0)
        {
            string[] s = sr.ReadLine().Split();
            int a = int.Parse(s[0]);
            int b = int.Parse(s[1]);

            sw.WriteLine(Combination(b, a));
        }

        sw.Flush();
    }

    static long Combination(int n, int r)
    {
        if (comb[n, r] != 0) return comb[n, r];
        if (r == 0) return 1;
        if (n == r) return 1;
        
        comb[n, r] = Combination(n - 1, r - 1) + Combination(n - 1, r);
        return comb[n, r];
    }

}