using System;
using System.Collections.Generic;

namespace DIO.ProjectBank
{
    class Program
    {
        static List<Conta> listarContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        InserirConta();
                        break;
                    case "2":
                        ListarContas();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.WriteLine("Thank you for using our services!");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: \n");
            Console.WriteLine("Enter the source account number: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: \n");
            Console.WriteLine("Enter the target account number: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: \n");
            Console.WriteLine("Enter the amount to be transferred: ");
            double valorTranferencia = double.Parse(Console.ReadLine());

            listarContas[indiceContaOrigem].Transferir(valorTranferencia, listarContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: \n");
            Console.WriteLine("Enter account number: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: \n");
            Console.WriteLine("Enter the amount to be withdrawn: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listarContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: \n");
            Console.WriteLine("Enter account number: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: \n");
            Console.WriteLine("Enter the amount to be deposited: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listarContas[indiceConta].Depositar(valorDeposito);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            Console.WriteLine("Insert new account");

            Console.Write("Digite 1 para pessoa FÍSICA ou 2 para pessoa JURÍDICA: \n");
            Console.WriteLine("If you are foreigner enter 1 for PHYSICAL person or 2 for LEGAL person: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: \n");
            Console.WriteLine("Enter customer name: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial do cliente: \n");
            Console.WriteLine("Enter the customer's opening balance: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito do cliente: \n");
            Console.WriteLine("Enter customer credit: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listarContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas existentes");
            Console.WriteLine("List existing accounts");

            if (listarContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada ainda");
                Console.WriteLine("No account registered yet");
                return;
            }
            
            for (int i = 0; i < listarContas.Count; i++)
            {
                Conta conta = listarContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem-vindo(a) ao Banco Don Juan!      |Welcome to the Don Juan bank!");
            Console.WriteLine("O que podemos fazer por você agora?  |What can we do for you now?");
            Console.WriteLine("Escolha uma das opções abaixo:       |Choose one of the options below:");
            Console.WriteLine("                                     |");
            Console.WriteLine("1 - Inserir nova conta               |1 - Insert new account");
            Console.WriteLine("2 - Listar contas                    |2 - List accounts");
            Console.WriteLine("3 - Fazer uma transferência          |3 - Make a transfer");
            Console.WriteLine("4 - Fazer um saque                   |4 - Make a withdrawal");
            Console.WriteLine("5 - Fazer um depósito                |5 - Make a deposit");
            Console.WriteLine("C - Limpar a tela                    |C - Clean the screen");
            Console.WriteLine("X - Sair                             |X - Exit");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
