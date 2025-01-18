using Application.Helpers.Interfaces;
using Domain.Helpers.Entities;
using System.Net.Http.Json;

namespace Application.Helpers
{
    public class FacebookTokenValidator : IFacebookTokenValidator
    {
        private readonly HttpClient _httpClient;

        public FacebookTokenValidator(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<FacebookUser> ValidateAsync(string token)
        {
            var response = await _httpClient.GetAsync($"https://graph.facebook.com/me?fields=id,email,first_name,last_name&access_token={token}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var facebookUser = await response.Content.ReadFromJsonAsync<FacebookUser>();
            return facebookUser;
        }
    }
}
