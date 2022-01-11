using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Params
{
    internal class Params
    {
        static void Main(string[] args)
        {
            double average;
            average = CalculateAverage(4.0, 3.2, 5.7, 64.22, 87.2);
            Console.WriteLine("Среднее: " + average);
            // Передать список значений double, разделенных запятыми...

            double[] data = { 4.0, 3.2, 5.7 };
            average = CalculateAverage(data);
            Console.WriteLine("Среднее: " + average);
            // ... или передать массив значении double.

            Console.ReadKey();
        }
        // Возвращение среднего из некоторого количества значений double
        static double CalculateAverage(params double[] values)
        {
            Console.WriteLine("Размер массива: {0} ", values.Length);
            double sum = 0;
            for (int i = 0; i < values.Length; i++)
                sum+=values[i];
            return sum/values.Length;
        }
    }
}
