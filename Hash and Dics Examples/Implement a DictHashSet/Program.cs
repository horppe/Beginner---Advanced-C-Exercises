using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implement_a_DictHashSet
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<string>> dicOfDic = new Dictionary<int, List<string>>();
            dicOfDic[21] = new List<string>();
            dicOfDic[21].Add( "I now have two nested Dictionaries working together.");
            Console.ReadKey();
        }
    }
}
