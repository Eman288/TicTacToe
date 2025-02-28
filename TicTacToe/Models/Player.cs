using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Models
{
    public class Player
    {
        [Required]
        [Key]
        
        public int PlayerID { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, ErrorMessage = "Name can't be more than 50 characters")]
        public string PlayerName { get; set; } = "";

        [Required(ErrorMessage = "Email is Required")]
        [StringLength(100, ErrorMessage = "Email can't be more than 50 characters")]
        public string PlayerEmail { get; set; } = "";

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at lease 8 charcaters")]
        public string PlayerPassword { get; set; } = "";
    
        public DateTime PlayerJoinDate { get; set; }

        public int PlayerTotalPlays { get; set; } = 0;

        public string Picture { get; set; } = "";

        // relations

        public ICollection<PlayerGame> PlayerGames { get; set; } = null;
    }
}
