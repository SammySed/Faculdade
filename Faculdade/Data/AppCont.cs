using Faculdade.Models;
using Microsoft.EntityFrameworkCore;

namespace Faculdade.Data
{
    public class AppCont :DbContext
    {
        public AppCont(DbContextOptions<AppCont> options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos  { get; set; }

        public DbSet<Professor> Professores { get; set; }

    }
}
