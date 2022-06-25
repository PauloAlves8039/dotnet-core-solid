using System;
using GerenciamentoDeDescontro.Interfaces;
using GerenciamentoDeDescontro.Utils;

namespace GerenciamentoDeDescontro.Classes
{
    public class CalculaDescontoStatusFactory : ICalculaDescontoStatusFactory
    {
        public ICalculaDescontoStatusConta GetCalculaDescontoStatusConta(StatusContaCliente statusContaCliente)
        {
            ICalculaDescontoStatusConta calcular;

            switch (statusContaCliente)
            {
                case StatusContaCliente.NaoRegistrado:
                    calcular = new ClienteNaoRegistradoDesconto();
                    break;
                case StatusContaCliente.ClienteComum:
                    calcular = new ClienteComumDesconto();
                    break;
                case StatusContaCliente.ClienteEspecial:
                    calcular = new ClienteEspecialDesconto();
                    break;
                case StatusContaCliente.ClienteVIP:
                    calcular = new ClienteVipDesconto();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return calcular;
        }
    }
}