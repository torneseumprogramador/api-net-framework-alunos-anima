using joao_felipe_juliano_framework_api.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection.Emit;

namespace joao_felipe_juliano_framework_api.Controllers
{
    public class MeuContexto : DbContext
    {
        public MeuContexto() : base("name=DefaultConnection")
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        // Outras definições de entidades...

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configurações de entidades, chaves primárias, relações, etc.
        }
    }
}