using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using minesweeper.Properties;

namespace minesweeper
{
    public class Board
    {
        public Board(int width, int height, int mineCount)
        {
            Width = width;
            Height = height;
            MineCount = mineCount;
            CellCount = width * height;
            Cells = new List<Cell>();

            for (int i = 0, id = 0; i < height; ++i)
            {
                for (var j = 0; j < width; ++j)
                {
                    Cells.Add(new Cell(id,j,i));
                    ++id;
                }
            }
        }

        public int Width { get; }
        public int Height { get; }
        public int MineCount { get; }
        public int CellCount { get; }
        public List<Cell> Cells { get; set; }
    }

    public class Cell
    {
        public int Id { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public bool IsOpened { get; set; }
        public bool IsFlagged { get; set; }

        public Cell(int id, int x, int y)
        {
            Id = id;
            XCoordinate = x;
            YCoordinate = y;
        }


    }

    internal class Game
    {
        public static void StartGame(Panel panel)
        {
            var board = new Board(16, 16,32);
            var cells = board.Cells;

            foreach(var cell in cells)
            {
                //TODO : set images and click events to cells
            }
            /*
            var cellCount = board.CellCount;
            var cell = new PictureBox[cellCount];


            for (int i = 0, x = 0, y = 0; i < cellCount; ++i, ++x)
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
            */
        }
    }
}