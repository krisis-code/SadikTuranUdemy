﻿using System.ComponentModel.DataAnnotations;

namespace ProductsApi.DTO
{
    public class lOGİNDTO
    {
        

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
