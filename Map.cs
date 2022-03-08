using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Test
{
    class Map
    {
        private int[,] map { get; set; } = new int[20, 10];
        private int currentY { get; set; }
        private int currentX { get; set; }
        private Tetramino tetramino;
        
        //Ajoute un tetramino à la dans la classe map
        //Défini les positions de base du tetramino
        public void addTetramino()
        {
            tetramino = new Tetramino();
            currentX = 5 - tetramino.Width / 2 - tetramino.Width % 2;
            currentY = 0;
            integrateTetramino();
        }


        private void integrateTetramino()
        {
            for (int y = 0; y < tetramino.Height; y++)
            {
                for (int x = 0; x < tetramino.Width; x++)
                {
                    if (tetramino.Shape[y, x] != 0)
                    {
                        map[y + currentY, x + currentX] = tetramino.Shape[y, x];
                    }
                }
            }
        }

        private bool checkCollision()
        {
            int nextY = currentY + 1;
            if (nextY + tetramino.Height > 20)
            {
                return false;
            }
            for (int x = 0; x < tetramino.Width; x++)
            {
                if (tetramino.Shape[tetramino.Height - 1, x] != 0 && map[nextY + tetramino.Height - 1, x + currentX] != 0)
                {
                    Console.WriteLine("false");
                    return false;
                }
            }
            return true;
        }

        public void refreshMap()
        {
            if (checkCollision())
            {
                for (int y = 0; y < tetramino.Height; y++)
                {
                    for (int x = 0; x < tetramino.Width; x++)
                    {
                        if (tetramino.Shape[y, x] != 0) { map[y + currentY, x + currentX] = 0; }
                    }
                }
                currentY += 1;
                integrateTetramino();
            }
            else
            {
                addTetramino();
            }
        }
        public void PrintMap()
        {
            Console.WriteLine("--------");
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Console.Write(map[y, x]);
                }
                Console.Write("\n");
            }
        }

        public Map()
        {

        }
    }
}