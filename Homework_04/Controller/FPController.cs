using System;
using Homework_04.Model;

namespace Homework_04.Controller
{
    public class FPController
    {
        /// <summary>
        /// Генератор псевдослучайных чисел
        /// </summary>
        static Random Rand;

        /// <summary>
        /// Финансовые показатели
        /// </summary>
        FinancialPerformance[] Financial;
        
        /// <summary>
        /// Показать финансовый отчёт
        /// </summary>
        public void show()
        {
            Console.Clear();

            generateReport();

            Console.WriteLine($"{"Месяц",5} | {"Доход",6} | {"Расходы",6} | {"Прибыль",5} |");

            for(int i = 0; i < 12; i++)
            {
                Console.Write($"{Financial[i].Month, 6}|");
                Console.Write($"{Financial[i].Income, 8:0 000}|");
                Console.Write($"{Financial[i].Costs, 9:0 000}|");

                if(Financial[i].Profit == 0)
                {
                    Console.WriteLine($"{Financial[i].Profit,9}|");
                }
                else 
                {
                    Console.WriteLine($"{Financial[i].Profit,9:0 000}|");
                }                
            }

            Console.WriteLine();
            Console.WriteLine($"Месяцев с положительной прибылью: {positiveProfit()}");            
            Console.WriteLine($"Худшая прибыль в месяцах: {WorstProfitMonths()}");            
        }

        /// <summary>
        /// Генерация финансового отчёта
        /// </summary>
        private void generateReport()
        {
            Rand = new Random();
            Financial = new FinancialPerformance[12];

            for (int i = 0; i < 12; i++)
            {
                Financial[i] = new FinancialPerformance();

                Financial[i].Month = i + 1;
                Financial[i].Income = 10000 * Rand.Next(10, 21);
                Financial[i].Costs = 10000 * Rand.Next(8, 16);
            }
        }

        /// <summary>
        /// Число месяцев с положительной прибылью
        /// </summary>
        private int positiveProfit()
        {
            int count = 0;

            for(int i = 0; i < 12; i++)
            {
                if (Financial[i].Profit > 0) count++;
            }

            return count;
        }

        /// <summary>
        /// Месяцы показывающие худшую прибыль
        /// </summary>
        /// <returns></returns>
        private string WorstProfitMonths()
        {
            FinancialPerformance[] temp = new FinancialPerformance[12];
            string str = "";
            int count = 0;

            for(int i = 0; i < 12; i++)
            {
                temp[i] = new FinancialPerformance();
                temp[i].Month = Financial[i].Month;
                temp[i].Income = Financial[i].Income;
                temp[i].Costs = Financial[i].Costs;                
            }

            Array.Sort(temp);

            for(int i = 0; i < 12; i++)
            {
                if(temp[i].Profit <= 0)
                {
                    str += Convert.ToString(temp[i].Month) + " ";
                }

                if(temp[i].Profit > 0)
                {
                    str += Convert.ToString(temp[i].Month) + " ";

                    if (i < 11)
                    {
                        if (temp[i + 1].Profit != temp[i].Profit)
                        {
                            count++;
                        }
                    }                                     
                }

                if(count == 3)
                {
                    break;
                }
            }

            return str;
        }        
    }
}
