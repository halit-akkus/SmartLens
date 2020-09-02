using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SmartLens.Transmission
{
   public class ConsoleEffect
    {
        private static ConsoleColor[] _colors = { ConsoleColor.DarkYellow, ConsoleColor.Gray, ConsoleColor.DarkGreen, ConsoleColor.DarkRed, ConsoleColor.DarkCyan };
        private static Random _rnd = new Random();
        public ConsoleEffect()
        {
            Console.WindowHeight = (Console.LargestWindowHeight * 9 / 10);
           
        }
        public static void SetColor(ConsoleColor fore)
        {
            Console.ForegroundColor = fore;
        }
        public static void SetColor()
        {
            Console.ForegroundColor = _colors[_rnd.Next(0, _colors.Length)];
        }
        public static void ClearCurrent(int size)
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(size, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(size, currentLineCursor);
        }
        public static void Effect(object length)
        {
            string[] result = { "", ".", "..", "...", "", ".", " .", "  ." };
            Thread.Sleep(2000);
            while (true)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Console.Write(result[i]);
                    Thread.Sleep(450);
                    ClearCurrent((int)length);
                }
            }
        }
    }
}
