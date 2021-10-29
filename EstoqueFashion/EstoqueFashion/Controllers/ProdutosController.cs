using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EstoqueFashion.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace EstoqueFashion.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
    }
}
