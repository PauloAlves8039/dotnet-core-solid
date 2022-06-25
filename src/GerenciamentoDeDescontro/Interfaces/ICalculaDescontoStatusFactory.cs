using GerenciamentoDeDescontro.Utils;

namespace GerenciamentoDeDescontro.Interfaces
{
    public interface ICalculaDescontoStatusFactory
    {
        ICalculaDescontoStatusConta GetCalculaDescontoStatusConta(StatusContaCliente statusContaCliente);
    }
}