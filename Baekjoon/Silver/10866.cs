class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));


    static void Main()
    {
        int MAX = 10_000;
        int[] arr = new int[2 * MAX + 1];
        int head = MAX;
        int tail = MAX;
        
        
        
        int n = int.Parse(sr.ReadLine());
        while (n-- > 0)
        {
            string[] s = sr.ReadLine().Split();
            switch (s[0])
            {
                case "push_front":
                    arr[--head] = int.Parse(s[1]);
                    break;
                case "push_back":
                    arr[tail++] = int.Parse(s[1]);
                    break;
                case "pop_front":
                    sw.WriteLine(head == tail ? -1 : arr[head++]);
                    break;
                case "pop_back":
                    sw.WriteLine(head == tail ? -1 : arr[--tail]);
                    break;
                case "size":
                    sw.WriteLine(tail - head);
                    break;
                case "empty":
                    sw.WriteLine(head == tail ? 1 : 0);
                    break;
                case "front":
                    sw.WriteLine(head == tail ? -1 : arr[head]);
                    break;
                case "back":
                    sw.WriteLine(head == tail ? -1 : arr[tail - 1]);
                    break;
            }
        }


        sw.Flush();
    }
}