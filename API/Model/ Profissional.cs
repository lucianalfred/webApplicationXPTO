using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    
    public class Profissional
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
    }
}