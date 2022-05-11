using System;
using System.Collections.Generic;
using System.Linq;
using Login.Data;
using Login.Models;

namespace Login.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public UsuarioModel SeachForLogin(string login)
        {
            return _bancoContext.Usuario.FirstOrDefault(p => p.Login.ToUpper() == login.ToUpper());
        }
        public UsuarioModel ListForId(int id)
        {
            return _bancoContext.Usuario.FirstOrDefault(p => p.Id == id);
        }

        public List<UsuarioModel> SearchAll()
        {
            return _bancoContext.Usuario.ToList();
        }
        public UsuarioModel Adcionar(UsuarioModel usuario)
        {
            usuario.DateNew = DateTime.Now;
            _bancoContext.Usuario.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel UptadeAlter(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListForId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Ocorreu um erro");

            usuarioDB.Name = usuario.Name;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.DateAlter = DateTime.Now;
            usuarioDB.Perfil = usuario.Perfil;


            _bancoContext.Usuario.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public bool DeleteF(int Id)
        {
            UsuarioModel  usuarioDB = ListForId(Id);

            if (usuarioDB == null) throw new System.Exception("Ocorreu um erro");

            _bancoContext.Usuario.Remove(usuarioDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
