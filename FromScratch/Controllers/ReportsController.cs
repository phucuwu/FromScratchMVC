using FromScratch.Data;
using FromScratch.Models;
using Microsoft.AspNetCore.Mvc;

namespace FromScratch.Controllers;

public class ReportsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ReportsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // public IActionResult Index()
    // {
    //     var reports = _context.Reports.ToList();
    //     return View(reports);
    // }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Report report)
    {
        if (ModelState.IsValid)
        {
            _context.Reports.Add(report);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(report);
    }
    
    public IActionResult Index()
    {
        Console.WriteLine("🧠 ENTERED REPORTS CONTROLLER INDEX");
        var reports = _context.Reports.ToList();
        return View(reports);
    }

}