using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Test
{
    public abstract class Tetramino
    {

        public int id { get; protected set; }
        public int[,] shape { get; set; }
        public int height => shape.GetLength(0);
        public int width => shape.GetLength(1);

        //Rotate le tetramino
        public void GetRotate()
        {
            int[,] newShape = new int[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    newShape[x, height - y - 1] = shape[y, x];
                }
            }

            shape = newShape;
        }
    }

    public class I_Tetramino : Tetramino
    {
        public I_Tetramino()
        {
            shape = new int[,] { { 1, 1, 1, 1 } };
            id = 1;
        }
    }

    public class O_Tetramino : Tetramino
    {
        public O_Tetramino()
        {
            shape = new int[,] { { 2, 2 }, { 2, 2 } };
            id = 2;
        }
    }

    public class T_Tetramino : Tetramino
    {
        public T_Tetramino()
        {
            shape = new int[,] { { 3, 3, 3 }, { 0, 3, 0 } };
            id = 3;
        }
    }

    public class L_Tetramino : Tetramino
    {
        public L_Tetramino()
        {
            shape = new int[,] { { 4, 4, 4 }, { 4, 0, 0 } };
            id = 4;
        }
    }

    public class J_Tetramino : Tetramino
    {
        public J_Tetramino()
        {
            shape = new int[,] { { 5, 5, 5 }, { 0, 0, 5 } };
            id = 5;
        }
    }

    public class Z_Tetramino : Tetramino
    {
        public Z_Tetramino()
        {
            shape = new int[,] { { 6, 6, 0 }, { 0, 6, 6 } };
            id = 6;
        }
    }

    public class S_Tetramino : Tetramino
    {
        public S_Tetramino()
        {
            shape = new int[,] { { 0, 7, 7 }, { 7, 7, 0 } };
            id = 7;
        }
    }
}
