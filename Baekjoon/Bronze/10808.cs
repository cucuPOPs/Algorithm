//메모리: 5464KB, 시간: 52ms

class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        string s = sr.ReadLine();
        int[] a = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            a[s[i] - 'a']++;
        }

        sw.Write(string.Join(" ", a));
        sw.Flush();
    }
}