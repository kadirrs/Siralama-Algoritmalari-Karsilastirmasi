using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime;

namespace SiralamAlgoritmalari
{
    public class Program
    {
        public static void Main(string[] args)
        {

            int[] array = new int[50000];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next();
            }

            Stopwatch stopwatch = new Stopwatch();

            int tekrarSayisi = 1;
            double BubleSorttoplamSure = 0;
            double SelectionSorttoplamSure = 0;
            double InsertionSorttoplamSure = 0;
            double QuickSorttoplamSure = 0;
            double MergeSorttoplamSure = 0;
            for (int i = 0; i < tekrarSayisi; i++)
            {
                stopwatch.Start();
                BubbleSort(array);
                stopwatch.Stop();
                BubleSorttoplamSure += stopwatch.Elapsed.TotalMilliseconds;
                //Console.WriteLine("Bubble Sort: " + stopwatch.ElapsedMilliseconds + "Milisaniye");

                stopwatch.Reset();
                stopwatch.Start();
                SelectionSort(array);
                stopwatch.Stop();
                SelectionSorttoplamSure += stopwatch.Elapsed.TotalMilliseconds;
                //Console.WriteLine("Selection Sort: " + stopwatch.ElapsedMilliseconds + "Milisaniye");

                stopwatch.Reset();
                stopwatch.Start();
                InsertionSort(array);
                stopwatch.Stop();
                InsertionSorttoplamSure += stopwatch.Elapsed.TotalMilliseconds;
                //Console.WriteLine("Insertion Sort: " + stopwatch.ElapsedMilliseconds + "Milisaniye");

                stopwatch.Reset();
                stopwatch.Start();
                QuickSort(array, 0, array.Length - 1);
                stopwatch.Stop();
                TimeSpan elapsed = stopwatch.Elapsed;
                long elapsedNanoSeconds = elapsed.Ticks / TimeSpan.TicksPerMillisecond * 1000000;
                QuickSorttoplamSure += elapsedNanoSeconds;
                //Console.WriteLine("Quick Sort: " + elapsedNanoSeconds + "Nanosaniye");

                stopwatch.Reset();
                stopwatch.Start();
                MergeSort(array, 0, array.Length - 1);
                stopwatch.Stop();
                //Console.WriteLine("Merge Sort: " + stopwatch.ElapsedMilliseconds + "MiliSaniye");
                MergeSorttoplamSure += stopwatch.Elapsed.TotalMilliseconds;

            }
            double BubleOrtalamaSure = BubleSorttoplamSure / tekrarSayisi;
            double SelectionOrtalamaSure = SelectionSorttoplamSure / tekrarSayisi;
            double InsertionOrtalamaSure = InsertionSorttoplamSure / tekrarSayisi;
            double QuickOrtalamaSure = QuickSorttoplamSure / tekrarSayisi;
            double MergeOrtalamaSure = MergeSorttoplamSure / tekrarSayisi;
            Console.WriteLine("BubleSort Ortalama Süresi: " + BubleSorttoplamSure + "  Milisaniye");
            Console.WriteLine("SelectionSort Ortalama Süresi: " + SelectionSorttoplamSure + "  Milisaniye");
            Console.WriteLine("InsertionSort Ortalama Süresi: " + InsertionSorttoplamSure + "  Milisaniye");
            Console.WriteLine("QuickSort Ortalama Süresi: " + QuickSorttoplamSure + "  Nanosaniye");
            Console.WriteLine("MergeSort Ortalama Süresi: " + MergeSorttoplamSure + "  Milisaniye");
            Console.ReadLine();

        }

        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }


        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int current = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > current)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = current;
            }
        }

        public static void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(array, low, high);

                if (!IsSorted(array, low, pivot - 1))
                {
                    QuickSort(array, low, pivot - 1);
                }

                if (!IsSorted(array, pivot + 1, high))
                {
                    QuickSort(array, pivot + 1, high);
                }
            }
        }

        private static bool IsSorted(int[] array, int low, int high)
        {
            for (int i = low + 1; i <= high; i++)
            {
                if (array[i] < array[i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        public static int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            int temp2 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp2;

            return i + 1;
        }

        public static void MergeSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;

                MergeSort(array, low, mid);
                MergeSort(array, mid + 1, high);

                Merge(array, low, mid, high);
            }
        }

        public static void Merge(int[] array, int low, int mid, int high)
        {
            int[] temp = new int[high - low + 1];
            int i = low;
            int j = mid + 1;
            int k = 0;

            while (i <= mid && j <= high)
            {
                if (array[i] <= array[j])
                {
                    temp[k++] = array[i++];
                }
                else
                {
                    temp[k++] = array[j++];
                }
            }

            while (i <= mid)
            {
                temp[k++] = array[i++];
            }

            while (j <= high)
            {
                temp[k++] = array[j++];
            }

            for (int m = 0; m < temp.Length; m++)
            {
                array[low + m] = temp[m];
            }
        }

    }
}

