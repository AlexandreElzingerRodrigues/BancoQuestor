using BancoQuestor.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancoQuestor.Contexto
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) => Database.EnsureCreated();

        public DbSet<Banco> Banco{ get; set; }
        public DbSet<Boleto> Boleto{ get; set; }
    }
}
