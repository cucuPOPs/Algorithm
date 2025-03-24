class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        Queue<(int index, int priority)> q = new Queue<(int, int)>();
        int tc = int.Parse(sr.ReadLine());
        while (tc-- > 0)
        {
            q.Clear();
            string[] s = sr.ReadLine().Split();
            int targetIndex = int.Parse(s[1]);
            int[] priority = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int i = 0; i < priority.Length; i++)
            {
                q.Enqueue((i, priority[i]));
            }


            //내림차순.
            Array.Sort(priority, (a, b) => b.CompareTo(a));



            int count = 0;
            while (q.Count > 0)
            {
                var data = q.Dequeue();
                if (data.priority == priority[count])
                {
                    count++;
                    if (data.index == targetIndex) break;
                }
                else
                {
                    q.Enqueue(data);
                }
            }
            sw.WriteLine(count);
        }

        sw.Flush();
    }
}