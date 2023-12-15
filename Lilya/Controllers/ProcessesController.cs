using Microsoft.AspNetCore.Mvc;
using Lilya.Models; // Используйте корректные пространства имен
using Lilya.Services;

public class ProcessesController : Controller
{
    private readonly IProcessService _processService;

    public ProcessesController(IProcessService processService, IAuthorService authorService)
    {
        _processService = processService;
    }

    // GET: Processes
    public IActionResult Index(string searchName = "")
    {
        var processes = string.IsNullOrEmpty(searchName)
            ? _processService.GetAllProcesses()
            : _processService.FindProcessesByName(searchName);

        return View(processes);
    }

    // GET: Processes/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Processes/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Process process)
    {
        if (ModelState.IsValid)
        {
            _processService.AddProcess(process);
            return RedirectToAction(nameof(Index));
        }

        return View(process);
    }
}
