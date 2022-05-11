using System.Collections.Generic;
using System.Linq;
using Login.Data;
using Login.Models;

namespace Login.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly BancoContext _bancoContext;
        public PedidoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public PedidoModel ListForId(int id)
        {
            return _bancoContext.Pedido.FirstOrDefault(p => p.Id == id);
        }

        public List<PedidoModel> SearchAll()
        {
            return _bancoContext.Pedido.ToList();
        }
        public PedidoModel Adcionar(PedidoModel pedido)
        {
            _bancoContext.Pedido.Add(pedido);
            _bancoContext.SaveChanges();
            return pedido;
        }

        public PedidoModel UptadeAlter(PedidoModel pedido)
        {
            PedidoModel pedidoDB = ListForId(pedido.Id);

            if (pedidoDB == null) throw new System.Exception("Ocorreu um erro");

            pedidoDB.Name = pedido.Name;
            pedidoDB.Number = pedido.Number;
            pedidoDB.Itens = pedido.Itens;
            pedidoDB.Price = pedido.Price;

            _bancoContext.Pedido.Update(pedidoDB);
            _bancoContext.SaveChanges();

            return pedidoDB;
        }

        public bool DeleteF(int Id)
        {
            PedidoModel pedidoDB = ListForId(Id);

            if (pedidoDB == null) throw new System.Exception("Ocorreu um erro");

            _bancoContext.Pedido.Remove(pedidoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
