using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using unicivDemo.Model;
using unicivDemo.Repository;

namespace unicivDemo.Controllers
{
    public class FundoCapitalController : Controller
    {
        private readonly IFundoCapitalRepository _repositorio;

        public FundoCapitalController(IFundoCapitalRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Nossa API está funcionando");
        }

        [HttpGet("v1/fundocapital")]
        public IActionResult ListarFundos()
        {

            return Ok(_repositorio.ListarFundos());
        }

        [HttpPost("v1/fundocapital")]
        public IActionResult Adicionarfundo([FromBody] FundoCapital fundo)
        {
            _repositorio.Adicionar(fundo);
            return Ok();
        }

        [HttpPut("v1/fundocapital/{id}")]
        public IActionResult ALterarFundo(Guid id, [FromBody] FundoCapital fundo)
        {
            var fundoAntigo = _repositorio.ObterPorId(id);
            if (fundoAntigo == null)
                return NotFound();

            fundoAntigo.Nome = fundo.Nome;
            fundoAntigo.ValorAtual = fundo.ValorAtual;
            fundoAntigo.ValorNecessario = fundo.ValorNecessario;
            fundoAntigo.DataResgate = fundo.DataResgate;

            _repositorio.Alterar(fundoAntigo);

            return Ok();
        }

        [HttpGet("v1/fundocapital/{id}")]
        public IActionResult ObterFundo(Guid id)
        {
            var fundoAntigo = _repositorio.ObterPorId(id);
            if (fundoAntigo == null)
                return NotFound();

            return Ok(fundoAntigo);
        }

        [HttpDelete("v1/removerfundo/{id}")]
        public IActionResult RemoverFundo(Guid id)
        {
            var fundo = _repositorio.ObterPorId(id);
            if (fundo == null)
                return NotFound();

            _repositorio.Remover(fundo);
            return Ok(fundo);
        }
    }
}
