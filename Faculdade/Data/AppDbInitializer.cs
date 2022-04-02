using Faculdade.Models;

namespace Faculdade.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppCont>();
                context.Database.EnsureCreated();

                //Criar tarefas
                if (!context.Alunos.Any())
                {
                    context.Alunos.AddRange(new List<Aluno>()
                    {
                        new Aluno()
                        {
                            Name = "Marcos Evangelista Junior",
                            Curso = "Analise e Desenvolvimento de Sistemas",
                            Endereco = "sampa",
                            Tel = "9416501606856",
                            dataNascimento = DateTime.Now,
                        },
                    });
                    context.SaveChanges();
                }
                if (!context.Professores.Any())
                {
                    context.Professores.AddRange(new List<Professor>()
                    {
                        new Professor()
                        {
                            Name = "Samuel Silva Vieira",
                            Formacao = "Doutorado em Banco de Dados",
                            Endereco = "Sampa 2",
                            Tel = "1616515",
                            dataNascimento = DateTime.Now,
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
