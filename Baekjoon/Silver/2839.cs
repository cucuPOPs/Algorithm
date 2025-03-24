class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());

        //3....3
        //4....X
        //5....5
        //6....3 3
        //7....X
        //8....5 3
        //9....3 3 3
        //10...5 5
        //11...5 3 3
        //12...3 3 3 3
        //13...5 5 3
        //14...5 3 3 3
        //15...5 5 5
        //16...5 5 3 3
        //17...5 3 3 3 3
        //18...5 5 5 3
        //규칙이 안보여서, 순차탐색으로 구현.
        bool able = false;
        int count = 0;

        while (n > 0)
        {
            if (n % 5 == 0)
            {
                able = true;
                count += n / 5;
                sw.WriteLine(count);
                break;
            }
            n -= 3;
            count++;
            if (n == 0)
            {
                able = true;
                sw.WriteLine(count);
                break;
            }
        }
        if(!able)
            sw.WriteLine(-1);


        sw.Flush();
    }
}