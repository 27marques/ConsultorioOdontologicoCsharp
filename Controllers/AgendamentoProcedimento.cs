using Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Controllers
{
    public class AgendamentoProcedimentoController
    {
      public static AgendamentoProcedimento InserirAgendamentoProcedimento(
            int AgendamentoId,
            int ProcedimentoId
        )
        {
            AgendamentoController.GetAgendamento(AgendamentoId);
            ProcedimentoController.GetProcedimento(ProcedimentoId);

            return new AgendamentoProcedimento(AgendamentoId, ProcedimentoId);
        }

        public static AgendamentoProcedimento GetAgendamentoProcedimento(
            int Id
        )
        {
            AgendamentoProcedimento agendamento = (
                from AgendamentoProcedimento in AgendamentoProcedimento.GetAgendamentoProcedimento()
                    where AgendamentoProcedimento.Id == Id
                    select AgendamentoProcedimento
            ).First();

            if (agendamento == null)
            {
                throw new Exception("Relação Agendamento Procedimento não encontrada.");
            }

            return agendamento;
        }

        public static AgendamentoProcedimento ExcluirAgendamentoProcedimento(
            int Id
        )
        {
            AgendamentoProcedimento agendamentoProcedimento = GetAgendamentoProcedimento(Id);
            AgendamentoProcedimento.RemoverAgendamentoProcedimento(agendamentoProcedimento);
            return agendamentoProcedimento;
        }  
    }
}