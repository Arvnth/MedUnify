using MedUnify.IService;
using MedUnify.Models;



namespace MedUnify.Services
{
    public class PatientService : IPatientService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;

        public PatientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _baseApiUrl = "http://localhost:5018"; 
        }

        public async Task<List<Patient>> GetPatientsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Patient>>(_baseApiUrl + "patients");
            return response;
        }

        public async Task<bool> AddPatientAsync(Patient patient)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseApiUrl + "patients", patient);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AddVisitAsync(Visit visit)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseApiUrl + $"patients/{visit.PatientId}/visits", visit);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AddProgressNotesAsync(ProgressNote progressNotes)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseApiUrl + $"patients/{progressNotes.PatientId}/visits/{progressNotes.VisitId}/progressnotes", progressNotes);
            return response.IsSuccessStatusCode;
        }
    }
}
