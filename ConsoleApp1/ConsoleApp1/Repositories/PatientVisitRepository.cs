using ConsoleApp1.Models;

namespace ConsoleApp1.Repositories;

public class PatientVisitRepository : IPatientVisitRepository
{
    private static readonly List<PatientVisit> Visits = new();
    private static int _nextId = 1;
    private static int _nextVisitNumber = 1;
    private static readonly object Lock = new();

    public List<PatientVisit> GetAll()
    {
        return Visits.OrderByDescending(v => v.ArrivalDateTime).ToList();
    }

    public PatientVisit GetById(int id)
    {
        return Visits.FirstOrDefault(v => v.Id == id);
    }

    public void Add(PatientVisit visit)
    {
        lock (Lock)
        {
            visit.Id = _nextId++;
            visit.VisitNumber = GenerateVisitNumber();
            Visits.Add(visit);
        }
    }

    public void Update(PatientVisit visit)
    {
        var existing = GetById(visit.Id);
        if (existing == null)
        {
            return;
        }

        existing.FirstName = visit.FirstName;
        existing.LastName = visit.LastName;
        existing.Age = visit.Age;
        existing.Sex = visit.Sex;
        existing.ContactNumber = visit.ContactNumber;
        existing.Address = visit.Address;
        existing.Physician = visit.Physician;
        existing.VisitType = visit.VisitType;
        existing.ArrivalDateTime = visit.ArrivalDateTime;
        existing.ChiefComplaint = visit.ChiefComplaint;
        existing.Notes = visit.Notes;
        existing.Status = visit.Status;
        existing.ConsultationCompletedDateTime = visit.ConsultationCompletedDateTime;
    }

    public List<PatientVisit> Search(string term)
    {
        if (string.IsNullOrWhiteSpace(term))
        {
            return GetAll();
        }

        var normalized = term.Trim().ToLowerInvariant();

        return Visits.Where(v =>
                v.VisitNumber.ToLowerInvariant().Contains(normalized) ||
                v.FirstName.ToLowerInvariant().Contains(normalized) ||
                v.LastName.ToLowerInvariant().Contains(normalized) ||
                v.Physician.ToLowerInvariant().Contains(normalized) ||
                v.Status.ToString().ToLowerInvariant().Contains(normalized))
            .OrderByDescending(v => v.ArrivalDateTime)
            .ToList();
    }

    public string GenerateVisitNumber()
    {
        lock (Lock)
        {
            var number = $"V-{DateTime.Now:yyyyMMdd}-{_nextVisitNumber:D4}";
            _nextVisitNumber++;
            return number;
        }
    }
}
