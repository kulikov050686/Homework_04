using System;

namespace Homework_04.Model
{
    public class FinancialPerformance : IComparable<FinancialPerformance>
    {
        int month;
        double income;
        double costs;

        /// <summary>
        /// Номер месяца (1 - 12)
        /// </summary>
        public int Month
        {
            get 
            {
                return month;
            }

            set 
            {
                if(value > 0 && value <= 12)
                {
                    month = value;
                }
                else
                {
                    throw new ArgumentException("Месяца с таким номером не существует!");
                }
            }
        }

        /// <summary>
        /// Доход
        /// </summary>
        public double Income
        {
            get
            {
                return income;
            }

            set
            {
                if(value >= 0)
                {
                    income = value;
                }
                else
                {
                    income = 0;
                }
            }
        }

        /// <summary>
        /// Расходы
        /// </summary>
        public double Costs
        {
            get
            {
                return costs;
            }

            set
            {
                if (value >= 0)
                {
                    costs = value;
                }
                else
                {
                    costs = 0;
                }
            }
        }

        /// <summary>
        /// Прибыль
        /// </summary>
        public double Profit
        {
            get 
            {
                return Income - Costs;
            }
        }

        /// <summary>
        /// Сравнения объектов
        /// </summary>
        /// <param name="financial"> Объект сравнения </param>
        public int CompareTo(FinancialPerformance financial)
        {
            return Profit.CompareTo(financial.Profit);           
        }
    }
}
