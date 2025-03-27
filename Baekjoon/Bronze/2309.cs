class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int[] n = new int[9];
        int sum = 0;

        for (int i = 0; i < 9; i++)
        {
            n[i] = int.Parse(sr.ReadLine());
            sum += n[i];
        }

        Array.Sort(n);


        bool find = false;
        for (int i = 0; i < 8; i++)
        {
            for (int j = i + 1; j < 9; j++)
            {
                if (sum - n[i] - n[j] == 100)
                {
                    find = true;
                    for (int k = 0; k < 9; k++)
                    {
                        if (k != i && k != j)
                        {
                            sw.WriteLine(n[k]);
                        }
                    }
                    break;
                }
                if (find) break;
            }
            if (find) break;
        }
        sw.Flush();
    }
}