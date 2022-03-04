using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace Models
{
    public class AgendamentoProcedimento
    {
        public int Id { get; set; }
        public int ProcedimentoId { get; set; }
        public Procedimento Procedimento { get; set; }
        public int AgendamentoId { get; set; }
        public Agendamento Agendamento { get; set; }
        
        public AgendamentoProcedimento() { }

        public AgendamentoProcedimento(
            int ProcedimentoId,
            int AgendamentoId
        )
        {
            this.ProcedimentoId = ProcedimentoId;
            this.Procedimento = Procedimento.GetProcedimento().Find(Procedimento => Procedimento.Id == ProcedimentoId);
            this.AgendamentoId = AgendamentoId;
            this.Agendamento = Agendamento.GetAgendamentos().Find(Agendamento => Agendamento.Id == AgendamentoId);

            Context db = new Context();
            db.AgendamentoProcedimentos.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\nProcedimento: {this.ProcedimentoId}"
                + $"\nAgendamento: {this.AgendamentoId}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!AgendamentoProcedimento.ReferenceEquals(obj, this))
            {
                return false;
            }
            AgendamentoProcedimento it = (AgendamentoProcedimento) obj;
            return it.Id == this.Id;
        }

        public static List<AgendamentoProcedimento> GetAgendamentoProcedimento()
        {
            Context db = new Context();
            return (from AgendamentoProcedimento in db.AgendamentoProcedimentos select AgendamentoProcedimento).ToList();
        }

        public static IEnumerable<AgendamentoProcedimento> GetProcedimentosPorAgendamento(int AgendamentoId)
        {
            Context db = new Context();
            return (
                from AgendamentoProcedimento in db.AgendamentoProcedimentos 
                where AgendamentoProcedimento.AgendamentoId == AgendamentoId
                select AgendamentoProcedimento
            );
        }

        public static double GetTotalPorAgendamento(int AgendamentoId)
        {
            Context db = new Context();
            return (
                from AgendamentoProcedimento in db.AgendamentoProcedimentos 
                where AgendamentoProcedimento.AgendamentoId == AgendamentoId 
                select AgendamentoProcedimento.Procedimento.Preco
            ).Sum();
        }

        public static string ImprimirPorAgendamento(int AgendamentoId)
        {
            Context db = new Context();
            IEnumerable<AgendamentoProcedimento> procedimentos = from AgendamentoProcedimento in db.AgendamentoProcedimentos 
                where AgendamentoProcedimento.AgendamentoId == AgendamentoId
                select AgendamentoProcedimento;

            
            string ret = "Procedimentos: ";
            if (procedimentos.Count() > 0) {
                foreach(AgendamentoProcedimento procedimento in procedimentos) {
                    ret += $"\n    Procedimento: {procedimento.Procedimento.Descricao}";
                    ret += $"\n    Preco: {procedimento.Procedimento.Preco}";
                }
            }
            else 
            {
                ret += "\n    Não há procedimentos.";
            }           

            return ret;
        }

        public static void RemoverAgendamentoProcedimento(
            AgendamentoProcedimento agendamentoProcedimento
        )
        {
            Context db = new Context();
            db.AgendamentoProcedimentos.Remove(agendamentoProcedimento);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
