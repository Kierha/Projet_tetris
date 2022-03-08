using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Test
{
    class Grid
    {
        public Grid(int height, int width)
        {

            this.height = height;
            this.width = width;
            grid = new int[this.height, this.width];
        }

        public int[,] grid { get; private set; }
        private int height { get; set; }
        public int width { get; private set; }

        //Intègre le tetramino dans la grille du jeu
        public void IntegrateTetramino(Tetramino tetramino, int currentY, int currentX)
        {
            for (int y = 0; y < tetramino.height; y++)
            {
                for (int x = 0; x < tetramino.width; x++)
                {
                    if (tetramino.shape[y, x] != 0)
                    {
                        grid[y + currentY, x + currentX] = tetramino.shape[y, x];
                    }
                }
            }
        }

        //Supprime le tetramino de la grille du jeu
        public void DeleteTetramino(Tetramino tetramino, int currentY, int currentX)
        {
            for (int y = 0; y < tetramino.height; y++)
            {
                for (int x = 0; x < tetramino.width; x++)
                {
                    if (tetramino.shape[y, x] != 0)
                    {
                        grid[y + currentY, x + currentX] = 0;
                    }
                }
            }
        }

        //Vérifie que les limites du tableau ne sont pas dépassées
        //Vérifie qu'il n'y a pas d'obstacles
        public bool CheckCollision(Tetramino tetramino, int nextY, int nextX)
        {
            if (nextY + tetramino.height > height || nextX < 0 || nextX + tetramino.width > width)
            {
                return true;
            }

            for (int y = nextY; y < nextY + tetramino.height; y++)
            {
                for (int x = nextX; x < nextX + tetramino.width; x++)
                {
                    if (grid[y, x] != 0 && tetramino.shape[y - nextY, x - nextX] != 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        //Retourne vrai si la ligne est remplie
        private bool CheckEmptyLine(int line)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[line, x] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        //Vide les lignes remplies
        //Fais descendre les carrés aux dessus de la vidée
        //Retourne le nombre de ligne remplie
        public int CheckAllEmptyLine()
        {
            int emptyLine = 0;

            for (int y = height - 1; y > 0; y--)
            {
                if (CheckEmptyLine(y))
                {
                    for (int x = 0; x < width; x++) { grid[y, x] = 0; }
                    emptyLine++;
                } else if(emptyLine > 0)
                {
                    for (int x = 0; x < width; x++)
                    {
                        grid[y + emptyLine, x] = grid[y, x];
                        grid[y, x] = 0;
                    }
                }
            }

            return emptyLine;
        }

    }
}
