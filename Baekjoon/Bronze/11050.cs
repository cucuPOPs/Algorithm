class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        string[] s = sr.ReadLine().Split();
        int n = int.Parse(s[0]);
        int k = int.Parse(s[1]);


        //C(n,k) = n! / (k! * (n-k)!)
        int res = F(n) / (F(k) * F(n - k));
        sw.WriteLine(res);
        sw.Flush();
    }

    //팩토리얼
    static int F(int n)
    {
        int res = 1;
        for (int i = 1; i <= n; i++)
        {
            res *= i;
        }
        return res;
    }
}