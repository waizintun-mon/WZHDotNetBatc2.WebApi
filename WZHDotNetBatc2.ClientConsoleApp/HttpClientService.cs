using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WZHDotNetBatc2.ClientConsoleApp
{
    public class HttpClientService
    {
        public async Task RunAsync()
        {
            
            await CreateAsync();
            await ReadAsync();
            await UpdateAsync();
            await DeleteAsync(5);
        }
        HttpClient _client = new HttpClient();
        private async Task ReadAsync()
        {
            
            var response = await _client.GetAsync("https://localhost:7278/api/Movie/1/10");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
            }
        }
        private async Task CreateAsync()
        {
            var newMovie = new MovieModel()
            {
                Title = "Ghost",
                Genre= "horror",
                ReleaseYear= 2016,
                Rating = 9

            };
            var json = JsonConvert.SerializeObject(newMovie);
            StringContent content = new StringContent(json, Encoding.UTF8, Application.Json);
            var response = await _client.PostAsync("https://localhost:7278/api/Movie",content);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Create" +jsonStr);
            }
        }
        public async Task UpdateAsync()
        {
            var movie = new MovieModel()
            {
                MovieId = 1,
                Title = "Ghosted",
                Genre = "horror",
                ReleaseYear = 2016,
                Rating = 9

            };
            var json = JsonConvert.SerializeObject(movie);
            StringContent content = new StringContent(json, Encoding.UTF8, Application.Json);
            var response = await _client.PatchAsync($"https://localhost:7278/api/Movie/{movie.MovieId}", content);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Update" + jsonStr);
            }
        }
        public async Task DeleteAsync(int id)
        {

            var response = await _client.DeleteAsync($"https://localhost:7278/api/Movie/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine("delete" +jsonStr);
            }
        }

    }
    }
public class MovieModel
{
    public int MovieId { get; set; }    
    public string Title { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public int ReleaseYear { get; set; }

    public decimal Rating { get; set; }
}