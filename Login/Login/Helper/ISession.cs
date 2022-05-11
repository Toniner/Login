using Login.Models;

namespace Login.Helper
{
    public interface ISession
    {
        void CreateSessionUser(UsuarioModel usuario);
        void RemoveSessionUser();
        UsuarioModel SearchSessionUser();
    }
}
