using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_tasks_Successively
{
    class Program
    {
        static List<Task> tasks = new List<Task>();
        
        static void Main(string[] args)
        {
            tasks.Add(new Task(1, 2));
            tasks.Add(new Task(2, 5));
            tasks.Add(new Task(2, 4));
            tasks.Add(new Task(3, 1));
            for (int i = 0; i < tasks.Count; i++)
            {
                if (NotDependent(tasks[i].value))
                {
                    Traverse(tasks[i].value);
                    break;
                }
            }
            Console.ReadKey();
        }

        static void Traverse(int start)
        {
            Console.Write(start + " ");
            List<int> children = GetChildren(start);
            foreach (int task in children)
            {
                Traverse(task);
            }
        }

        static List<int> GetChildren(int task)
        {
            List<int> children = new List<int>();
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].value == task)
                {
                    children.Add(tasks[i].nextTask);
                }
            }
            return children;
        }

        static bool NotDependent(int start)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].nextTask == start)
                {
                    return false;
                }
            }
            return true;
        }
    }
    class Task
    {
        public int value;
        public int nextTask;
        
        public Task(int value, int nextTask)
        {
            this.value = value;
            this.nextTask = nextTask;
        }
    }
}
