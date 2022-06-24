using System;
using GerenciamentoDeDescontro.Interfaces;
using GerenciamentoDeDescontro.Utils;

namespace GerenciamentoDeDescontro.Classes
{
    public class GerenciadorDeDesconto
    {
        private readonly ICalculaDescontoFidelidade _descontoFidelidade;

        public GerenciadorDeDesconto(ICalculaDescontoFidelidade descontoFidelidade)
        {
            _descontoFidelidade = descontoFidelidade;
        }

        public decimal AplicarDesconto(decimal preco, StatusContaCliente statusContaCliente, int tempoDeContaEmAnos)
        {
            decimal precoDepoisDoDesconto = 0;

            switch (statusContaCliente)
            {
                case StatusContaCliente.NaoRegistrado:
                    precoDepoisDoDesconto = new ClienteNaoRegistradoDesconto().AplicarDescontoStatusConta(preco);;
                    break;
                case StatusContaCliente.ClienteComum:
                    precoDepoisDoDesconto = new ClienteComumDesconto().AplicarDescontoStatusConta(preco);
                    precoDepoisDoDesconto = 
                        _descontoFidelidade.AplicarDescontoFidelidade(precoDepoisDoDesconto, tempoDeContaEmAnos);
                    break;
                case StatusContaCliente.ClienteEspecial:
                    precoDepoisDoDesconto = new ClienteEspecialDesconto().AplicarDescontoStatusConta(preco);
                    precoDepoisDoDesconto = 
                        _descontoFidelidade.AplicarDescontoFidelidade(precoDepoisDoDesconto, tempoDeContaEmAnos);
                    break;
                case StatusContaCliente.ClienteVIP:
                    precoDepoisDoDesconto = new ClienteVipDesconto().AplicarDescontoStatusConta(preco);
                    precoDepoisDoDesconto = 
                        _descontoFidelidade.AplicarDescontoFidelidade(precoDepoisDoDesconto, tempoDeContaEmAnos);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return precoDepoisDoDesconto;
        }
    }
}