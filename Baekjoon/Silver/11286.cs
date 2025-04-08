class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        //C#에서는 기본동작이 최소힙.
        PriorityQueue<int, (int, int)> q = new PriorityQueue<int, (int, int)>();


        int n = int.Parse(sr.ReadLine());
        while (n-- > 0)
        {
            int x = int.Parse(sr.ReadLine());
            if (x == 0)
            {
                if (q.Count > 0)
                {
                    sw.WriteLine(q.Dequeue());
                }
                else
                {
                    sw.WriteLine(0);
                }
            }
            else
            {
                int absX = Abs(x);
                q.Enqueue(x, (absX, x));
            }
        }

        sw.Flush();
    }

    static int Abs(int x)
    {
        return x < 0 ? -x : x;
    }
}