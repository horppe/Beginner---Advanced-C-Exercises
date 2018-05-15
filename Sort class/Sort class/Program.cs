using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_class
{
    class Program
    {
        static void Main(string[] args)
        {
            Sort sort = new Sort();
            int[] array = { 3, 5, 7, 9, 1, 4, 10, 6, 2, 8};
            sort.QuickSort(array);
            Console.ReadKey();
        }
    }

    class Sort
    {
        public int[] Selection(int[] array)
        {
            int index = 0;
            while (index < array.Length)
            {
                for (int i = index; i < array.Length; i++)
                {
                    if (array[i] < array[index])
                    {
                        int temp = array[i];
                        array[i] = array[index];
                        array[index] = temp;
                    }
                }
                index++;
            }
            return array;
        }
        public void Insertion(int[] array)
        {
            int index = 1;
            while (index < array.Length)
            {
                int j = index;
                while (j > 0 && array[j] < array[j - 1])
                {
                    j--;
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
                index++;
            }
        }

        private int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];
            while (true)
            {
                while (numbers[left] < pivot)
                    left++;

                while (numbers[right] > pivot)
                    right--;

                if (left < right)
                {
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        private void SortQuick(int[] arr, int left, int right)
        {
            // For Recusrion  
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                    SortQuick(arr, left, pivot - 1);

                if (pivot + 1 < right)
                    SortQuick(arr, pivot + 1, right);
            }
        }

        public void QuickSort(int[] array)
        {
            int max = array.Length;
            Console.WriteLine("QuickSort By Recursive Method");
            SortQuick(array, 0, max - 1);
            for (int i = 0; i < max; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadLine();
        }
    }
}
