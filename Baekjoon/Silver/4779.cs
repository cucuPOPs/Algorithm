class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));


    static void Main()
    {
        while (true)
        {
            string s = sr.ReadLine();
            if (s == null) break;

            int n = int.Parse(s);
            int length = Pow(3, n);
            Print(0, length);
            sw.WriteLine();
        }

        sw.Flush();
    }

    static void Print(int start, int end)
    {
        int length = end - start;
        if (length == 1)
        {
            sw.Write("-");
            return;
        }

        int temp = length / 3;

        //왼쪽
        Print(start, start + temp);

        //중간
        sw.Write(new string(' ', temp));

        //오른쪽
        Print(start + 2 * temp, end);
    }

    static int Pow(int a, int b)
    {
        int result = 1;
        while (b-- > 0)
        {
            result *= a;
        }

        return result;
    }
}