using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Database.Entity
{
    public class Usuario 
    {
        [Key]
        public string NomeDeUsuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public bool Admin { get; set; }
        public string Cargo { get; set; }
        public string Senha { get; set; }
    }
}
