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
    public class FaturasController : ControllerBase
    {
        private readonly Db _context;

        public FaturasController(Db context)
        {
            _context = context;
        }
    }
}
