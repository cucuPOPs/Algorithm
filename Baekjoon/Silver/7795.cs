class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        int tc = int.Parse(sr.ReadLine());

        while (tc-- > 0)
        {
            string[] s = sr.ReadLine().Split();
            int n = int.Parse(s[0]);
            int m = int.Parse(s[1]);

            int[] arrA = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arrB = sr.ReadLine().Split().Select(int.Parse).ToArray();

            Array.Sort(arrA);
            Array.Sort(arrB);

            int count = 0, j = 0;

            foreach (int a in arrA)
            {
                while (j < m && arrB[j] < a)
                    j++;

                count += j; // j는 B에서 a보다 작은 개수
            }

            sw.WriteLine(count);
        }

        sw.Flush();
    }
}