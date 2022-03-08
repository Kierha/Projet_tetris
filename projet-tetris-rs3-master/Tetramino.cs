using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Test
{
    class Tetramino
    {
        public Tetramino()
        {
            Random rnd = new Random();
            int shapeChoice = rnd.Next(7) + 1;

            switch (shapeChoice)
            {
                //I-Tetramino
                case 1:
                    Shape = new int[,] { { 1, 1, 1, 1 } };
                    break;
                //O-Tetramino
                case 2:
                    Shape = new int[,] { { 1, 1 }, { 1, 1 } };
                    break;
                //T-Tetramino
                case 3:
                    Shape = new int[,] { { 1, 1, 1 }, { 0, 1, 0 } };
                    break;
                //L-Tetramino
                case 4:
                    Shape = new int[,] { { 1, 1, 1 }, { 1, 0, 0 } };
                    break;
                //J-Tetramino
                case 5:
                    Shape = new int[,] { { 1, 1, 1 }, { 0, 0, 1 } };
                    break;
                //Z-Tetramino
                case 6:
                    Shape = new int[,] { { 1, 1, 0 }, { 0, 1, 1 } };
                    break;
                //S-Tetramino
                case 7:
                    Shape = new int[,] { { 0, 1, 1 }, { 1, 1, 0 } };
                    break;
            }
        }
        public int[,] Shape { get; set; }
        public int Height => Shape.GetLength(0);
        public int Width => Shape.GetLength(1);

        public void getRotate()
        {
            int[,] newShape = new int[Width, Height];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    newShape[x, Height - y - 1] = Shape[y, x];
                }
            }
            Shape = newShape;
        }

        /*public void PrintTetra()
        {
            Console.WriteLine("--------");
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.Write(Shape[y, x]);
                }
                Console.Write("\n");
            }
        }*/
    }
}