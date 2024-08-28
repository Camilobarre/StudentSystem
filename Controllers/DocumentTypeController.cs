using LibrarySystem.Data;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Controllers;

[Route("[controller]")]
public class DocumentTypesController : Controller
{
    private readonly ILogger<DocumentTypesController> _logger;
    private readonly ApplicationDbContext _context;

    public DocumentTypesController(ILogger<DocumentTypesController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var allDocumentTypes = await _context.DocumentTypes.ToListAsync();
        return View(allDocumentTypes);
    }

    [Route("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(DocumentType documentType)
    {
        if (ModelState.IsValid)
        {
            _context.Add(documentType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        else
        {
            _logger.LogError("Error saving");
            return View(documentType);
        }
    }

    [Route("edit/{name}")]
    public async Task<IActionResult> Edit(string name)
    {
        var documentTypeFound = await _context.DocumentTypes.FindAsync(name);
        return View(documentTypeFound);
    }

    [HttpPost("edit/{id}")]
    public async Task<IActionResult> Edit(int id, DocumentType documentType)
    {
        var result = CheckExist(id);
        if (result == false)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(documentType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        else
        {
            _logger.LogError("El modelo no es valido");
            return View(documentType);
        }
    }

    [Route("delete/{name}")]
    public async Task<IActionResult> Delete(string name)
    {
        var documentTypeFound = await _context.DocumentTypes.FindAsync(name);
        if (documentTypeFound == null)
        {
            return NotFound();
        }
        return View(documentTypeFound);
    }

    [HttpPost("delete/{name}")]
    public async Task<IActionResult> DeleteConfirmed(string name)
    {
        var result = CheckExist(name);
        if (result == false)
        {
            return NotFound();
        }

        var documentTypeFound = await _context.DocumentTypes.FindAsync(name);
        if (documentTypeFound == null)
        {
            return NotFound();
        }
        _context.DocumentTypes.Remove(documentTypeFound);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    private bool CheckExist(string name)
    {
        var checkDocumentType = _context.DocumentTypes.Any(e => e.Name == name);
        if (checkDocumentType == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}