using System.Collections.Generic;
using Login.Models;

namespace Login.Repository
{
    public interface IUsuarioRepository
    {
        UsuarioModel SeachForLogin(string login);
        UsuarioModel ListForId(int id);
        List<UsuarioModel> SearchAll();
        UsuarioModel Adcionar(UsuarioModel usuario);

        UsuarioModel UptadeAlter(UsuarioModel usuario);

        bool DeleteF(int Id);
    }
}
