using System;
using Login.Enum;

namespace Login.Models
{
    public class userModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public PerfilEnum Perfil { get; set; }
        public DateTime DateNew { get; set; }
        public DateTime? DateAlter { get; set; }

    }
}
