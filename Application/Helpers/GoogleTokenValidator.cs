using Domain.Helpers.Domain.Entities;
using Domain.Helpers.Interfaces;
using System.Net.Http.Json;

namespace Application.Helpers
{
    public class GoogleTokenValidator : IGoogleTokenValidator
    {
        private readonly HttpClient _httpClient;

        public GoogleTokenValidator(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GoogleUser> ValidateAsync(string token)
        {
            var response = await _httpClient.GetAsync($"https://oauth2.googleapis.com/tokeninfo?id_token={token}");
            if (!response.IsSuccessStatusCode)
                return null;

            var googleUser = await response.Content.ReadFromJsonAsync<GoogleUser>();
            return googleUser;
        }
    }
}

