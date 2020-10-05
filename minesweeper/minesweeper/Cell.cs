using System.Drawing;
using System.Windows.Forms;

namespace minesweeper
{
    public class Cell
    {
        public int Id { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public PictureBox Picturebox { get; set; }
        public bool IsOpened { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsBomb { get; set; }
        public int MinesAround { get; set; }

        public Cell(int id, int x, int y)
        {
            Id = id;
            XCoordinate = x;
            YCoordinate = y;
        }

        public Cell(){}

    }
}