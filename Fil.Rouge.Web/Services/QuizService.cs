namespace Fil.Rouge.Web.Services
{
    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Models;
    using System.Text;

    public class QuizService
    {
        private HttpClient httpClient;

        public QuizService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44396");
        }

        public async Task<IList<QuizQuestion>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/QuizQuestion");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var quiz = JsonConvert.DeserializeObject<List<QuizQuestion>>(responseBody);

                return quiz;
            }

            return new List<QuizQuestion>();
        }

        public async Task<QuizQuestion> Get(int id)
        {
            var response = await this.httpClient.GetAsync($"/api/QuizQuestion/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var quiz = JsonConvert.DeserializeObject<QuizQuestion>(responseBody);

                return quiz;
            }

            return null;
        }

        public async Task<bool> Create(QuizQuestion quiz)
        {
            var content = new StringContent(JsonConvert.SerializeObject(quiz), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/QuizQuestion", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Update(int id, QuizQuestion quiz)
        {
            var content = new StringContent(JsonConvert.SerializeObject(quiz), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"/api/QuizQuestion/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await this.httpClient.DeleteAsync($"/api/QuizQuestion/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}