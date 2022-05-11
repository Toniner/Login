using Login.Models;
using Microsoft.EntityFrameworkCore;

namespace Login.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<PedidoModel> Pedido { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
    }
}
