using System.ComponentModel.DataAnnotations;

namespace ArithmeticGame.ViewModels
{
    public class AddGameMenuViewModel
    {
        [Required]
        [Display(Name = "Game Menu Name")]
        public string Name { get; set; }
    }
}
