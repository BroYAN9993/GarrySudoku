using System;
using System.ComponentModel.DataAnnotations;

namespace GarrySudoKu.Models
{
    public class Cell
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int BoxIndex { get; set; }
        [Range(1, Constants.BoardSize, ErrorMessage = Constants.IllegalMessage)]
        public int? Value { get; set; }
        public Cell()
        {
            Value = null;
        }
    }
}
