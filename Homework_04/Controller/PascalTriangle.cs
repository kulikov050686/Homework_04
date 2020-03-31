using System;
using Homework_04.Model;

namespace Homework_04.Controller
{
    public class PascalTriangle
    {
        /// <summary>
        /// Количество строк треугольника
        /// </summary>
        uint N;

        /// <summary>
        /// Массив элементов треугольника
        /// </summary>
        ulong[,] ElementTriangle;

        /// <summary>
        /// Вычислитель элемента треугольника
        /// </summary>
        Combinatorics ElementCalculation;

        /// <summary>
        /// Конструктор нового треугольника Паскаля
        /// </summary>
        /// <param name="n"> Количество строк треугольника </param>
        public PascalTriangle(uint n)
        {
            if(n > 0)
            {
                N = n;
                ElementCalculation = new Combinatorics();
                ElementTriangle = new ulong[N, N];
            }
            else
            {
                throw new ArgumentException("Ошибка ввода данных!");
            }
        }

        /// <summary>
        /// Показать треугольник Паскаля
        /// </summary>
        public void show()
        {
            Console.Clear();

            elementCalculation();
            
            for (uint i = 0; i < N; i++)
            {
                for (uint p = 0; p <= N - i; p++)
                {
                    Console.Write($"{" ",3}");
                }

                for (uint j = 0; j <= i; j++)
                {
                    Console.Write($"{ElementTriangle[j, i],6}");
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Вычисление элементов треугольника
        /// </summary>
        private void elementCalculation()
        {
            for(uint k = 0; k < N; k++)
            {
                for (uint n = k; n < N; n++)
                {
                    ElementTriangle[k, n] = ElementCalculation.combinations(k,n);
                }
            }
        }        
    }
}
