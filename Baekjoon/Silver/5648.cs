class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        // 입력을 한 번에 읽고 공백/줄바꿈 기준으로 나누기
        string[] inputs = sr.ReadToEnd().Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        int n = int.Parse(inputs[0]);
        List<long> numbers = new List<long>();
        
        for (int i = 1; i <= n; i++)
        {
            long reversedNumber = ReverseNumber(long.Parse(inputs[i]));
            numbers.Add(reversedNumber);
        }

        numbers.Sort();

        foreach (var num in numbers)
        {
            sw.WriteLine(num);
        }

        sw.Flush();
    }

    static long ReverseNumber(long num)
    {
        string reversed = new string(num.ToString().Reverse().ToArray());
        return long.Parse(reversed);
    }
}