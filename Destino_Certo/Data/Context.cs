using Destino_Certo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Destino_Certo.Data
{
    public class Context : DbContext
    {
        public DbSet<PessoaModel> Pessoas { get; set; }
        public DbSet<DestinoModel> Destinos { get; set; }
        public DbSet<AtendimentoModel> Atendimentos { get; set;}
        public DbSet<ReservaModel> Reservas { get; set; }

        public Context(DbContextOptions<Context> opt) : base(opt)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
