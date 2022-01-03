using Destino_Certo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Destino_Certo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<PessoaModel> Pessoas { get; set; }
        public DbSet<DestinoModel> Destinos { get; set; }
        public DbSet<HotelModel> Hoteis { get; set; }
        public DbSet<AtendimentoModel> Atendimentos { get; set;}
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ColaboradorModel> Colaboradores { get; set;}

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<HotelModel>()
                .HasOne(hotel => hotel.Destino)
                .WithMany(destino => destino.Hoteis)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
                 .Entity<UsuarioModel>()
                 .HasOne(usuario => usuario.Pessoa)
                 .WithOne(pessoa => pessoa.Usuario)
                 .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
                .Entity<UsuarioModel>()
                .HasOne(usuario => usuario.Colaborador)
                .WithOne(colaborador => colaborador.Usuario)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
