using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EsquinaLabApi.Data;
using EsquinaLabApi.Models;

namespace EsquinaLabApi.Controllers
{
    [Route("api/[controller]/{actions}")]
    [ApiController]
    public class ParcelasController : ControllerBase
    {
        private readonly Db _context;

        public ParcelasController(Db context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Fatura>> BuscarProximaFaturaCliente(int codigoCliente)
        {
            var fatura = await _context.Fatura.AsNoTracking()
                                              .Where(x => x.CodigoCliente == codigoCliente
                                                       && x.DataPagamento == null)
                                              .OrderByDescending(x => x.DataVencimento)
                                              .FirstOrDefaultAsync();
            if (fatura == null)
            {
                return NotFound(new { message = "Não existe uma fatura em aberto para este Cliente." });
            }

            var parcelas = await _context.Parcela.AsNoTracking()
                                                     .Where(x => x.CodigoFatura == fatura.CodigoFatura)
                                                     .ToListAsync();

            return Ok(new { ValorDevido = fatura.ValorFatura, Parcelas = parcelas });
        }
    }
}
