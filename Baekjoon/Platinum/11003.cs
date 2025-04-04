class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장 빠른 속도.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        string[] input = sr.ReadLine().Split();
        int N = int.Parse(input[0]);
        int L = int.Parse(input[1]);

        string[] values = sr.ReadLine().Split();
        int[] arr = new int[N];
        for (int i = 0; i < N; i++)
            arr[i] = int.Parse(values[i]);

        int[] queue = new int[N];  // 인덱스 저장
        int start = 0, end = 0;   // 큐의 앞/뒤 포인터

        for (int i = 0; i < N; i++)
        {
            // 1. 큐에서 윈도우를 벗어난 값 제거
            if (start < end && queue[start] <= i - L)
                start++;

            // 2. 새로운 값이 들어오면, 기존 큐의 뒷부분에서 큰 값 제거
            while (start < end && arr[queue[end - 1]] > arr[i])
                end--;

            // 3. 현재 인덱스를 큐에 추가
            queue[end++] = i;

            // 4. 큐의 맨 앞이 최솟값을 가지므로 결과에 추가
            sw.Write(arr[queue[start]] + " ");
        }
        sw.Flush();
    }
}