using System;

namespace Homework_04.Model
{
    public class Combinatorics
    {
        /// <summary>
        /// Факториал числа
        /// </summary>
        /// <param name="n"> Число </param>
        public ulong factorial(uint n)
        {
            if (n == 0) return 1;
            if (n == 1) return 1;

            return n * factorial(n - 1);
        }

        /// <summary>
        /// Число сочетаний без повторений (n>=k)
        /// </summary>
        /// <param name="k"> Число </param>
        /// <param name="n"> Число </param>
        /// <returns></returns>
        public ulong combinations(uint k, uint n)
        {
            if(n >= k)
            {
                return factorial(n) / (factorial(n - k) * factorial(k));
            }

            throw new ArgumentException("Ошибка ввода данных!");
        }

        /// <summary>
        /// Число размещений без повторений (n>=k)
        /// </summary>
        /// <param name="k"> Число </param>
        /// <param name="n"> Число </param>
        /// <returns></returns>
        public ulong placement(uint k, uint n)
        {
            if(n>=k)
            {
                return factorial(n) / factorial(n - k);
            }

            throw new ArgumentException("Ошибка ввода данных!");
        }
    }
}
