using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPSTUFF.Data;
using ASPSTUFF.Models;

namespace ASPSTUFF.Controllers;

public class CustomersController : Controller
{
    private readonly ApplicationDbContext _context;

    public CustomersController(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        var customers = await _context.Customers.ToListAsync();
        return View(customers);
    }

public IActionResult Create()
{
    return View();
}


[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Id,Name,Email,Phone")] Customer customer)
{
    if (ModelState.IsValid)
    {
        _context.Add(customer);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(customer);
}
}