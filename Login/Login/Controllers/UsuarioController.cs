using System.Collections.Generic;
using Login.Models;
using Login.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepository.SearchAll();
            return View(usuarios);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            UsuarioModel usuario = _usuarioRepository.ListForId(id);
            return View(usuario);
        }

        public IActionResult Delete(int id)
        {
            UsuarioModel usuario = _usuarioRepository.ListForId(id);
            return View(usuario);
        }

        [HttpGet]
        public IActionResult DeleteForId(int id)
        {
            try
            {
                bool trueDelete = _usuarioRepository.DeleteF(id);

                if (trueDelete)
                {
                    TempData["MessageSuccess"] = "Usuario apagado com sucesso";
                }
                else
                {
                    TempData["MessageErro"] = "Usuario não foi apagado";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MessageErro"] = $"Pedido não foi apagado, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Create(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.Adcionar(usuario);
                    TempData["MessageSuccess"] = "Usuario cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MessageErro"] = $"Pedido não foi cadastrado, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public IActionResult Edit(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Name = usuarioSemSenhaModel.Name,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil
                    };

                    usuario = _usuarioRepository.UptadeAlter(usuario);
                    TempData["MessageSuccess"] = "Usuario alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Edit", usuarioSemSenhaModel);
            }
            catch (System.Exception erro)
            {
                TempData["MessageErro"] = $"Pedido não foi alterado, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
