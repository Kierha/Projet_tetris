using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Test
{
    public class BlockColor
    {
        public SolidBrush BackgroundBlock(int ColorChoice)
        {
            switch (ColorChoice)
            {
                case 1:
                    return new SolidBrush(System.Drawing.Color.Cyan);
                case 2:
                    return new SolidBrush(System.Drawing.Color.Yellow);
                case 3:
                    return new SolidBrush(System.Drawing.Color.Purple) ;
                case 4:
                    return new SolidBrush(System.Drawing.Color.Orange);
                case 5:
                    return new SolidBrush(System.Drawing.Color.Blue);
                case 6:
                    return new SolidBrush(System.Drawing.Color.Red);
                case 7:
                    return new SolidBrush(System.Drawing.Color.Green);
                default:
                    return new SolidBrush(System.Drawing.Color.White);
            }
        }
    }
}
