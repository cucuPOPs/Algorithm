class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        Queue<int> q = new Queue<int>();
        int back = 0;
        while (n-- > 0)
        {
            string[] s = sr.ReadLine().Split();
            switch (s[0][1])
            {
                case 'u'://push
                    q.Enqueue(back = int.Parse(s[1]));
                    break;
                case 'o'://pop
                    sw.WriteLine(q.Count > 0 ? q.Dequeue() : -1);
                    break;
                case 'r'://front
                    sw.WriteLine(q.Count > 0 ? q.Peek() : -1);
                    break;
                case 'a'://back
                    sw.WriteLine(q.Count > 0 ? back : -1);
                    break;
                case 'i'://size
                    sw.WriteLine(q.Count);
                    break;
                case 'm'://empty
                    sw.WriteLine(q.Count == 0 ? 1 : 0);
                    break;
            }
        }

        sw.Flush();
    }
}