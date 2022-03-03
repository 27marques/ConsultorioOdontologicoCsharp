using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace Models
{
    public class Procedimento
    {
        public int Id { get; set;}
        [Required]
        public string Descricao { get; set;}
        public double Preco { get; set;}

        public Procedimento() { }
        public Procedimento(
            string Descricao,
            double Preco
        )
        {
            this.Id = Id;
            this.Descricao = Descricao;
            this.Preco = Preco;
            Context db = new Context();
            db.Procedimentos.Add(this);
            db.SaveChanges();

        }

        internal static void Add(Procedimento procedimento)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\nDescricao: {this.Descricao}"
                + $"\nPreco: {this.Preco}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Procedimento.ReferenceEquals(obj, this))
            {
                return false;
            }
            Procedimento it = (Procedimento) obj;
            return it.Id == this.Id;
        }

        public static List<Procedimento> GetProcedimento()
        {
            Context db = new Context();
            return (from Procedimento in db.Procedimentos select Procedimento).ToList();
        }

        public static void RemoverProcedimento(Procedimento procedimento)
        {
            Context db = new Context();
            db.Procedimentos.Remove(procedimento);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}