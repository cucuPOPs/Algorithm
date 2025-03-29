class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        string[] s = sr.ReadLine().Split();
        int n = int.Parse(s[0]);
        int max = int.Parse(s[1]);

        (int male, int female)[] arr = new (int, int)[6];


        for (int i = 0; i < n; i++)
        {
            string[] ss = sr.ReadLine().Split();
            int grade = int.Parse(ss[1]);

            if (ss[0] == "0")//isFemale?
            {
                arr[grade - 1].female++;
            }
            else
            {
                arr[grade - 1].male++;
            }
        }
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            count += RoundUp((double)arr[i].male / max);
            count += RoundUp((double)arr[i].female / max);
        }
        sw.Write(count);
        sw.Flush();
    }
    static int RoundUp(double d)
    {
        if (d % 1 != 0)
            return (int)d + 1;
        else
            return (int)d;
    }
}
