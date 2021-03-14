using System;

namespace DIO.ProjectBank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set;}
        private double Saldo { get; set;}
        private double Credito { get; set;}
        private string Nome { get; set;}

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            //Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo insuficiente");
                Console.WriteLine("Insufficient funds");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("O Saldo atual da conta do cliente {0} é R${1}.", this.Nome, this.Saldo);
            Console.WriteLine("Current account balance for customer {0} is R${1}.", this.Nome, this.Saldo);

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("O Saldo atual da conta do cliente {0} é R${1}.", this.Nome, this.Saldo);
            Console.WriteLine("Current account balance for customer {0} is R${1}.", this.Nome, this.Saldo);

        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno1 = " ";
            retorno1 += "Tipo da Conta: " + this.TipoConta + " | ";
            retorno1 += "Nome: " + this.Nome + " | ";
            retorno1 += "Saldo: " + this.Saldo + " | ";
            retorno1 += "Crédito: " + this.Credito +"\n";
            string retorno2 = " ";
            retorno2 += "Account Type: " + this.TipoConta + " | ";
            retorno2 += "Name: " + this.Nome + " | ";
            retorno2 += "Balance: " + this.Saldo + " | ";
            retorno2 += "Credit: " + this.Credito;
            return retorno1 + retorno2;
        }
    }
}