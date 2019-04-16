using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays.Net
{
    class Program
    {
        private static string[] monthNames = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Otc", "Nov", "Dec"};
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] a = new int [20];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = r.Next(-10, 11);
                Console.Write($"{a[i]}, ");
            }

            Console.WriteLine( "\nSorting:");
            Array.Sort(a);

            ArrayPrint(a);

            Console.WriteLine("\n Binary search of '5':");
            Console.WriteLine(Array.BinarySearch(a, 5));

            Array.Clear(a, 10, 5);
            ArrayPrint(a);

            int[] b = new int[50];
            //Array.Copy(a, 0, b, 7, 10);
            Array.Copy(a, b, 20);   //a.CopyTo(b, 20);
            ArrayPrint(b);
            a = b;
            ArrayPrint(a);

            // Linear (sequential) search
            Console.WriteLine($"\nIndexOf(10): {Array.IndexOf(a, 0,Array.IndexOf(a, 0, Array.IndexOf(a, 0, Array.IndexOf(a, 0)+1) + 1) +1)}");

            int[,] c = new int[5, 4];
            Console.WriteLine(c.Rank);                                  // Number of dimensions
            for (int row = 0; row < c.GetLength(0); row++)              // Loop for rows
                for (int column = 0; column < c.GetLength(1); column++) // Loop for columns
                    c[row, column] = r.Next(0, 21);                     // Filling the 2D array elements
            ArrayPrint(c);
            
            //Array.Sort(c); // Doesn't work with multidimensional arrays
            int[] temp = new int[c.Length];
            int k = 0;
            foreach (int item in c)
                temp[k++] = item;
            Array.Sort(temp);
            k = 0;
            for (int row = 0; row < c.GetLength(0); row++)
                for (int column = 0; column < c.GetLength(1); column++)
                    c[row, column] = temp[k++];
            
            ArrayPrint(c);

            // ------------------------------------------------
            const int MONTHS = 12;  // month number
            const int LONG_MONTH_DAYS = 31;
            const int SHORT_MONTH_DAYS = 30;
            const int FEBRUARY_DAYS = 28;

            double[][] weather = new double[MONTHS][];

            for (int i = 0; i < MONTHS; i+=2)
            {
                if (i == 8)
                    i--;
                weather[i] = new double[LONG_MONTH_DAYS];
            }
            for (int i = 3; i < MONTHS; i += 2)
            {
                if (i == 7)
                    i--;
                weather[i] = new double[SHORT_MONTH_DAYS];
            }
            weather[1] = new double[FEBRUARY_DAYS];
            Random rnd = new Random();
            int delta = -25;
            for (int month = 0; month < MONTHS; month++)
            {
                for (int day = 0; day < weather[month].Length; day++)
                    weather[month][day] = -rnd.NextDouble()*15+delta;

                if (month< 7)
                    delta += 7;
                else
                    delta -= 7;
            }

            JaggedArrayPrint(weather);


            for (int i =0; i < weather.GetLength(0); i++)
            {
                Console.WriteLine(monthNames[i] + ") "  + AverageValue(weather[i]));                
            }
            //weather[1] = new double[35];
            Array.Resize(ref weather[1], 35);
            JaggedArrayPrint(weather);

            Console.WriteLine("\n\n------------------------------\n");
            List<double> arraylist = new List<double>();
            arraylist.Add(12);
            arraylist.Add(13);
            arraylist.Add(14);
            for (int i = 0; i < arraylist.Count; i++)
                Console.WriteLine(arraylist[i]);
            Console.WriteLine($"Count {arraylist.Count}, Capacity: {arraylist.Capacity}");
            arraylist.Add(1234);
            arraylist.Add(1234);
            Console.WriteLine($"Count {arraylist.Count}, Capacity: {arraylist.Capacity}");

        }

        private static double AverageValue(double[] month)
        {
            double avg = 0;
            foreach (double day in month)
                avg += day;

            return avg / month.Length;
        }

        private static void JaggedArrayPrint(double [][] array)
        {
            Console.WriteLine("\n-------------------------\n");
            for (int month = 0; month < array.GetLength(0); month++)
            {
                Console.Write("\n" + (monthNames[month]) + ") ");
                for (int day = 0; day < array[month].Length; day++)
                {
                    Console.Write(String.Format("{0:0.0}", array[month][day]) + " ");
                }
            }
            Console.WriteLine();
         }

            private static void ArrayPrint(int[] a)
        {
            Console.WriteLine("---------------------------------------\n");
            foreach (var item in a)
                Console.Write($"{item}, ");
            Console.WriteLine();
        }

        private static void ArrayPrint(int[,] c)
        {
            Console.WriteLine("---------------------------------------\n");
            for (int i = 0; i < c.GetLength(0); i++)
            {
                for (int j = 0; j < c.GetLength(1); j++)
                {
                    Console.Write($"{c[i, j]}\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

    }
}
