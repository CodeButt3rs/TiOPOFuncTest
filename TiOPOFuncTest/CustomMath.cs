using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiOPOFuncTest
{
    public class CustomMath
    {
        public static double[] Discr(double a, double b, double c)
        {
            if (a < -10000 || a > 10000 || b < -10000 || b > 10000 || c < -10000 || c > 10000) throw new OutOfRange();
            double d = Math.Pow(b, 2) - 4 * a * c;
            if (d < 0) throw new NoSqrts();
            if (d == 0) return new double[1] { (-b) / 2 * a };
            return new double[2] { (-b + Math.Sqrt(d)) / (2 * a), (-b - Math.Sqrt(d)) / (2 * a) };
        }
        public static ResultStruct FindElementsGreatThat(double[] arr, double c)
        {
            List<double> indexes = new List<double>();
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] > c)
                {
                    indexes.Add(i);
                    count++;
                }
            }
            return new ResultStruct(indexes.ToArray(), count);
        }
    }
    public struct ResultStruct
    {
        public ResultStruct(double[] arr, int count)
        {
            Indexes = arr;
            Count = count;
        }
        public double[] Indexes { get; }
        public int Count { get; }
    }
}
