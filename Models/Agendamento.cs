using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Repository;
using System;

namespace Models
{
    public class Agendamento
    {
        public int Id { set; get; }
        [Required]
        public int IdPaciente { set; get; }
        public Paciente Paciente { get; }
        [Required]
        public int IdDentista { set; get; }
        public Dentista Dentista { get; }
        [Required]
        public int IdSala { set; get; }
        public Sala Sala { get; }
        public DateTime Data { set; get; }
        public bool Confirmado { set; get; }

        public Agendamento() { }

        public Agendamento(
            int IdPaciente,
            int IdDentista,
            int IdSala,
            DateTime Data
        )
        {
            this.Id = Id;
            this.IdPaciente = IdPaciente;
            this.Paciente = Paciente.GetPacientes().Find(Paciente => Paciente.Id == IdPaciente);
            this.IdDentista = IdDentista;
            this.Dentista = Dentista.GetDentistas().Find(Dentista => Dentista.Id == IdDentista);
            this.IdSala = IdSala;
            this.Sala = Sala.GetSalas().Find(Sala => Sala.Id == IdSala);
            this.Data = Data;
            
            Context db = new Context();
            db.Agendamentos.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\nPaciente: {this.Paciente.Nome}"
                + $"\nDentista: {this.Dentista.Nome}"
                + $"\nSala: {this.Sala.Numero}"
                + $"\nData: {this.Data}"
                + $"\nConfirmado: {(this.Confirmado ? "Sim" : "Não")}"
                + $"\nTotal: R$ {AgendamentoProcedimento.GetTotalPorAgendamento(this.Id)}"
                + $"\n{AgendamentoProcedimento.ImprimirPorAgendamento(this.Id)}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Agendamento.ReferenceEquals(obj, this))
            {
                return false;
            }
            Agendamento it = (Agendamento) obj;
            return it.Id == this.Id;
        }
        public static List<Agendamento> GetAgendamentos()
        {
            Context db = new Context();
            return (from Agendamento in db.Agendamentos select Agendamento).ToList();
        }

        public static void RemoverAgendamento(
            Agendamento agendamento
        )
        {
            Context db = new Context();
            db.Agendamentos.Remove(agendamento);
        }

        public static void RemoverProcedimento (
            Procedimento procedimento
        ) 
        {
            Procedimento.RemoverProcedimento(procedimento);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}