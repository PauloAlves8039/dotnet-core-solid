using GerenciamentoDeDescontro.Interfaces;
using GerenciamentoDeDescontro.Utils;

namespace GerenciamentoDeDescontro.Classes
{
    public class ClienteComumDesconto : ICalculaDescontoStatusConta
    {
        public decimal AplicarDescontoStatusConta(decimal preco)
        {
            return preco - (Constantes.DESCONTO_CLIENTE_COMUM * preco);
        }
    }
}