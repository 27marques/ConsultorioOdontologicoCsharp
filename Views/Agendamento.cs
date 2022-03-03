using System;
using Controllers;
using Models;
using System.Collections.Generic;

namespace Views
{
    public class AgendamentoView
    {

        public static void InserirAgendamento()
        {
            int IdPaciente;
            int IdDentista;
            int IdSala;
            DateTime Data = DateTime.Now;
            int opt = 0;
            List<int> IdProcedimentos = new List<int>();
            Console.WriteLine("Digite o ID do Paciente do Agendamento: ");
            try
            {
                IdPaciente = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite o Id do Dentista do Agendamento: ");
            try
            {
                IdDentista = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite o Id da Sala do Agendamento: ");
            try
            {
                IdSala = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite o Data do Agendamento: ");
            try
            {
                Data = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Data inválida.");
            }

            do
            {
                Console.WriteLine("Digite o Id do Procedimento que será executado: ");
                try
                {
                    IdProcedimentos.Add(Convert.ToInt32(Console.ReadLine()));
                }
                catch
                {
                    throw new Exception("Procedimento inválido.");
                }
                Console.WriteLine("Escolha a opção: ");
                Console.WriteLine("0 - Sair ");
                Console.WriteLine("1 - Inserir outro procedimento: ");
                try
                {
                    opt = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    opt = 99;
                }

                switch (opt)
                {
                    case 0:
                        Console.WriteLine("Saiu");
                        break;
                    case 1:
                        Console.WriteLine("Digite o Id do procedimento que será adicionado: ");
                        try
                        {
                            IdProcedimentos.Add(Convert.ToInt32(Console.ReadLine()));
                        }
                        catch
                        {
                        throw new Exception("Procedimento inválido.");
                        }
                        break;
                    default:
                        Console.WriteLine("Operação inválida");
                        break;
                }  

            }while(opt != 0);

            AgendamentoController.InserirAgendamento(
                IdPaciente,
                IdDentista,
                IdSala,
                Data,
                IdProcedimentos
            );
        }

        public static void AlterarAgendamento()
        {
            int Id = 0;
            int IdSala;
            DateTime Data = DateTime.Now;
            int opt = 0;
            List<int> IdProcedimentos = new List<int>();
            Console.WriteLine("Digite o ID do Agendamento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }            
            Console.WriteLine("Digite o Id da Sala do Agendamento: ");
            try
            {
                IdSala = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite o Data do Agendamento: ");
            try
            {
                Data = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Data inválida.");
            }

            do
            {
                Console.WriteLine("Escolha a opção: ");
                Console.WriteLine("0 - Sair ");
                Console.WriteLine("1 - Alterar Procedimento: ");
                Console.WriteLine("2 - Excluir Procedimento: ");
                try
                {
                    opt = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    opt = 99;
                }

                switch (opt)
                {
                    case 0:
                        Console.WriteLine("Saiu");
                        break;
                    case 1:
                        Console.WriteLine("Digite o Id do procedimento que será adicionado: ");
                        try
                        {
                            IdProcedimentos.Add(Convert.ToInt32(Console.ReadLine()));
                        }
                        catch
                        {
                        throw new Exception("Procedimento inválido.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Digite o Id do procedimento que será removido: ");
                        try
                        {
                            IdProcedimentos.Remove(Convert.ToInt32(Console.ReadLine()));
                        }
                        catch
                        {
                            throw new Exception("Procedimento inválido.");
                        }
                        break;
                    default:
                        Console.WriteLine("Operação inválida");
                        break;
                }  

            }while(opt != 0);

            /*do 
            {
                Console.WriteLine("Digite o Id do procedimento que será adicionado: ");
                try
                {
                    IdProcedimentos.Add(Convert.ToInt32(Console.ReadLine()));
                }
                catch
                {
                    throw new Exception("Procedimento inválido.");
                }
                Console.WriteLine("Deseja adicionar outro procedimento? [1-Sim]");
                try
                {
                    optProcedimento = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    optProcedimento = 99;
                }
            } while (optProcedimento != 1);

            do {
                Console.WriteLine("Digite o Id do procedimento que será removido: ");
                try
                {
                    IdProcedimentos.Remove(Convert.ToInt32(Console.ReadLine()));
                }
                catch
                {
                    throw new Exception("Procedimento inválido.");
                }
                Console.WriteLine("Deseja remover outro procedimento? [1-Sim]");
                try
                {
                    optProcedimento = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    optProcedimento = 99;
                }
            } while (optProcedimento != 1);
*/

            AgendamentoController.AlterarAgendamento(
                Id,
                IdSala,
                Data,
                IdProcedimentos
            );

        }

        public static void ExcluirAgendamento()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID do Agendamento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            
            AgendamentoController.ExcluirAgendamento(
                Id
            );

        }

        public static void ListarAgendamentos()
        {
            foreach (Agendamento item in AgendamentoController.VisualizarAgendamentos())
            {
                Console.WriteLine(item);
            }
        }

        public static void GetAgendamentosPorPaciente(int IdPaciente)
        {
            foreach (Agendamento item in AgendamentoController.GetAgendamentosPorPaciente(IdPaciente))
            {
                Console.WriteLine(item);
            }
        }
        public static void ConfirmarAgendamento()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID do Agendamento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Agendamento agendamento = AgendamentoController.ConfirmarAgendamento(Id);

            Console.WriteLine("Agendamento Confirmado: ");
            Console.WriteLine(agendamento);
        }
    }
}