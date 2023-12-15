using Lilya.Models;
using Lilya.Services;
using Microsoft.AspNetCore.Mvc;

public class AuthorsController : Controller
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    // GET: Authors
    public IActionResult Index()
    {
        var authors = _authorService.GetAllAuthors();
        return View(authors);
    }

    // GET: Authors/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Authors/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("FullName")] Author author)
    {
        if (ModelState.IsValid)
        {
            _authorService.AddAuthor(author);
            return RedirectToAction(nameof(Index));
        }
        return View(author);
    }
}
