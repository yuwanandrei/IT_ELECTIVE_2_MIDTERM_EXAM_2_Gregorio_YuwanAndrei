using ConsoleApp1.Models;

namespace ConsoleApp1.Repositories;

public interface IPatientVisitRepository
{
    List<PatientVisit> GetAll();
    PatientVisit GetById(int id);
    void Add(PatientVisit visit);
    void Update(PatientVisit visit);
    List<PatientVisit> Search(string term);
    string GenerateVisitNumber();
}
