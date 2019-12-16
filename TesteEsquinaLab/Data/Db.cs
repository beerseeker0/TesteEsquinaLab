using Microsoft.EntityFrameworkCore;
using EsquinaLabApi.Models;

namespace EsquinaLabApi.Data
{
    public class Db :  DbContext
    {
        public Db(DbContextOptions<Db> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Fatura> Fatura { get; set; }
        public DbSet<Parcela> Parcela { get; set; }
    }
}
