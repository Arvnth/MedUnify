using MedUnify.Models;

namespace MedUnify.IService
{
    public interface IPatientService
    {
        Task<List<Patient>> GetPatientsAsync();
        Task<bool> AddPatientAsync(Patient patient);
        Task<bool> AddVisitAsync(Visit visit);
        Task<bool> AddProgressNotesAsync(ProgressNote progressNotes);
    }
}
