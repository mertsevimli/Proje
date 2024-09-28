using Microsoft.AspNetCore.Mvc;
using NisanKurumsalSite.Data;

namespace NisanKurumsalSite.WebUI.Areas.Admin.Controllers;

public class ContactsController : Controller
{
    private readonly DatabaseContext _context;

    public ContactsController(DatabaseContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
        return View(_context.Contacts);
    }
}