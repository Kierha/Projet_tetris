using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Test
{
    class GameManager
    {
        public GameManager(Grid map)
        {
            this.currentGrid = map;
            currentTetramino = CreateTetramino();
            nextTetramino = CreateTetramino();
            currentY = 0;
            currentX = spawnX;
            delay = 500;
            score = 0;
            isOver = false;
            map.IntegrateTetramino(currentTetramino, currentY, currentX);
        }

        private Grid currentGrid;
        private Tetramino currentTetramino;
        private Tetramino nextTetramino;

        private int spawnX => this.currentGrid.width / 2 - currentTetramino.width / 2 - currentTetramino.width % 2;
        private int currentY { get; set; }
        private int currentX { get; set; }
        public int delay { private get; set; }
        public int score { get; set; }
        public bool isOver { get; private set; }

        //Si shapeChoice est null, il va sortir un chiffre aléatoire
        //Retourne un tétramino différent en fonction de la valeur de shapeChoice
        private Tetramino CreateTetramino(int? shapeChoice = null)
        {
            var rand = new Random();

            do
            {
                shapeChoice = rand.Next(7) + 1;
            } while (shapeChoice == null || currentTetramino != null && shapeChoice == currentTetramino.id);

            switch (shapeChoice) {
                case 1:
                    return new I_Tetramino();
                case 2:
                    return new O_Tetramino();
                case 3:
                    return new T_Tetramino();
                case 4:
                    return new L_Tetramino();
                case 5:
                    return new J_Tetramino();
                case 6:
                    return new Z_Tetramino();
                case 7:
                    return new S_Tetramino();
                default:
                    return new I_Tetramino();
            }
        }

        //Remplace le tetramino en cours par le prochain et le positionne au spawn
        //Crée le tetramino suivant
        private void ChangeTetramino()
        {
            currentTetramino = nextTetramino;
            nextTetramino = CreateTetramino();
            currentY = 0;
            currentX = spawnX;
            if (currentGrid.CheckCollision(currentTetramino, currentY, currentX)) { isOver = true; }
        }

        //Déplace le tétramino de gauche à droite si il n'y a pas d'obstacles
        public void MoveTetramino(int direction)
        {
            currentGrid.DeleteTetramino(currentTetramino, currentY, currentX);
            if (!currentGrid.CheckCollision(currentTetramino, currentY, currentX + direction)) { currentX += direction; }
            currentGrid.IntegrateTetramino(currentTetramino, currentY, currentX);
        }

        //Vérifie qu'il n'y ai pas d'obstacles pour la rotation
        //Si il y en a pas, il effectue la rotation sur le tetramino en cours
        public void RotateTetramino()
        {
            Tetramino nextRotate = CreateTetramino(currentTetramino.id);
            
            nextRotate.shape = currentTetramino.shape;
            nextRotate.GetRotate();

            currentGrid.DeleteTetramino(currentTetramino, currentY, currentX);
            if (!currentGrid.CheckCollision(nextRotate, currentY, currentX)) { currentTetramino.GetRotate(); }
            currentGrid.IntegrateTetramino(currentTetramino, currentY, currentX);
        }
        
        //Coeur du manageur
        //Si il n'y a pas d'obstacles le tetramino tombe
        //Sinon il regarde le nombre de lignes remplies pour modifier le score
        //Et passe au prochain tetramino
        public async Task manageGame()
        {
            currentGrid.DeleteTetramino(currentTetramino, currentY, currentX);
            if (!currentGrid.CheckCollision(currentTetramino, currentY + 1, currentX))
            {
                currentY += 1;
                currentGrid.IntegrateTetramino(currentTetramino, currentY, currentX);
            }
            else
            {
                currentGrid.IntegrateTetramino(currentTetramino, currentY, currentX);
                score += currentGrid.CheckAllEmptyLine() * 100;
                ChangeTetramino();
            }
            await Task.Delay(delay);
        }

        //Retourne la grille
        public int[,] getMap()
        {
            return currentGrid.grid;
        }

        //Retourne la forme du prochain tetramino
        public int[,] getNextTetramino()
        {
            return nextTetramino.shape;
        }

    }
}
