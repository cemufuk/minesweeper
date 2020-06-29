using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using minesweeper.Properties;

namespace minesweeper
{
    public class Board
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int CellCount { get; }

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            CellCount = width * height;
        }
    }

    class Game
    {
        public static void StartGame(Panel panel)
        {
            var board = new Board(20, 20);

            var cell = new PictureBox[board.CellCount];
            

            for (int i = 0, x = 0, y = 0; i < board.CellCount; ++i, ++x)
            {
                if (x == board.Width)
                {
                    y += 1;
                    x = 0;
                }

                cell[i] = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(x * 25, y * 25),
                    Size = new Size(25, 25),
                    Image = Resources.closed
                };

                cell[i].Show();
            }
            panel.Controls.AddRange(cell);
        }
    }
}
