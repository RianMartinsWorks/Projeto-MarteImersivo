using System.Data.Entity;

namespace PIM_WEB_MARTE.Models
{
    //Para adicionar as tabelas ao banco de dados e fazer a conexão com o banco correto
    public class Contexto : DbContext
    {
        public Contexto() : base("RIAN") { }

        public DbSet<Feedback> Feedback { get; set; }

        public DbSet<AdminModel> Admin { get; set; }
    }
}
