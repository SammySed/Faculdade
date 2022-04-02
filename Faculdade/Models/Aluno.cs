using System.ComponentModel.DataAnnotations;

namespace Faculdade.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Curso { get; set; }

        [Required]
        public string Endereco { get; set; }
       
        public string Tel { get; set; }

        [Required]
        public DateTime dataNascimento { get; set; }
    }
}
