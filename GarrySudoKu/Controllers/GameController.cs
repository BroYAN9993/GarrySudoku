using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarrySudoKu.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GarrySudoKu.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IActionResult Game()
        {
            var board = new GameBoard();
            for (var i = 1; i <= Constants.BoardSize; i++)
            {
                var cell = new Cell { XCoordinate = i, YCoordinate = i, BoxIndex = (i - 1) / 3 * 3 + (i - 1) / 3 + 1, Value = i };
                board.Add(cell);
            }
            return View(board);
        }
    }
}
