class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        Queue<string> q = new Queue<string>();
        string last = string.Empty;
        while (n-- > 0)
        {
            string[] s = sr.ReadLine().Split();
            string ss = s[0];

            switch (ss)
            {
                case "push":
                    last = s[1];
                    q.Enqueue(last);
                    break;
                case "pop":
                    sw.WriteLine(q.Count > 0 ? q.Dequeue() : "-1");
                    break;
                case "size":
                    sw.WriteLine(q.Count);
                    break;
                case "empty":
                    sw.WriteLine(q.Count == 0 ? "1" : "0");
                    break;
                case "front":
                    sw.WriteLine(q.Count > 0 ? q.Peek() : "-1");
                    break;
                case "back":
                    sw.WriteLine(q.Count > 0 ? last : "-1");
                    break;
            }
        }

        sw.Flush();
    }
}