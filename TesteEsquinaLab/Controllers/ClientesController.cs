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
    public class ClientesController : ControllerBase
    {
        private readonly Db _context;

        public ClientesController(Db context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> ListarCliente()
        {

            var clientes = await _context.Cliente.AsNoTracking().ToListAsync();


            return clientes;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> BuscarCliente(int id)
        {
            var cliente = await _context.Cliente.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoCliente == id);

            if (cliente == null)
            {
                return NotFound(new { message = $"Não foi possível encontrar o Cliente." });
            }

            return cliente;
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> InserirCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.Cliente.Add(cliente);
                await _context.SaveChangesAsync();

                //Retorna utilizando o metodo de get já criado trazendo o codigo do novo cliente
                return CreatedAtAction("BuscarCliente", new { Id = cliente.CodigoCliente }, cliente);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível cadastrar Cliente." });
            }
                
        }

        [HttpPost("{id:int}")]
        public async Task<ActionResult<Cliente>> DeletarCliente(int id)
        {
            var cliente = await _context.Cliente.FirstOrDefaultAsync(x => x.CodigoCliente == id);
            if (cliente == null)
            {
                return NotFound(new { message = $"Não foi possível encontrar o Cliente." });
            }

            try
            {
                _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();

                return cliente;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível excluir o Cliente." });

            }
        }
    }
}
