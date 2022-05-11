using System;
using System.ComponentModel.DataAnnotations;
using Login.Enums;

namespace Login.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuario!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o login do usuario!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o Email do usuario!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Perfil do usuario!")]
        public PerfilEnum? Perfil { get; set; }
    }
}
