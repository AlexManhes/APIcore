using Microsoft.EntityFrameworkCore;
using APIcore.Models;

namespace APIcore.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) 
            :   base(options) => Database.EnsureCreated();
        public DbSet<sosEditar> SOS { get; set; }

        internal object savechangesasync()
        {
            throw new NotImplementedException();
        }

        internal object Find(int matricula)
        {
            throw new NotImplementedException();
        }
    }
}
