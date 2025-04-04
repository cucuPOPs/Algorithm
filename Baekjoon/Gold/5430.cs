
class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장 빠른 속도.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        int tc = int.Parse(sr.ReadLine());

        while (tc-- > 0)
        {
            string cmd = sr.ReadLine();
            int n = int.Parse(sr.ReadLine());

            // 빈 배열 입력 시 예외 방지
            string input = sr.ReadLine().Trim('[', ']');
            string[] s = (input.Length == 0) ? Array.Empty<string>() : input.Split(',');
            int[] arr = (input.Length == 0) ? Array.Empty<int>() : Array.ConvertAll(s, int.Parse);

            // 배열을 이용한 덱 구현
            int left = 0, right = n - 1;
            bool reversed = false;
            bool error = false;

            foreach (char c in cmd)
            {
                if (c == 'R')
                {
                    reversed = !reversed;
                }
                else if (c == 'D')
                {
                    if (left > right)
                    {
                        error = true;
                        break;
                    }

                    if (reversed)
                    {
                        right--; // 뒤집혔을 경우 뒤쪽 원소 제거
                    }
                    else
                    {
                        left++; // 정방향이면 앞쪽 원소 제거
                    }
                }
            }

            // 결과 출력
            if (error)
            {
                sw.WriteLine("error");
            }
            else
            {
                sw.Write("[");
                if (reversed)
                {
                    for (int i = right; i >= left; i--)
                    {
                        sw.Write(arr[i]);
                        if (i > left) sw.Write(",");
                    }
                }
                else
                {
                    for (int i = left; i <= right; i++)
                    {
                        sw.Write(arr[i]);
                        if (i < right) sw.Write(",");
                    }
                }
                sw.WriteLine("]");
            }
        }

        sw.Flush();
    }
}