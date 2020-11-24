using RestSharp;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Exercise
{
    public class Service
    {
        public async Task<Film> GetStarWarsEpisodeIntroduction(int episodeId)
        {
            // Save request log into file
            var log = File.AppendAllTextAsync("log.txt", $"{DateTime.Now:G} - Looking for film with id {episodeId}\n");

            var filmData = await GetFilmByEpisodeId(episodeId);

            if (string.IsNullOrWhiteSpace(filmData.Content))
            {
                return null;
            }

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            await log;
            return JsonSerializer.Deserialize<Film>(filmData.Content, options);

        }

        private Task<IRestResponse> GetFilmByEpisodeId(int id)
        {
            var client = new RestClient($"http://swapi.dev/api/films/{id}/");

            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            return client.ExecuteAsync(request);
        }
    }

    public class Film
    {
        public string Title { get; set; }

        [JsonPropertyName("opening_crawl")]
        public string Introduction { get; set; }
    }
}