class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        string[] times = sr.ReadLine().Split();
        string sTime = times[0];
        string eTime = times[1];
        string qTime = times[2];

        HashSet<string> entered = new(); // 입장한 사람
        HashSet<string> answered = new(); // 출석 인정된 사람

        string line;
        while ((line = sr.ReadLine()) != null)
        {

            string[] parts = line.Split();
            string time = parts[0];
            string name = parts[1];

            if (string.Compare(time, sTime) <= 0)
            {
                entered.Add(name);
            }
            else if (string.Compare(time, eTime) >= 0 && string.Compare(time, qTime) <= 0)
            {
                if (entered.Contains(name) && !answered.Contains(name))
                {
                    answered.Add(name);
                }
            }
        }

        sw.WriteLine(answered.Count);
        sw.Flush();
    }
}