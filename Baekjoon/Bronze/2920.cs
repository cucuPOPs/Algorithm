class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int[] a = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        bool asc = true;
        for (int i = 1; i < a.Length; i++)
        {
            bool test = a[i - 1] < a[i];
            if (!test)
            {
                asc = false;
                break;
            }
        }

        bool desc = true;
        for (int i = 1; i < a.Length; i++)
        {
            bool test = a[i - 1] > a[i];
            if (!test)
            {
                desc = false;
                break;
            }
        }

        if (asc)
        {
            sw.WriteLine("ascending");
        }
        else if (desc)
        {
            sw.WriteLine("descending");
        }
        else
        {
            sw.WriteLine("mixed");
        }
        sw.Flush();
    }
}