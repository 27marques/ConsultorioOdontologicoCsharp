using Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Controllers
{
    public class ProcedimentoController
{
    public static Procedimento IncluirProcedimento(
        string Descricao,
        double Preco
    )
    {
        if (String.IsNullOrEmpty(Descricao))
        {
            throw new Exception("Descricao é obrigatória");
        }
        if (Double.IsNaN(Preco) || Double.IsNegative(Preco)) 
            {
                throw new Exception("o preço é obrigatório");
            }

        return new Procedimento(Descricao, Preco);
    }

    public static Procedimento AlterarProcedimento(
        int Id,
        string Descricao,
        double Preco
    )
    {
        Procedimento procedimento = GetProcedimento(Id);
        
        if (!String.IsNullOrEmpty(Descricao))
        {
            procedimento.Descricao = Descricao;
        }
        if (!Double.IsNaN(Preco) && !Double.IsNegative(Preco)) {
                procedimento.Preco = Preco;
            }
        procedimento.Preco = Preco;

        return procedimento;
    }

    public static Procedimento ExcluirProcedimento(
        int Id
    )
    {
        Procedimento procedimento = GetProcedimento(Id);
        Models.Procedimento.RemoverProcedimento(procedimento);
        return procedimento;
    }

    public static List<Procedimento> VisualizarProcedimento()
    {
        return Models.Procedimento.GetProcedimento();
    }

    public static Procedimento GetProcedimento(
        int Id
    )
    {
        List<Procedimento> procedimentosModels = Models.Procedimento.GetProcedimento();
            IEnumerable<Procedimento> procedimentos = from Procedimento in procedimentosModels
                                        where Procedimento.Id == Id
                                        select Procedimento;
            Procedimento procedimento = procedimentos.First();

            if (procedimento == null)
            {
                throw new Exception("Procedimento não encontrado");
            }

            return procedimento;
    }
}
}