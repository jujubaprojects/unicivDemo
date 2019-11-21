using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using unicivDemo.Model;

namespace unicivDemo.Repository
{
    public interface IFundoCapitalRepository
    {
        void Adicionar(FundoCapital fundo);
        void Alterar(FundoCapital fundo);
        IEnumerable<FundoCapital> ListarFundos();
        FundoCapital ObterPorId(Guid id);
        void Remover(FundoCapital fundo);
    }
}
