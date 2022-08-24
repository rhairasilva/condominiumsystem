using SistemaRH.Database.Data;
using SistemaRH.Database.Entity;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Models
{
    public class AtividadeDPModel
    {
        public List<AtividadeDP> GetAllAtividadeDPList(bool incluirEncerradas)
        {
            List<AtividadeDP> listAtiv = new List<AtividadeDP>();
            
            using (var context = new SistemaDbContext())
            {
                listAtiv = context.AtividadeDP.Where(a => a.Encerrada == incluirEncerradas).ToList();
                context.DisposeAsync();
            }

            return listAtiv;
        }

        public List<AtividadeDP> GetAtividadeDPListByEmailUsuario(string emailUsuario, bool incluirEncerradas)
        {
            List<AtividadeDP> listAtiv = new List<AtividadeDP>();

            using (var context = new SistemaDbContext())
            {
                listAtiv = context.AtividadeDP.Where(a => a.EmailDoResponsavel == emailUsuario && a.Encerrada == incluirEncerradas).ToList();
                context.DisposeAsync();
            }

            return listAtiv;
        }

        public AtividadeDP GetAtividadeDPById(int id)
        {
            AtividadeDP ativ = new AtividadeDP();

            using (var context = new SistemaDbContext())
            {
                ativ = context.AtividadeDP.Where(a => a.Id == id).FirstOrDefault();
                context.DisposeAsync();
            }

            return ativ;
        }

        public void UpdateAtividadeDP(AtividadeDP ativDp)
        {
            using (var context = new SistemaDbContext())
            {
                context.AtividadeDP.Update(ativDp);
                context.SaveChangesAsync();
                context.DisposeAsync();
            }
        }

        public void DeletarAtividadeDP(AtividadeDP ativDp)
        {
            using (var context = new SistemaDbContext())
            {
                context.AtividadeDP.Remove(ativDp);
                context.SaveChangesAsync();
                context.DisposeAsync();
            }
        }
    }
}
