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
    public class PlayerController : Controller
    {
        private readonly TicTacToeDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public PlayerController(TicTacToeDbContext _db, IWebHostEnvironment _webHostEnvironment)
        {
            this._db = _db;
            this._webHostEnvironment = _webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new Player());
        }

        [HttpPost]
        public async Task<IActionResult> Register(Player p, IFormCollection f)
        {
            if (p == null)
            {
                return View("Register");
            }

            Player newPlayer = new Player();
            newPlayer.PlayerName = p.PlayerName;
            newPlayer.PlayerEmail = p.PlayerEmail;
            newPlayer.PlayerPassword = p.PlayerPassword;
            newPlayer.PlayerJoinDate = DateTime.Now;


            _db.Players.Add(newPlayer);
            await _db.SaveChangesAsync();
            
            return View("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new Player());
        }

        [HttpPost]
        public async Task<IActionResult> Login(Player p)
        {
            Player? player = await _db.Players.Where(a => a.PlayerEmail == p.PlayerEmail).FirstOrDefaultAsync();
            if (player == null)
            {
                // there is no user with this email

                return View("Login");
            }
            if (player.PlayerPassword == p.PlayerPassword)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // the password is wrong
                return View("Login");
            }
        }
    }
}
