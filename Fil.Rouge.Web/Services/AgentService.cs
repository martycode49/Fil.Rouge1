namespace Fil.Rouge.Web.Services
{
    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Models;
    using System.Text;

    public class AgentService
    {
        private HttpClient httpClient;

        public AgentService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44396");
        }

        public async Task<IList<Agent>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/Agent");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var agent = JsonConvert.DeserializeObject<List<Agent>>(responseBody);

                return agent;
            }

            return new List<Agent>();
        }

        public async Task<Agent> Get(int id)
        {
            var response = await this.httpClient.GetAsync($"/api/Agent/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var agent = JsonConvert.DeserializeObject<Agent>(responseBody);

                return agent;
            }

            return null;
        }

        public async Task<bool> Create(Agent agent)
        {
            var content = new StringContent(JsonConvert.SerializeObject(agent), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/Agent", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Update(int id, Agent agent)
        {
            var content = new StringContent(JsonConvert.SerializeObject(agent), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"/api/Agent/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await this.httpClient.DeleteAsync($"/api/Agent/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}