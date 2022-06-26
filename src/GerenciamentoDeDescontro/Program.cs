using System;
using GerenciamentoDeDescontro.Classes;
using GerenciamentoDeDescontro.Interfaces;
using GerenciamentoDeDescontro.Utils;

namespace GerenciamentoDeDescontro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Gerenciamento de Desconto *****");

            Console.WriteLine("");

            ICalculaDescontoFidelidade descFide = new CalculaDescontoFidelidade();
            ICalculaDescontoStatusFactory descConta = new CalculaDescontoStatusFactory();

            GerenciadorDeDesconto gerDesc = new GerenciadorDeDesconto(descFide, descConta);

            Console.WriteLine("Valor da compra 1000 e fidelidade 10 anos (5%)\n");
            var resultado1 = gerDesc.AplicarDesconto(1000, StatusContaCliente.ClienteComum, 10);

            Console.WriteLine($"Cliente {StatusContaCliente.ClienteComum}, valor de desconto é de : {resultado1}");
            var resultado2 = gerDesc.AplicarDesconto(1000, StatusContaCliente.ClienteEspecial, 10);

            Console.WriteLine($"Cliente {StatusContaCliente.ClienteEspecial}, valor de desconto é de : {resultado2}");
            var resultado3 = gerDesc.AplicarDesconto(1000, StatusContaCliente.ClienteVIP, 10);

            Console.WriteLine($"Cliente {StatusContaCliente.ClienteVIP}, valor do Desconto é de : {resultado3}");
            Console.WriteLine("\n\nValor da compra 1000 e fidelidade 4 anos (4%)\n");

            var resultado4 = gerDesc.AplicarDesconto(1000, StatusContaCliente.ClienteComum, 4);
            Console.WriteLine($"Cliente {StatusContaCliente.ClienteComum}, valor do desconto é de : {resultado4}");

            var resultado5 = gerDesc.AplicarDesconto(1000, StatusContaCliente.ClienteEspecial, 4);
            Console.WriteLine($"Cliente {StatusContaCliente.ClienteEspecial}, valor do desconto é de : {resultado5}");

            var resultado6 = gerDesc.AplicarDesconto(1000, StatusContaCliente.ClienteVIP, 4);
            Console.WriteLine($"Cliente {StatusContaCliente.ClienteVIP}, valor do desconto é de : {resultado6}");

            Console.ReadLine();
        }
    }
}
