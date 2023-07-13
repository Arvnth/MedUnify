using MedUnify.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MedUnify.Services
{
    public interface IProgressNoteService
    {
        Task<bool> AddProgressNoteAsync(int visitId, ProgressNote progressNote);
        Task<ProgressNote> GetProgressNoteByIdAsync(int visitId, int progressNoteId);
        Task<List<ProgressNote>> GetProgressNotesForVisitAsync(int visitId);
        Task<bool> UpdateProgressNoteAsync(int visitId, ProgressNote progressNote);
        Task<bool> DeleteProgressNoteAsync(int visitId, int progressNoteId);
    }
}
