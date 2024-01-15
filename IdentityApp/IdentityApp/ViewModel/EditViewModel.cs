﻿using System.ComponentModel.DataAnnotations;

namespace IdentityApp.ViewModel
{
    public class EditViewModel
    {

        public string? Id { get; set; }

        public string? FullName { get; set; }
        
        [EmailAddress]
        public string? Email { get; set; } 

       
        [DataType(DataType.Password)]
        public string? Password { get; set; } 

        
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Parola Eşleşmiyor")]
        public string? ConfirmPassword { get; set; }

    }
}
