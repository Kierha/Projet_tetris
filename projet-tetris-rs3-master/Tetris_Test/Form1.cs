
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris_Test
{
    public partial class Form1 : Form
    {
        private int currentTime = 0;

        private int width = 20, height = 23;

        private int nextBlockW = 20, nextBlockH = 20;

        int[,] grid;
        int[,] gridNextBlock;
        Bitmap draw;
        Graphics canvas;
        GameManager game;

        Bitmap draw2;
        Graphics canvas2;
      

        public Form1()
        {
            game = new GameManager(new Grid(height, width));
            InitializeComponent();
            _ = Start();
        }

     

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    game.delay = 500;
                    break;
                default:
                    return;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    game.MoveTetramino(-1);
                    break;
                case Keys.Right:
                    game.MoveTetramino(1);
                    break;
                case Keys.Up:
                    game.RotateTetramino();
                    break;
                case Keys.Down:
                    game.delay = 50;
                    break;
                default:
                    return;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            UCoption uo = new UCoption();
            MainControlClass.showControl(uo, pictureBox1);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!game.isOver)
            {
                currentTime++; // currentTime = currentTime + 1
                this.label1.Text = currentTime.ToString();
            }
        }

    public async Task Start()
        {
            BlockColor blockColor = new BlockColor();
            grid = new int[width, height];
            draw = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            canvas = Graphics.FromImage(draw);

            gridNextBlock = new int[nextBlockW, nextBlockH];
            draw2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            canvas2 = Graphics.FromImage(draw2);

            while (!game.isOver)
            {
                canvas.Clear(Color.White);
                canvas2.Clear(Color.White);
                // Affichage CurrentBlock
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (game.getMap()[y, x] != 0)
                        { 
                            Rectangle blockSize = new Rectangle(x * width, y * height, width, height);
                            canvas.FillRectangle(blockColor.BackgroundBlock(game.getMap()[y, x]), blockSize);
                            canvas.DrawRectangle(Pens.Black, blockSize);
                        }
                    }
                }
                pictureBox1.Image = draw;
                
                // Affichage nextBlock
                for (int y = 0; y < game.getNextTetramino().GetLength(0); y++)
                {
                    for (int x = 0; x < game.getNextTetramino().GetLength(1); x++)
                    {
                        if (game.getNextTetramino()[y, x] != 0)
                        {
                            Rectangle blockSize = new Rectangle((int)((x + 1.5) * nextBlockW), (y+2) * nextBlockH, nextBlockW, nextBlockH);
                            canvas2.FillRectangle(blockColor.BackgroundBlock(game.getNextTetramino()[y, x]), blockSize);
                            canvas2.DrawRectangle(Pens.Black, blockSize);
                        }
                    }
                }
                // Si y'a des lignes détruites --> Récupère --> Variable Score --> Display Scoring 
                pictureBox2.Image = draw2;
                // pictureBox2.Image = ... ;
                this.label2.Text = game.score.ToString();
                await game.manageGame();
            }
            //fonction gameOver
            UCoption uo = new UCoption();
            MainControlClass.showControl(uo, pictureBox1);
        }
    }
}