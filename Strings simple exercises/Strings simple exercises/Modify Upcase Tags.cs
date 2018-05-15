using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings_simple_exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string sent = "We are living in a <upcase>yellow submarine</upcase>. <upcase>We don't</upcase> have <upcase>anything</upcase> else.";
            StringBuilder sb = new StringBuilder();
            string openTag = "<upcase>";
            string closeTag = "</upcase>";
            int firstInd = sent.IndexOf(openTag);
            int secInd = sent.IndexOf(closeTag);
            int sbLen = 0;
            while (firstInd != -1)
            {
                int tempIndex = firstInd - sbLen;
                sb.Append(sent.Substring(sbLen, tempIndex));
                tempIndex = firstInd + openTag.Length;
                int tempindex2 = secInd - tempIndex;
                string tempStr = sent.Substring(tempIndex, tempindex2);
                sb.Append(tempStr.ToUpper());
                sbLen = secInd + closeTag.Length;
                firstInd = sent.IndexOf(openTag, firstInd + 1);
                secInd = sent.IndexOf(closeTag, secInd + 1);
            }
            int temp = sent.Length - sbLen;
            sb.Append(sent.Substring(sbLen, temp));
            Console.WriteLine("String before modification: \n{0}", sent);
            Console.WriteLine("String after modification: \n{0}", sb.ToString());
            Console.ReadKey();
        }
    }
}
