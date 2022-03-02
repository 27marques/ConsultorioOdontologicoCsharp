using System;
using Models;
using System.Linq;
using System.Collections.Generic;

namespace Models
{
    public class AgendamentoProcedimento
    {
        public static int ID = 0;
        private static List<AgendamentoProcedimento> AgendamentoProcedimentos = new List<AgendamentoProcedimento>();
        public int Id { get; set; }
        public int IdProcedimento { get; set; }
        public Procedimento Procedimento { get; set; }
        public int IdAgendamento { get; set; }
        public Agendamento Agendamento { get; set; }
        
        public AgendamentoProcedimento(
            int IdProcedimento,
            int IdAgendamento
        ) : this(++ID, IdProcedimento,IdAgendamento)
        {

        }

        private AgendamentoProcedimento(
            int Id,
            int IdProcedimento,
            int IdAgendamento
        )
        {
            this.Id = ID;
            this.IdProcedimento = IdProcedimento;
            this.Procedimento = Procedimento.GetProcedimento().Find(Procedimento => Procedimento.Id == IdProcedimento);
            this.IdAgendamento = IdAgendamento;
            this.Agendamento = Agendamento.GetAgendamentos().Find(Agendamento => Agendamento.Id == IdAgendamento);

            AgendamentoProcedimentos.Add(this);
        }

        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\nProcedimento: {this.IdProcedimento}"
                + $"\nAgendamento: {this.IdAgendamento}";
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
            return AgendamentoProcedimentos;
        }

        public static IEnumerable<AgendamentoProcedimento> GetProcedimentosPorAgendamento(int IdAgendamento)
        {
            return AgendamentoProcedimentos.FindAll(Procedimento => Procedimento.IdAgendamento == IdAgendamento);
        }

        public static double GetTotalPorAgendamento(int IdAgendamento)
        {
            return (
                from AgendamentoProcedimento in AgendamentoProcedimentos 
                where AgendamentoProcedimento.IdAgendamento == IdAgendamento 
                select AgendamentoProcedimento.Procedimento.Preco
            ).Sum();
        }

        public static string ImprimirPorAgendamento(int IdAgendamento)
        {
            IEnumerable<AgendamentoProcedimento> procedimentos = from AgendamentoProcedimento in AgendamentoProcedimentos 
                where AgendamentoProcedimento.IdAgendamento == IdAgendamento
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
            AgendamentoProcedimentos.Remove(agendamentoProcedimento);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
