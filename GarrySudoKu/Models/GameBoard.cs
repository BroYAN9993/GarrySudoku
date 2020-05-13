using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GarrySudoKu.Models
{
    public class GameBoard
    {
        public SelectListItem Temp { get; set; }
        public SelectList SelectList { get; set; }
        public List<Cell> CellsList { get; set; }
        public List<List<Cell>> Board { get; set; }
        public int BoardNumber { get; set; }
        public GameStatus Status { get; set; }
        public GameBoard()
        {
            CellsList = new List<Cell>();
            Board = new List<List<Cell>>();
            for (var i = 0; i < Constants.BoardSize; i++)
            {
                Board.Add(new List<Cell>());
                for (var j = 0; j < Constants.BoardSize; j++)
                {
                    Board[i].Add(null);
                }
            }
            Status = GameStatus.Normal;
            SelectList = CellSelectList();
        }
        public void Add(Cell cell)
        {
            if (cell is null) throw new ArgumentNullException(nameof(cell));
            if (cell.Value is null) throw new ArgumentNullException(nameof(cell.Value));
            if (CellsList.Where(c => (c.XCoordinate == cell.XCoordinate || c.YCoordinate == cell.YCoordinate || c.BoxIndex == cell.BoxIndex) && c.Value == cell.Value).Count() > 0) throw new ArgumentException(nameof(cell), "Illegal number");
            if (CellsList.Where(c => c.XCoordinate == cell.XCoordinate && c.YCoordinate == cell.YCoordinate).Count() > 0) throw new ArgumentException(nameof(cell), $"There is a number in [{cell.XCoordinate}, {cell.YCoordinate}]");
            Board[cell.YCoordinate - 1][cell.XCoordinate - 1] = cell;
            CellsList.Add(cell);
        }
        private SelectList CellSelectList()
        {
            var nums = new List<int>();
            for (var i = 1; i <= Constants.BoardSize; i++) nums.Add(i);
            var selectList = nums.Select(n => new SelectListItem { Value = n.ToString(), Text = n.ToString() });
            return new SelectList(selectList, "Value", "Text");
        }
    }
}
