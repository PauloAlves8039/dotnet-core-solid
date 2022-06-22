using System;
using GerenciamentoDeDescontro.Utils;

namespace GerenciamentoDeDescontro.Classes
{
    public class GerenciadorDeDesconto
    {
        public decimal AplicarDesconto(decimal preco, StatusContaCliente statusContaCliente, int tempoDeContaEmAnos)
        {
            decimal precoDepoisDoDesconto = 0;

            decimal descontoPorFidelidade = tempoDeContaEmAnos > 5 ? (decimal)5 / 100 : (decimal)tempoDeContaEmAnos / 100;

            switch (statusContaCliente)
            {
                case StatusContaCliente.NaoRegistrado:
                    precoDepoisDoDesconto = preco;
                    break;
                case StatusContaCliente.ClienteComum:
                    precoDepoisDoDesconto = (preco - (0.1m * preco)) - descontoPorFidelidade * (preco - (0.1m * preco));
                    break;
                case StatusContaCliente.ClienteEspecial:
                    precoDepoisDoDesconto = (0.7m * preco) - descontoPorFidelidade * (0.7m * preco);
                    break;
                case StatusContaCliente.ClienteVIP:
                    precoDepoisDoDesconto = (preco - (0.5m * preco)) - descontoPorFidelidade * (preco - (0.5m * preco));
                    break;
                default:
                    throw new NotImplementedException();
            }

            return precoDepoisDoDesconto;
        }
    }
}