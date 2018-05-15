using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace String_to_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            DataTable dt = new DataTable();
            string add = "-1 + 2 + 3 * 4 - 0.5";
            var sum = dt.Compute(add, "");
            calc.Multiply(add);
            Console.ReadKey();
        }
    }

    class Calculator
    {
        private List<string> sum = new List<string>();
        private List<int> priority = new List<int>();
        public List<string> exp = new List<string>();
        private void Add()
        {

        }
        private void Subtract()
        {

        }
        public void Multiply(string value)
        {
            int valid;
            string[] val = value.Split(' ');
            int cal = 1;
            for (int i = 0; i < val.Length; i++)
            {
                if (int.TryParse(val[i], out valid))
                {
                    priority.Add(int.Parse(val[i]));
                }
            }
            cal = priority[0] * priority[1];
            sum.Add(cal);
        }
        private void Division(string value)
        {
            int valid;
            string[] val = value.Split(' ');
            int cal = 1;
            for (int i = 0; i < val.Length; i++)
            {
                if (int.TryParse(val[i], out valid))
                {
                    priority.Add(int.Parse(val[i]));
                }
            }
            
                cal *= priority[i];
            }
            sum.Add(cal);
        }
        private void Power()
        {

        }
        private void Log()
        {

        }
        private void Sqrt()
        {

        }
        public void Remover(int pos)
        {
            
            if (exp[pos] == "*")
            {
                StringBuilder bld = new StringBuilder();
                int cnt = pos - 1;
                for (int i = 0; i <= 2; i++)
                {
                    bld.Insert(i, exp[cnt++]);
                }
                string send = bld.ToString();
                Multiply(send);
            }
            if (exp[pos] == "/")
            {
                StringBuilder bld = new StringBuilder();
                int cnt = pos - 1;
                for (int i = 0; i <= 2; i++)
                {
                    bld.Insert(i, exp[cnt++]);
                }
                string send = bld.ToString();
                Division(send);
            }
        }
        public void Interface()
        {
            string exp = "-1 + 2 + 3 * 4 - 0.5";
            //Console.Write(" ");
            //string exp = Console.ReadLine();
            string[] expArray = exp.Split(' ', '+');
            List<string> send = new List<string>();
            Remover(expArray, send, 0);
            Console.ReadKey();
        }
    }
}
