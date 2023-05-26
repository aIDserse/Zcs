using System.ComponentModel.DataAnnotations;

namespace Zap.Models
{
    public class HappeningHandler
    {
        [Required(ErrorMessage = "Dato obbligatorio!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Dato Obbligatorio!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Dato Obbligatorio!")]
        [StringLength(100, MinimumLength = 6)]
        public string Email { get; set; }
        public int MuseumID { get; set; }
        [Required(ErrorMessage = "Dato Obbligatorio!")]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Dato obbligatorio!")]
        [Compare(nameof(Password))]
        public string ConfermaPassword { get; set; }
    }
}
