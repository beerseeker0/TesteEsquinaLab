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
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly Db _context;

        public ComprasController(Db context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Compra>> BuscarCompra(int id)
        {
            var compra = await _context.Compra.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoCompra == id);

            if (compra == null)
            {
                return NotFound(new { message = $"Não foi possível encontrar a Compra." });
            }

            return compra;
        }

        [HttpPost]
        public async Task<ActionResult<Compra>> InserirCompra(Compra compra)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!VerificarCliente(compra.CodigoCliente))
                return NotFound(new { message = $"Não foi possível encontrar o Cliente." });

            try
            {
                _context.Compra.Add(compra);

                List<Parcela> parcelas = CriarParcelas(compra);

                _context.Parcela.AddRange(parcelas);

                await _context.SaveChangesAsync();

                return CreatedAtAction("BuscarCompra", new { id = compra.CodigoCompra }, compra);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível realizar a Compra." });

            }    
        }

        public List<Parcela> CriarParcelas(Compra compra)
        {
            List<Parcela> parcelas = new List<Parcela>();
            
            for(int i = 1; i <= compra.QuantidadeParcelas; i++)
            {
                Parcela parc = new Parcela();
                parc.CodigoCompra = compra.CodigoCompra;
                parc.DataVencimento = compra.DataCompra.AddMonths(i-1);
                parc.ValorParcela = compra.ValorCompra / i;
            }

            return parcelas;
        }

        public bool VerificarCliente(int codigoCliente)
        {
            var cliente = _context.Cliente.Where(x=> x.CodigoCliente == codigoCliente).FirstOrDefault();

            if (cliente != null)
                return true;
            else
                return false;
        }
    }
}
