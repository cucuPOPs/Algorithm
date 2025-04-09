class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        int[] leftChild = new int[n + 1];
        int[] rightChild = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            string s = sr.ReadLine();
            char cur = s[0];
            char left = s[2];
            char right = s[4];
            if (left != '.') leftChild[cur - 'A' + 1] = left - 'A' + 1;
            if (right != '.') rightChild[cur - 'A' + 1] = right - 'A' + 1;
        }

        PreOrder(1);
        sw.WriteLine();

        InOrder(1);
        sw.WriteLine();

        PostOrder(1);
        sw.Flush();

        void PreOrder(int cur)
        {
            sw.Write((char)(cur + 'A' - 1));
            if (leftChild[cur] != 0) PreOrder(leftChild[cur]);
            if (rightChild[cur] != 0) PreOrder(rightChild[cur]);
        }

        void InOrder(int cur)
        {
            if (leftChild[cur] != 0) InOrder(leftChild[cur]);
            sw.Write((char)(cur + 'A' - 1));
            if (rightChild[cur] != 0) InOrder(rightChild[cur]);
        }

        void PostOrder(int cur)
        {
            if (leftChild[cur] != 0) PostOrder(leftChild[cur]);
            if (rightChild[cur] != 0) PostOrder(rightChild[cur]);
            sw.Write((char)(cur + 'A' - 1));
        }
    }
}