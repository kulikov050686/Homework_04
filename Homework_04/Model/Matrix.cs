using System;

namespace Homework_04.Model
{
    public class Matrix
    {
        /// <summary>
        /// Двумерная матрица
        /// </summary>
        double[,] Vector;       

        /// <summary>
        /// Число столбцов матрицы
        /// </summary>
        public int Column { get; }
        
        /// <summary>
        /// Число строк матрицы
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// Генератор псевдослучайных чисел
        /// </summary>
        static Random Rand;

        /// <summary>
        /// Конструктор новой матрицы
        /// </summary>
        /// <param name="NumberOfRow"> Количество строк </param>
        /// <param name="NumberOfColumns"> Количество столбцов </param>
        public Matrix(int NumberOfRow, int NumberOfColumns)
        {
            if(NumberOfColumns >= 1 && NumberOfRow >= 1)
            {
                Column = NumberOfColumns;
                Row = NumberOfRow;                

                Vector = new double[Row, Column];                
            }
            else
            {
                throw new ArgumentException("Матрицы такой размерности не существует!");
            }
        }

        /// <summary>
        /// Установить данные по номеру элемента матрицы
        /// </summary>
        /// <param name="rowNumber"> Номер строки </param>
        /// <param name="columnNumber"> Номер столбца </param>
        /// <param name="data"> Данные </param>
        public void setItem(int rowNumber, int columnNumber, double data)
        {
            if (0 <= rowNumber && rowNumber < Row &&  0 <= columnNumber && columnNumber < Column)
            {
                Vector[rowNumber, columnNumber] = data;
            }
            else
            {
                throw new ArgumentException("Элемента с таким номером не существует!");
            }
        }

        /// <summary>
        /// Получить данные по номеру элемента матрицы
        /// </summary>
        /// <param name="rowNumber"> Номер строки </param>
        /// <param name="columnNumber"> Номер столбца </param>        
        public double getItem(int rowNumber, int columnNumber)
        {
            if (0 <= rowNumber && rowNumber < Row && 0 <= columnNumber && columnNumber < Column)
            {
               return Vector[rowNumber, columnNumber];
            }            

            throw new ArgumentException("Элемента с таким номером не существует!");            
        }

        /// <summary>
        /// Создаёт матрицу и заполняет её числами из диапазона [min, max]
        /// </summary>
        /// <param name="min"> Минимальное число диапазона </param>
        /// <param name="max"> Максимальное число диапазона </param>
        public void createMatrix(int min, int max)
        {
            Rand = new Random();

            for(int i = 0; i < Row; i++)
            {
                for(int j = 0; j < Column; j++)
                {
                    Vector[i, j] = Rand.Next(min, max + 1);
                }
            }
        }

        /// <summary>
        /// Печать матрицы
        /// </summary>
        public void printMatrix()
        {
            for (int i = 0; i < Row; i++)
            {
                Console.Write("|");

                for (int j = 0; j < Column; j++)
                {
                    Console.Write($"{Vector[i, j], 8:0.0}");                    
                }

                Console.Write($"{"|", 4}");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Определяет является ли матрица квадратной
        /// </summary>        
        public bool square()
        {
            if (Row == Column) 
            {
                return true;
            }

            return false;
        }
    }
}
