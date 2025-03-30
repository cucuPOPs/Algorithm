class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        string s = sr.ReadLine();
        int n = int.Parse(sr.ReadLine());

        LinkedList<char> text = new LinkedList<char>(s);
        LinkedListNode<char> cur = text.AddLast(' ');

        while (n-- > 0)
        {
            string cmd = sr.ReadLine();
            switch (cmd[0])
            {
                case 'L':
                    if (cur.Previous != null) cur = cur.Previous;
                    break;
                case 'D':
                    if (cur.Next != null) cur = cur.Next;
                    break;
                case 'B':
                    if (cur.Previous != null)
                    {
                        text.Remove(cur.Previous);
                    }

                    break;
                case 'P':
                    text.AddBefore(cur, cmd[2]);
                    break;
            }
        }

        text.RemoveLast();

        cur = text.First;
        while (cur != null)
        {
            sw.Write(cur.Value);
            cur = cur.Next;
        }

        sw.Flush();
    }
}