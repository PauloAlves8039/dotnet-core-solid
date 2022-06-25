using GerenciamentoDeDescontro.Interfaces;
using GerenciamentoDeDescontro.Utils;

namespace GerenciamentoDeDescontro.Classes
{
    public class GerenciadorDeDesconto
    {
        private readonly ICalculaDescontoStatusFactory _descontoStatusConta;
        private readonly ICalculaDescontoFidelidade _descontoFidelidade;

        public GerenciadorDeDesconto(ICalculaDescontoFidelidade descontoFidelidade, 
                                     ICalculaDescontoStatusFactory descontoStatusConta)
        {
            _descontoFidelidade = descontoFidelidade;
            _descontoStatusConta = descontoStatusConta;
        }

        public decimal AplicarDesconto(decimal preco, StatusContaCliente statusContaCliente, int tempoDeContaEmAnos)
        {
            decimal precoDepoisDoDesconto = 0;

            precoDepoisDoDesconto = _descontoStatusConta.
                GetCalculaDescontoStatusConta(statusContaCliente).AplicarDescontoStatusConta(preco);

            precoDepoisDoDesconto = _descontoFidelidade.
                AplicarDescontoFidelidade(precoDepoisDoDesconto, tempoDeContaEmAnos);

            return precoDepoisDoDesconto;
        }
    }
}