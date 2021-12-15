using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ConsoleApp1
{
    public class Sort
    {
        public void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length - 1; j++)
                    if (array[j] > array[j + 1])
                    {
                        int t = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = t;
                    }
        }
        public  void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int cur = array[i];
                int j = i;
                while (j > 0 && cur < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = cur;
            }
        }
        public int Partition(int[] Array, int start, int end)
        {
            int temp;
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (Array[i] < Array[end]) 
                {
                    temp = Array[marker]; 
                    Array[marker] = Array[i];
                    Array[i] = temp;
                    marker += 1;
                }
            }

            temp = Array[marker];
            Array[marker] = Array[end];
            Array[end] = temp;
            return marker;
        }
        public void QuickSort(int[] Array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = Partition(Array, start, end);
            QuickSort(Array, start, pivot - 1);
            QuickSort(Array, pivot + 1, end);
        }
        public void ShellSort(int[] Array)
        {
            int step = Array.Length / 2;
            while (step > 0)
            {
                int i, j;
                for (i = step; i < Array.Length; i++)
                {
                    int value = Array[i];
                    for (j = i - step; (j >= 0) && (Array[j] > value); j -= step)
                        Array[j + step] = Array[j];
                    Array[j + step] = value;
                }
                step /= 2;
            }
        }
        public void SelectionSort(int[] Array)
        {
            for (int i = 0; i < Array.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Array.Length; j++)
                {
                    if (Array[j] < Array[min])
                    {
                        min = j;
                    }
                }
                int dummy = Array[i];
                Array[i] = Array[min];
                Array[min] = dummy;
                min = i;
            }
        }

    }

    [MemoryDiagnoser]
    [RankColumn]
    public class Benchmark
    {
        private readonly Sort _sort = new Sort();
         
        [Benchmark]
        public void Benchmark_Bubble()
        {
            int[] array = new int[1000];
            array = Enumerable.Range(0, 1000).Select(s => new Random(s).Next(1000)).ToArray();

            _sort.BubbleSort(array);
        }

        [Benchmark]
        public void Benchmark_Insertion()
        {
            int[] array = new int[1000];
            array = Enumerable.Range(0, 1000).Select(s => new Random(s).Next(1000)).ToArray();

            _sort.InsertionSort(array);
        }
        [Benchmark]
        public void Benchmark_Quick()
        {
            int[] array = new int[1000];
            array = Enumerable.Range(0, 1000).Select(s => new Random(s).Next(1000)).ToArray();

            _sort.QuickSort(array, 0, 500);
        }
        [Benchmark]
        public void Benchmark_Shell()
        {
            int[] array = new int[1000];
            array = Enumerable.Range(0, 1000).Select(s => new Random(s).Next(1000)).ToArray();

            _sort.ShellSort(array);
        }

        [Benchmark]
        public void Benchmark_Selection()
        {
            int[] array = new int[1000];
            array = Enumerable.Range(0, 1000).Select(s => new Random(s).Next(1000)).ToArray();

            _sort.SelectionSort(array);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }
}
