using System;
using Login.Helper;
using Login.Models;
using Login.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISession _session;
        public LoginController(IUsuarioRepository usuarioRepository, ISession session)
        {
            _usuarioRepository = usuarioRepository;
            _session = session;
        }

        public IActionResult Index()
        {
            if(_session.SearchSessionUser() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Logout()
        {
            _session.RemoveSessionUser();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepository.SeachForLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.PassValid(loginModel.Password))
                        {
                            _session.CreateSessionUser(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MessageErro"] = "Senha invalida. Por favor, tente novamente";
                    }
                    TempData["MessageErro"] = "Usuario e/ou senha invalido(s). Por favor, tente novamente";
                }
                return View("Index");
            }

            catch (Exception erro)
            {

                TempData["MessageErro"] = $"Não conseguimos realizar seu login, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
