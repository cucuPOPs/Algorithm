class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        string[] s = sr.ReadLine().Split();
        int n = int.Parse(s[0]);
        int m = int.Parse(s[1]);

        char[,] board = new char[n, m];

        for (int i = 0; i < n; i++)
        {
            string a = sr.ReadLine();
            for (int j = 0; j < m; j++)
            {
                board[i, j] = a[j];
            }
        }

        int minDiff = int.MaxValue;
        for (int x = 0; x <= n - 8; x++)
        {
            for (int y = 0; y <= m - 8; y++)
            {
                int whiteDiff = 0;
                int blackDiff = 0;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        char whiteBoard = ((i + j) % 2 == 0) ? 'W' : 'B';
                        char blackBoard = ((i + j) % 2 == 0) ? 'B' : 'W';

                        if (board[x + i, y + j] != whiteBoard) whiteDiff++;
                        if (board[x + i, y + j] != blackBoard) blackDiff++;
                    }
                }

                if (minDiff > whiteDiff) minDiff = whiteDiff;
                if (minDiff > blackDiff) minDiff = blackDiff;
            }
        }

        sw.WriteLine(minDiff);
        sw.Flush();
    }
}