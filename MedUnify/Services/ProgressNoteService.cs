using MedUnify.Models;
using MedUnify.IService;

namespace MedUnify.Services
{
    public class ProgressNoteService : IProgressNoteService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;

        public ProgressNoteService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseApiUrl = configuration.GetValue<string>("Api:BaseUrl");    
        }

        public async Task<bool> AddProgressNoteAsync(int visitId, ProgressNote progressNote)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseApiUrl + $"/api/visits/{visitId}/progressnotes", progressNote);
            return response.IsSuccessStatusCode;
        }

        public async Task<ProgressNote> GetProgressNoteByIdAsync(int visitId, int progressNoteId)
        {
            return await _httpClient.GetFromJsonAsync<ProgressNote>(_baseApiUrl + $"/api/visits/{visitId}/progressnotes/{progressNoteId}");
        }

        public async Task<List<ProgressNote>> GetProgressNotesForVisitAsync(int visitId)
        {
            return await _httpClient.GetFromJsonAsync<List<ProgressNote>>(_baseApiUrl + $"/api/visits/{visitId}/progressnotes");
        }

        public async Task<bool> UpdateProgressNoteAsync(int visitId, ProgressNote progressNote)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseApiUrl + $"/api/visits/{visitId}/progressnotes/{progressNote.ProgressNoteId}", progressNote);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProgressNoteAsync(int visitId, int progressNoteId)
        {
            var response = await _httpClient.DeleteAsync(_baseApiUrl + $"/api/visits/{visitId}/progressnotes/{progressNoteId}");
            return response.IsSuccessStatusCode;
        }
    }
}
