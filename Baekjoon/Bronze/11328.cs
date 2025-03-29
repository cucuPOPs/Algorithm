class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        while (n-- > 0)
        {
            string[] s = sr.ReadLine().Split();
            int[] a = new int[26];
            foreach (char c in s[0])
            {
                a[c - 'a']++;
            }
            foreach (char c in s[1])
            {
                a[c - 'a']--;
            }

            bool isPossible = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != 0)
                {
                    isPossible = false;
                    break;
                }
            }

            sw.WriteLine(isPossible ? "Possible" : "Impossible");
        }

        sw.Flush();
    }
}