class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        string a = sr.ReadLine();
        string b = sr.ReadLine();

        int[] arr = new int[26];
        foreach (char ch in a)
        {
            arr[ch - 'a']++;
        }
        foreach (char ch in b)
        {
            arr[ch - 'a']--;
        }
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += myAbs(arr[i]);
        }
        sw.WriteLine(sum);
        sw.Flush();
    }

    static int myAbs(int a)
    {
        return a < 0 ? -a : a;
    }
}