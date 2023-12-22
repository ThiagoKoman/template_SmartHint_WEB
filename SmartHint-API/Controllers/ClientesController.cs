using Microsoft.AspNetCore.Mvc;
using SmartHint_API.Models;

namespace SmartHint_API.Controllers
{
    [Route("Clientes")]
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ClientesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var clientes = _dbContext.Clientes.ToList();
            return View(clientes);
        }
    }
}
