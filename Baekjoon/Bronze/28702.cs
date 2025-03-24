class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int nextNum = 0;

        //최소 1개는 숫자.
        int t = 3;
        while (t-- > 0)
        {
            int i;
            bool b = int.TryParse(sr.ReadLine(), out i);
            if (!b) continue;
            nextNum = i + t + 1;
        }

        bool b3 = nextNum % 3 == 0;
        bool b5 = nextNum % 5 == 0;
        if (b3 & b5)
        {
            sw.WriteLine("FizzBuzz");
        }
        else if (b3 & !b5)
        {
            sw.WriteLine("Fizz");
        }
        else if (!b3 & b5)
        {
            sw.WriteLine("Buzz");
        }
        else
        {
            sw.WriteLine(nextNum);
        }
        sw.Flush();
    }
}