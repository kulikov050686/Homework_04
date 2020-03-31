using System;
using Homework_04.Controller;

namespace Homework_04.View
{
    public class HomeWork
    {
        /// <summary>
        /// Завершение программы
        /// </summary>
        bool Exit;

        /// <summary>
        /// Конструктор домашнего задания
        /// </summary>
        public HomeWork()
        {
            Exit = false;
        }

        /// <summary>
        /// Запуск приложения
        /// </summary>
        public void run()
        {
            while (!Exit)
            {
                startMenu();
            }            
        }

        /// <summary>
        /// Стартовое меню
        /// </summary>
        void startMenu()
        {
            string[] itensMenu = new string[] { "Задание 1",
                                                "Задание 2", 
                                                "Задание 3",
                                                "Выход" };

            NewMenu menu = new NewMenu(itensMenu, "Выбирите пункт меню");

            switch (menu.selectedMenuItem())
            {
                case 0:
                    Task_1();
                    break;
                case 1:
                    Task_2();
                    break;
                case 2:
                    Task_3();
                    break;
                case 3:
                    Exit = true;
                    break;
            }
        }

        /// <summary>
        /// Задание 1
        /// </summary>
        void Task_1()
        {
            FPController fPController = new FPController();

            fPController.show();
            Console.ReadKey();
        }

        /// <summary>
        /// Задание 2
        /// </summary>
        void Task_2()
        {
            PascalTriangle pascalTriangle = new PascalTriangle(20);

            pascalTriangle.show();
            Console.ReadKey();
        }

        /// <summary>
        /// Задание 3
        /// </summary>
        void Task_3()
        {
            string[] itensMenu = new string[] { "Умножение матрицы на число",
                                                "Сложение матриц",
                                                "Вычитание матриц",
                                                "Умножение матриц" };

            MenuController menu = new MenuController(itensMenu);
            MatrixOperations matrixOperations = new MatrixOperations();

            switch (menu.selectedMenuItem())
            {
                case 0:
                    matrixOperations.show(0);
                    Console.ReadKey();
                    break;
                case 1:
                    matrixOperations.show(1);
                    Console.ReadKey();
                    break;
                case 2:
                    matrixOperations.show(2);
                    Console.ReadKey();
                    break;
                case 3:
                    matrixOperations.show(3);
                    Console.ReadKey();
                    break;
            }
        }
    }
}
