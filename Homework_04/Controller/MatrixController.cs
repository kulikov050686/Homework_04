using System;
using Homework_04.Model;

namespace Homework_04.Controller
{
    public class MatrixController
    {        
        /// <summary>
        /// Сравнивает размеры двух матриц
        /// </summary>
        public bool Compare(Matrix matrix_1, Matrix matrix_2)
        {
            if(matrix_1.Column == matrix_2.Column && matrix_1.Row == matrix_2.Row)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Проверяет матрицы на возможность умножения
        /// </summary>        
        public bool MultiplicationResolution(Matrix matrix_1, Matrix matrix_2)
        {
            if(matrix_1.Column == matrix_2.Row)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Сложение двух матриц
        /// </summary>
        public Matrix Add(Matrix matrix_1, Matrix matrix_2)
        {
            double data = 0;

            if(Compare(matrix_1, matrix_2))
            {
                Matrix matrix_3 = new Matrix(matrix_1.Row, matrix_1.Column);

                for (int i = 0; i < matrix_3.Row; i++)
                {
                    for (int j = 0; j < matrix_3.Column; j++)
                    {
                        data = matrix_1.getItem(i, j) + matrix_2.getItem(i, j);
                        matrix_3.setItem(i, j, data);
                    }
                }

                return matrix_3;
            }

            throw new Exception("Невозможно сложить матрицы!");
        }

        /// <summary>
        /// Вычитание двух матриц
        /// </summary>
        public Matrix Sub(Matrix matrix_1, Matrix matrix_2)
        {
            double data = 0;

            if (Compare(matrix_1, matrix_2))
            {
                Matrix matrix_3 = new Matrix(matrix_1.Row, matrix_1.Column);

                for (int i = 0; i < matrix_3.Row; i++)
                {
                    for (int j = 0; j < matrix_3.Column; j++)
                    {
                        data = matrix_1.getItem(i, j) - matrix_2.getItem(i, j);
                        matrix_3.setItem(i, j, data);
                    }
                }

                return matrix_3;
            }

            throw new Exception("Невозможно вычесть матрицы!");
        }

        /// <summary>
        /// Умножение матриц
        /// </summary>        
        public Matrix Mult(Matrix matrix_1, Matrix matrix_2)
        {
            double data = 0;

            if(matrix_1.Column == matrix_2.Row)
            {
                Matrix matrix_3 = new Matrix(matrix_1.Row, matrix_2.Column);

                for(int i = 0; i < matrix_1.Row; i++)
                {
                    for(int j = 0; j < matrix_2.Column; j++)
                    {
                        for(int r = 0; r < matrix_1.Column; r++)
                        {
                            data += matrix_1.getItem(i, r) * matrix_2.getItem(r, j);
                        }

                        matrix_3.setItem(i, j, data);
                        data = 0;
                    }
                }

                return matrix_3;
            }

            throw new Exception("Невозможно перемножить матрицы!");
        }

        /// <summary>
        /// Умножение матрицы на число
        /// </summary>
        public Matrix MatrixMultByNumber(Matrix matrix, double number)
        {            
            double temp = 0;

            for(int i = 0; i < matrix.Row; i++)
            {
                for(int j = 0; j < matrix.Column; j++)
                {
                    temp = number * matrix.getItem(i, j);
                    matrix.setItem(i, j, temp);
                }
            }

            return matrix;
        }        
    }
}
