﻿using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Login do usuario!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuario!")]
        public string Password { get; set; }

    }
}
