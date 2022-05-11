using System.Collections.Generic;
using Login.Models;

namespace Login.Repository
{
    public interface IPedidoRepository
    {
        PedidoModel ListForId(int id);
        List<PedidoModel> SearchAll();
        PedidoModel Adcionar(PedidoModel pedido);

        PedidoModel UptadeAlter(PedidoModel pedido);

        bool DeleteF(int Id);
    }
}
