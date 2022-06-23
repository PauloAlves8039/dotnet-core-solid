using System;
using GerenciamentoDeDescontro.Utils;

namespace GerenciamentoDeDescontro.Classes
{
    public class GerenciadorDeDesconto
    {
        public decimal AplicarDesconto(decimal preco, StatusContaCliente statusContaCliente, int tempoDeContaEmAnos)
        {
            decimal precoDepoisDoDesconto = 0;

            decimal descontoPorFidelidade = tempoDeContaEmAnos > Constantes.DESCONTO_MAXIMO_POR_FIDELIDADE ?
                        (decimal)Constantes.DESCONTO_MAXIMO_POR_FIDELIDADE / 100 : (decimal)tempoDeContaEmAnos / 100;

            switch (statusContaCliente)
            {
                case StatusContaCliente.NaoRegistrado:
                    precoDepoisDoDesconto = preco;
                    break;
                case StatusContaCliente.ClienteComum:
                    precoDepoisDoDesconto = (preco - (Constantes.DESCONTO_CLIENTE_COMUM * preco));
                    precoDepoisDoDesconto = precoDepoisDoDesconto -
                        (descontoPorFidelidade * precoDepoisDoDesconto);
                    break;
                case StatusContaCliente.ClienteEspecial:
                    precoDepoisDoDesconto = (preco - (Constantes.DESCONTO_CLIENTE_ESPECIAL * preco));
                    precoDepoisDoDesconto = precoDepoisDoDesconto -
                        (descontoPorFidelidade * precoDepoisDoDesconto);
                    break;
                case StatusContaCliente.ClienteVIP:
                    precoDepoisDoDesconto = (preco - (Constantes.DESCONTO_CLIENTE_VIP * preco));
                    precoDepoisDoDesconto = precoDepoisDoDesconto -
                        (descontoPorFidelidade * precoDepoisDoDesconto);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return precoDepoisDoDesconto;
        }
    }
}