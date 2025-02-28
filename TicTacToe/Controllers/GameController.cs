using Microsoft.AspNetCore.Mvc;
using TicTacToe.Models;
using TicTacToe.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure;

namespace TicTacToe.Controllers
{
    public class GameController : Controller
    {

        private readonly TicTacToeDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GameController(TicTacToeDbContext _db, IWebHostEnvironment _webHostEnvironment)
        {
            this._db = _db;
            this._webHostEnvironment = _webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Game(int mode) // 1 => single, 2 => two players
        {
            ViewData["mode"] = mode;
            return View();
        }
    }
}
