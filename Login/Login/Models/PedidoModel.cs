using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class PedidoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o nome do cliente!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o numero do Pedido!")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Digite os itens do pedido!")]
        public string Itens { get; set; }
        [Required(ErrorMessage = "Digite o valor do pedido!")]
        public string Price { get; set; }
    }
}
