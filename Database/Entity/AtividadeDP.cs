using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRH.Database.Entity
{
    public class AtividadeDP
    {
        //public AtividadeDP() {
        //    Status = SetStatus();
        //}

        [Key]
        public int Id { get; set; }
        public DateTime PrazoDeEntrega { get; set; }
        public DateTime Vencimento { get; set; }
        public string? Nome { get; set; }
        public string? CargoDoResponsavel { get; set; }
        public string? EmailDoResponsavel { get; set; }
        public int? QtCond { get; set; }
        public bool Encerrada { get; set; }

        [NotMapped]
        public string Status { get; set; }

        public string SetStatus()
        {
            if ((this.PrazoDeEntrega > DateTime.Now) && ((this.PrazoDeEntrega - DateTime.Now).TotalDays > 2))
            {
                return "No prazo";
            }
            else if ((this.PrazoDeEntrega > DateTime.Now) && ((this.PrazoDeEntrega - DateTime.Now).TotalDays <= 2))
            {
                return "Vencendo";
            }
            else 
            {
                return "Atrasada";
            }
        }
    }
}
