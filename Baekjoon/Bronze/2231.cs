class Program
{
    private const int bufferSize = 131072;
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());

        int res = 0;
        for (int i = 1; i < n; i++)
        {
            int number = i;
            int sum = number;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            if (sum == n)
            {
                res = i;
                break;
            }
        }

        sw.WriteLine(res);
        sw.Flush();
    }
}
