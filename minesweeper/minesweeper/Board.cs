using System.Collections.Generic;

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
}