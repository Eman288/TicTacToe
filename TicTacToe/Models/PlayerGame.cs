using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToe.Models
{
    public class PlayerGame
    {
        [Required]
        public int PlayerID { get; set; }  // Foreign Key

        [Required]
        public int GameID { get; set; }  // Foreign Key

        public char PlayerChar { get; set; } = 'X';

        // Navigation Properties
        public Player Player { get; set; }
        public Game Game { get; set; }
    }
}
