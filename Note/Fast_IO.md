[Back(메인으로)](/README.md)  

출처: https://www.acmicpc.net/source/72759533  
또 보이면... 정리해보자.

```C#
class Reader
{
    StreamReader R;
    public Reader() => R = new(new BufferedStream(Console.OpenStandardInput()));

    public int NextInt()
    {
        var (v, n, r) = (0, false, false);
        while (true)
        {
            int c = R.Read();
            if ((r, c) == (false, '-'))
            {
                (n, r) = (true, true);
                continue;
            }

            if ('0' <= c && c <= '9')
            {
                (v, r) = (v * 10 + (c - '0'), true);
                continue;
            }

            if (r == true) break;
        }

        return n ? -v : v;
    }

    public string NextString(int m)
    {
        var (v, r, l) = (new char[m + 1], false, 0);
        while (true)
        {
            int c = R.Read();
            if (r == false && (c == ' ' || c == '\n' || c == '\r')) continue;
            if (r == true && (l == m || c == ' ' || c == '\n' || c == '\r')) break;
            v[l++] = (char)c;
            r = true;
        }

        return new string(v, 0, l);
    }

    public char NextChar()
    {
        char v = '\0';
        while (true)
        {
            int c = R.Read();
            if (c != ' ' && c != '\n' && c != '\r')
            {
                v = (char)c;
                break;
            }
        }

        return v;
    }
}
```
