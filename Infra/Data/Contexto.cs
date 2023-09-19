using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class Contexto : IdentityDbContext
    {
        public Contexto() { }
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Dentista> Dentistas { get; set; }
        public DbSet<Tratamento> Tratamentos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetConnectionString());
            base.OnConfiguring(optionsBuilder);
        }
        private string GetConnectionString()
        {
            return "Data Source=SAMUEL;Initial Catalog=ClinicaDentaria;Integrated Security=True;Encrypt=false";
        }
    }
}
