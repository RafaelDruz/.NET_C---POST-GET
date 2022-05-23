using Microsoft.EntityFrameworkCore;
using WebApiTest.Model;

namespace WebApiTest.Descricao
{
    public class Descricao : DbContext
    {
        public Descricao(DbContextOptions<Descricao> options)
            : base(options) => Database.EnsureCreated();
        public DbSet<Contato> Contato { get; set; }
    }
}
