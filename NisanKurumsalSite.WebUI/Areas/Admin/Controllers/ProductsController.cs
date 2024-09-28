using Microsoft.AspNetCore.Mvc;
using NisanKurumsalSite.Data;

namespace NisanKurumsalSite.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductsController : Controller
{
   private readonly DatabaseContext _context;
        public ProductsController(DatabaseContext context)
        {
            _context = context;
        }

    // GET
    public IActionResult Index()
    {
        return View(_context.Products);
    }
}