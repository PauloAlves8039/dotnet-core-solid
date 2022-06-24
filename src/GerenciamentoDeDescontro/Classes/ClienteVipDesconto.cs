using GerenciamentoDeDescontro.Interfaces;
using GerenciamentoDeDescontro.Utils;

namespace GerenciamentoDeDescontro.Classes
{
    public class ClienteVipDesconto : ICalculaDescontoStatusConta
    {
        public decimal AplicarDescontoStatusConta(decimal preco)
        {
            return preco - (Constantes.DESCONTO_CLIENTE_VIP * preco);
        }
    }
}