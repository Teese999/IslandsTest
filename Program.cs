using System;
using System.Collections.Generic;
using System.Linq;

namespace Islands
{
    public class Program
    {
        public static List<int> Areas = new();
        public static int HorizontalSize = 0;
        public static int VerticalSize = 0;
        static void Main()
        {
            int[,] map1 = {
                { 1, 0, 0, 0 },
                { 1, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            };
            int[,] map2 = {
                { 0, 0, 0, 1, 1, 1 },
                { 0, 0, 0, 0, 1, 1 },
                { 0, 0, 1, 1, 0, 0 },
                { 1, 1, 0, 0, 0, 0 },
                { 0, 1, 1, 1, 0, 0 },
                { 0, 0, 0, 1, 0, 0 }
            };

            start(map1);


            Console.WriteLine($"Количество островов - {Areas.Count}");
            Console.WriteLine("ПЛощади островов:");
            foreach (var item in Areas)
            {
                Console.WriteLine(item);
            }


            void start(int[,] Map)
            {
                VerticalSize = Map.GetLength(0);
                HorizontalSize = Map.Length / VerticalSize;
                for (int h = 0; h < HorizontalSize; h++)
                {
                    for (int v = 0; v < VerticalSize; v++)
                    {
                        if (Map[h, v] == 1)
                        {
                            Areas.Add(0);
                            IslandChecker(Map, h, v);
                        }
                    }
                }

            }

        }
        static bool IslandChecker(int[,] Map, int Hor, int Vert)
        {

            if ((Hor < 0) || (Hor >= HorizontalSize)) return false;
            if ((Vert < 0) || (Vert >=VerticalSize)) return false;

            bool IsIsland = Map[Hor, Vert] == 1;

            Map[Hor, Vert] = 0;

            if (IsIsland)
            {
                IslandChecker(Map, Hor, Vert + 1);
                IslandChecker(Map, Hor, Vert - 1);
                IslandChecker(Map, Hor + 1, Vert);
                IslandChecker(Map, Hor - 1, Vert);
                Areas[^1]++;
            }

            return IsIsland;
        }
    } 
}
