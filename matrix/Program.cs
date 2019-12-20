using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix<int> a = new Matrix<int>(2, 3);
            a[0, 0] = 1;
            a[0, 1] = 4;
            a[0, 2] = 3;
            a[1, 0] = 3;
            a[1, 1] = 5;
            a[1, 2] = 7;

            Matrix<int> b = new Matrix<int>(2, 3);
            b[0, 0] = 1;
            b[0, 1] = 4;
            b[0, 2] = 5;
            b[1, 0] = 3;
            b[1, 1] = 5;
            b[1, 2] = 7;

            Matrix<int> d = new Matrix<int>(3, 2);
            d[0, 0] = 1;
            d[0, 1] = 2;
            d[1, 0] = 5;
            d[1, 1] = 2;
            d[2, 0] = 1;
            d[2, 1] = 6;

            // addition
            Matrix<int> c = a + b;

            Console.WriteLine(c);

            // subtraction
            c = a - b;
            Console.WriteLine(c);
            if (c)
                Console.WriteLine("Matrix has no zero elements");

            else
                Console.WriteLine("MATRIX HAS ELEMENTS WITH VALUE ZERO");

            // multiplication
            c = a * d;
            Console.WriteLine(c);

            if (c)
                Console.WriteLine("Matrix has no zero elements");

            else
                Console.WriteLine("MATRIX HAS ELEMENTS WITH VALUE ZERO");


            // IEnumerable test
            foreach (var element in c)
            {
                Console.WriteLine(element);
            }
            Console.ReadKey();
        }
    }
    }
}
