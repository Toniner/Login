using System.Collections.Generic;
using Login.Models;
using Login.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public IActionResult Index()
        {   
            List<PedidoModel> pedidos = _pedidoRepository.SearchAll();
            return View(pedidos);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            PedidoModel pedido = _pedidoRepository.ListForId(id);
            return View(pedido);
        }

        public IActionResult Delete(int id)
        {
            PedidoModel pedido = _pedidoRepository.ListForId(id);
            return View(pedido);
        }

        [HttpGet]
        public IActionResult DeleteForId(int id)
        {
            try
            {
                bool trueDelete = _pedidoRepository.DeleteF(id);

                if (trueDelete)
                {
                    TempData["MessageSuccess"] = "Pedido apagado com sucesso";
                }
                else
                {
                    TempData["MessageErro"] = "Pedido não foi apagado";
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
        public IActionResult Create(PedidoModel pedido)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pedidoRepository.Adcionar(pedido);
                    TempData["MessageSuccess"] = "Pedido cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(pedido);
            }
            catch (System.Exception erro)
            {
                TempData["MessageErro"] = $"Pedido não foi cadastrado, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alter(PedidoModel pedido)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pedidoRepository.UptadeAlter(pedido);
                    TempData["MessageSuccess"] = "Pedido alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Edit", pedido);
            }
            catch (System.Exception erro)
            {
                TempData["MessageErro"] = $"Pedido não foi alterado, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
