using ConsoleApp1.Models;
using ConsoleApp1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controllers;

[Authorize]
public class PatientVisitController : Controller
{
    private readonly IPatientVisitRepository _repository;

    public PatientVisitController(IPatientVisitRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index(string searchTerm)
    {
        var visits = _repository.Search(searchTerm);
        ViewData["SearchTerm"] = searchTerm;
        return View(visits);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new PatientVisit { ArrivalDateTime = DateTime.Now });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(PatientVisit model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        model.Status = VisitStatus.Waiting;
        model.ConsultationCompletedDateTime = null;
        _repository.Add(model);

        TempData["SuccessMessage"] = $"Visit {model.VisitNumber} registered successfully";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var visit = _repository.GetById(id);
        if (visit == null)
        {
            return NotFound();
        }

        return View(visit);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, PatientVisit model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        var existing = _repository.GetById(id);
        if (existing == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        model.VisitNumber = existing.VisitNumber;
        model.Status = existing.Status;
        model.ConsultationCompletedDateTime = existing.ConsultationCompletedDateTime;
        _repository.Update(model);

        TempData["SuccessMessage"] = $"Visit {model.VisitNumber} updated successfully";
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int id)
    {
        var visit = _repository.GetById(id);
        if (visit == null)
        {
            return NotFound();
        }

        return View(visit);
    }

    [HttpGet]
    public IActionResult Complete(int id)
    {
        var visit = _repository.GetById(id);
        if (visit == null)
        {
            return NotFound();
        }

        if (visit.Status == VisitStatus.Completed)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(visit);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Complete(int id, PatientVisit ignored)
    {
        var visit = _repository.GetById(id);
        if (visit == null)
        {
            return NotFound();
        }

        visit.Status = VisitStatus.Completed;
        visit.ConsultationCompletedDateTime = DateTime.Now;
        _repository.Update(visit);

        TempData["SuccessMessage"] = $"Consultation for {visit.FullName} marked as completed";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult StartConsultation(int id)
    {
        var visit = _repository.GetById(id);
        if (visit == null)
        {
            return NotFound();
        }

        if (visit.Status == VisitStatus.Waiting)
        {
            visit.Status = VisitStatus.InConsultation;
            _repository.Update(visit);
        }

        return RedirectToAction(nameof(Index));
    }
}
