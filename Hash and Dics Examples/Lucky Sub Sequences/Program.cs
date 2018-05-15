using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucky_Sub_Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> p = new List<int>() { 1, 1, 2, 1, -1, 2, 3, -1, 1, 2, 3, 5, 1, -1, 2, 3 };
            int n = 5;
            List<List<int>> s = GetS(n, p);
            //The 10 elements have been returned into s
        }

        static List<List<int>> GetS(int n, List<int> p)
        {
            List<List<int>> s = new List<List<int>>();
            List<int> subSequence = new List<int>();
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i] == n)
                {
                    s.Add(new List<int>() { p[i] });
                    continue;
                }
                
                subSequence.Add(p[i]);
                for (int j = i + 1; j < p.Count; j++)
                {
                    subSequence.Add(p[j]);
                    if (subSequence.Sum() == n)
                    {
                        s.Add(subSequence);
                        subSequence = new List<int>();
                        break;
                    }
                    if (subSequence.Sum() > n)
                    {
                        subSequence = new List<int>();
                        break;
                    }
                }
                subSequence = new List<int>();
            }
            return s;
        }
    }
}
