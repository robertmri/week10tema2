using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class Program
    {
        public static class StringsProblem
        {
            public static string ReverseString(string S)
            {
                if (S == null || S == "")
                    throw new InvalidOperationException();
                int start = 0;
                int end = S.Length - 1;
                char[] sRev = S.ToCharArray();

                while (start < end)
                {
                    if (
                        (S[start] < 65 || S[start] > 90) &&
                        (S[start] < 97 || S[start] > 122))
                        start++;

                    else if (
                        (S[end] < 65 || S[end] > 90) &&
                        (S[end] < 97 || S[end] > 122))
                        end--;

                    else
                    {
                        sRev[start] = (char)(sRev[start] + sRev[end]);
                        sRev[end] = (char)(sRev[start] - sRev[end]);
                        sRev[start] = (char)(sRev[start] - sRev[end]);

                        start++;
                        end--;
                    }
                }

                StringBuilder sb = new StringBuilder();
                foreach (var x in sRev)
                    sb.Append(x);
                return sb.ToString();
            }
        }
    }
}
