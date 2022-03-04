using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace Models
{
    public class Dentista : Pessoa
    {
        [Required]
        public string Registro { set; get; }
        public double Salario { set; get; }
        public int EspecialidadeId { set; get; }

        public override string ToString()
        {
            return base.ToString()
                + $"\nRegistro (CRO): {this.Registro}" 
                + $"\nSalario: R$ {this.Salario}"
                + $"\nEspecialiade: {this.EspecialidadeId}";
        }
        public Dentista() { }

        public Dentista(
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            string Registro,
            double Salario,
            int EspecialidadeId
        ) : base(Nome, Cpf, Fone, Email, Senha)
        {
            this.Registro = Registro;
            this.Salario = Salario;
            this.EspecialidadeId = EspecialidadeId;

            Context db = new Context();
            db.Dentistas.Add(this);
            db.SaveChanges();
        }


        public static List<Dentista> GetDentistas()
        {
            Context db = new Context();
            return (from Dentista in db.Dentistas select Dentista).ToList();
        }

        public static void RemoverDentista(Dentista dentista)
        {
            Context db = new Context();
            db.Dentistas.Remove(dentista);
        }

    }
}