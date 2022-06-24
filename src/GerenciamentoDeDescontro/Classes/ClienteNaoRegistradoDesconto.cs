using GerenciamentoDeDescontro.Interfaces;

namespace GerenciamentoDeDescontro.Classes
{
    public class ClienteNaoRegistradoDesconto : ICalculaDescontoStatusConta
    {
        public decimal AplicarDescontoStatusConta(decimal preco)
        {
            return preco;
        }
    }
}