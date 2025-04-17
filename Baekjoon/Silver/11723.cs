class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        int m = int.Parse(sr.ReadLine());
        int mask = 0;

        for (int i = 0; i < m; i++)
        {
            string[] s = sr.ReadLine().Split();
            string cmd = s[0];

            if (cmd[1] == 'd') //add
            {
                int x = int.Parse(s[1]);
                mask |= (1 << (x - 1));
            }
            else if (cmd[1] == 'e') //remove
            {
                int x = int.Parse(s[1]);
                mask &= ~(1 << (x - 1));
            }
            else if (cmd[1] == 'h') //check
            {
                int x = int.Parse(s[1]);
                sw.WriteLine((mask & (1 << (x - 1))) != 0 ? "1" : "0");
            }
            else if (cmd[1] == 'o') //toggle
            {
                int x = int.Parse(s[1]);
                mask ^= (1 << (x - 1));
            }
            else if (cmd[1] == 'l') //all
            {
                mask = (1 << 20) - 1;
            }
            else //empty
            {
                mask = 0;
            }
        }

        sw.Flush();
    }
}