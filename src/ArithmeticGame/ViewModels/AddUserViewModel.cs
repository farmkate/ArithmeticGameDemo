using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using ArithmeticGame.Models;

namespace ArithmeticGame.ViewModels
{
    public class AddUserViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Required]
        [Compare("Verify")]
        [MinLength(6, ErrorMessage = "Your password must be at least 6 characters in length")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Verify Password")]
        public string Verify { get; set; }

        [Required(ErrorMessage = "You must enter a username")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }


        public List<SelectListItem> Categories { get; set; }

        public AddUserViewModel()
        { }

        public AddUserViewModel(IEnumerable<UserCategory> categories)
        {

            Categories = new List<SelectListItem>();

            foreach (UserCategory category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = (category.ID.ToString()),
                    Text = category.Name.ToString()
                });
            }

        }

    }
}
