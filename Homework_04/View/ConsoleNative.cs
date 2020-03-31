using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Homework_04.View
{
    static class ConsoleNative
    {
        //получение состояния всех клавиш, включая служебные и мышь
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetKeyboardState(byte[] lpKeyState);

        //сюда будем писать состояния клавиш
        private static byte[] keys = new byte[256];

        //получение состояния указанной клавиши
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetKeyState(int key);

        /// <summary>
        /// Проверка на нажатость клавиши
        /// </summary>        
        public static bool IsAnyKeyPressed()
        {            
            GetKeyState(0);

            if (!GetKeyboardState(keys))
            {                
                int err = Marshal.GetLastWin32Error();
                throw new Win32Exception(err);
            }
            //каждый байт - это состояние одной из клавиш
            for (int i = 0; i < 256; i++)
            {
                if (i < 7)
                {
                    //байты с 0 по 6 отвечают за клавиши мыши, проигнорируем их
                    keys[i] = 0;
                }
                else
                {
                    //за состояние "нажатости" отвечает старший бит, остальное просто зануляем
                    keys[i] = (byte)(keys[i] & 0x80);
                }
            }

            return keys.Any(k => k != 0);
        }

        /// <summary>
        /// Клавиша нажата
        /// </summary> 
        public static void WaitForKeyDown()
        {
            bool isAnyKeyPressed;
            do
            {
                isAnyKeyPressed = IsAnyKeyPressed();
            }
            while (!isAnyKeyPressed);
        }

        /// <summary>
        /// Клавиша отпущена
        /// </summary>
        public static void WaitForKeyUp()
        {
            bool isAnyKeyPressed;
            do
            {
                isAnyKeyPressed = IsAnyKeyPressed();
            }
            while (isAnyKeyPressed);
        }
        
        /// <summary>
        /// Очистка входного потока от нажатых клавиш
        /// </summary>
        public static void FlushInputStream()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }                
        }
    }
}

