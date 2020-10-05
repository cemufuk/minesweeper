using minesweeper.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace minesweeper
{
    internal class Game
    {
        public static bool GameStarted = false;

        public static void StartGame(Panel panel)
        {
            var board = new Board(10, 10, 10);
            var cellCount = board.CellCount;

            var cells = board.Cells;

            // Create all cells and set images
            for (int i = 0, x = 0, y = 0; i < cellCount; ++i, ++x)
            {
                if (x == board.Width)
                {
                    y += 1;
                    x = 0;
                }

                var cellPictureBox = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(x * 25, y * 25),
                    Size = new Size(25, 25),
                    Image = Resources.closed
                };

                panel.Controls.Add(cellPictureBox);
                cells[i].Picturebox = cellPictureBox;
                cells[i].IsBomb = false;
                cells[i].IsFlagged = false;
                cells[i].IsOpened = false;
                var i1 = i;
                var x1 = x;
                var y1 = y;
                cells[i].Picturebox.Click += (s, e) => { CellClick(board, cells, i1); };
            }
        }

        private static void GetCellMines(List<Cell> cells, Board board)
        {
            foreach (var cell in cells)
            {
                var list = CellsAround(cell, board);
                var mineCount = CheckMines(cells, list);
                cell.MinesAround = mineCount;
            }
        }


        private static void CellClick(Board board, List<Cell> cells, int i)
        {
            // Set mines if this is the first cell click
            if (!GameStarted)
            {
                // set mines to random cells but exclude this clicked cell
                SetMines(board.MineCount, cells, i);
                GetCellMines(cells, board);
                GameStarted = true;
            }

            //cells[i].IsOpened = true;

            if (cells[i].IsBomb)
            {
                foreach (var cell in cells)
                {
                    if (cell.IsBomb == true)
                        cell.Picturebox.Image = Resources.bomb;
                }

                MessageBox.Show("You Lost!");
                // GameStarted = false;
                return;
            }

            SetImages(cells[i]);
            
            var list = CellsAround(cells[i], board);
            OpenEmptyCells(cells, cells[i], list, board);

        }

        private static void OpenEmptyCells(List<Cell> cells, Cell cell, List<int> idList, Board board)
        {
            if (cell.IsOpened == false && cell.MinesAround == 0)
            {
                cell.IsOpened = true;
                foreach (var id in idList)
                {
                    //cells[id].IsOpened = true;
                    SetImages(cells[id]);
                    var _idList = CellsAround(cells[id], board);
                    OpenEmptyCells(cells, cells[id], _idList, board);
                }

            }
                
        }

        private static int CheckMines(List<Cell> cells, List<int> idList)
        {
            var mineCount = 0;
            foreach (var id in idList)
            {
                if (cells[id].IsBomb == true)
                {
                    mineCount++;
                }
            }

            return mineCount;
        }
        private static List<int> CellsAround(Cell cell, Board board)
        {
            var xCoor = cell.XCoordinate;
            var yCoor = cell.YCoordinate;
            var idList = new List<int>();

            for (var _i = yCoor - 1; _i <= yCoor + 1; ++_i)
            for (var _j = xCoor - 1; _j <= xCoor + 1; ++_j)
            {
                if (_i >= 0 && _j >= 0 && _i < board.Width && _j < board.Height)
                {
                    if (_i != yCoor || _j != xCoor)
                    {
                        var id = _i * board.Width + _j;
                        idList.Add(id);
                    }
                }
            }

            return idList;
        }
        private static void SetImages(Cell cell)
        {
            switch (cell.MinesAround)
            {
                case 0:
                    cell.Picturebox.Image = Resources._0;
                    break;
                case 1:
                    cell.Picturebox.Image = Resources._1;
                    break;
                case 2:
                    cell.Picturebox.Image = Resources._2;
                    break;
                case 3:
                    cell.Picturebox.Image = Resources._3;
                    break;
                case 4:
                    cell.Picturebox.Image = Resources._4;
                    break;
                case 5:
                    cell.Picturebox.Image = Resources._5;
                    break;
                case 6:
                    cell.Picturebox.Image = Resources._6;
                    break;
                case 7:
                    cell.Picturebox.Image = Resources._7;
                    break;
                case 8:
                    cell.Picturebox.Image = Resources._8;
                    break;
            }
        } 
        private static void SetMines(int mineCount, List <Cell> cells, int exclude)
        {
            var list = new List<Cell>(cells);
            var rnd = new Random();

            // Remove the first clicked cell from the list to avoid being marked as possible mine field
            list.RemoveAt(exclude);

            for (var i = 0; i < mineCount; ++i)
            {
                var index = rnd.Next(list.Count);
                list[index].IsBomb = true;
                list.RemoveAt(index);
            }
        }
    }
}