using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToe.Models
{
    public class Game
    {
        [Key]
        public int GameID { get; set; }

        public DateTime GameDate { get; set; }

        public int GameXPoints { get; set; } = 0;

        public int GameYPoints { get; set; } = 0;

        // Navigation Property
        public ICollection<PlayerGame> PlayerGames { get; set; } = new List<PlayerGame>();
    }
}
