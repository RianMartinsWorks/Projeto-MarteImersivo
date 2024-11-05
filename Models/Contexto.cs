using System.Data.Entity;

namespace PIM_WEB_MARTE.Models
{
    public class Contexto : DbContext
    {
        public Contexto() : base("RIAN") { }

        public DbSet<Feedback> Feedback { get; set; }

        // Adicione a tabela AdminModel
        public DbSet<AdminModel> Admin { get; set; }
    }
}
