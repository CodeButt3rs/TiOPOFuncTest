using TiOPOFuncTest;

namespace TiOPO
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            ArrayFinder();
        }
        static void ArrayFinder()
        {
            int width = 0;
            List<double> arr = new List<double>();
            double c = 0;
            Console.WriteLine("Введите длину массива");
            NumberCorrection(() => { 
                Console.WriteLine("Введите число из диапазона [1; 100]"); 
                width = int.Parse(Console.ReadLine());
                if (width > 100 || width < 5) throw new OutOfRange();
            });
            //
            Console.WriteLine("Заполните массив");
            NumberCorrection(() => {
                Console.WriteLine("Введите число из диапазона [-100; 100]");
                arr.Add(double.Parse(Console.ReadLine()));
                if (width > 100 || width < -100) throw new OutOfRange();
            }, 
            width);
            //
            Console.WriteLine("Введите число C");
            NumberCorrection(() => {
                Console.WriteLine("Введите число из диапазона [-100; 100]");
                c = double.Parse(Console.ReadLine()); 
            });
            ResultStruct r = CustomMath.FindElementsGreatThat(arr.ToArray(), c);
            Console.WriteLine(r.Count);
            Console.WriteLine("[{0}]", string.Join(", ", r.Indexes));
        }
        static void NumberCorrection(Action dofunc, int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                try
                {
                    dofunc();
                }
                catch (Exception)
                {
                    Console.WriteLine("Неверное число!");
                    i--;
                }
            }
        }
        static void DiscrFunc()
        {
            string[] letters = { "a", "b", "c" };
            double[] arguments = new double[3];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Введите число {letters[i]} из диапазона [-10000;10000]");
                try
                {
                    arguments[i] = double.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                    Console.WriteLine($"Неверное значение.");
                    i--;
                }
            }
            try
            {
                double[] result = CustomMath.Discr(arguments[0], arguments[1], arguments[2]);
                if (result.Length > 1)
                {
                    Console.WriteLine($"x1 = {result[0]}, x2 = {result[1]}");
                }
                else
                {
                    Console.WriteLine($"x = {result[0]}");
                }
            }
            catch (NoSqrts)
            {

                Console.WriteLine("Нет корней");
            }
        }
    }
}