namespace Fil.Rouge.Web.Services
{
    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Models;
    using System.Text;

    public class ParticipantDataService
    {
        private HttpClient httpClient;

        public ParticipantDataService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44396");
        }

        //******* Cette méthode doit lister que les questions attribuées à un Id Candidat
        public async Task<IList<ParticipantData>> GetQuiz(int quizid)
        {
            var response = await this.httpClient.GetAsync("/api/ApiQuiz").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var partdata = JsonConvert.DeserializeObject<List<ParticipantData>>(responseBody);

                return partdata;
            }
            else return null;
        }

        //*************************

        public async Task<IList<ParticipantData>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/ParticipantData");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var pdata = JsonConvert.DeserializeObject<List<ParticipantData>>(responseBody);

                return pdata;
            }

            return new List<ParticipantData>();
        }

        public async Task<ParticipantData> Get(int id)
        {
            var response = await this.httpClient.GetAsync($"/api/ParticipantData/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var pdata = JsonConvert.DeserializeObject<ParticipantData>(responseBody);

                return pdata;
            }

            return null;
        }

        public async Task<bool> Create(ParticipantData pdata)
        {
            var content = new StringContent(JsonConvert.SerializeObject(pdata), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/ParticipantData", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Update(int id, ParticipantData pdata)
        {
            var content = new StringContent(JsonConvert.SerializeObject(pdata), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"/api/ParticipantData/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await this.httpClient.DeleteAsync($"/api/ParticipantData/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

    }
}