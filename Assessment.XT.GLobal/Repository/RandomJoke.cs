using Assessment.XT.GLobal.data;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Assessment.XT.GLobal.Repository
{
    public class RandomJoke : IRandomJoke
    {
        private readonly IOptions<APIConfiguration> _config;
        public RandomJoke(IOptions<APIConfiguration> config)
        {
            this._config = config;
        }
        public async Task<JokeSchema> GetJoke()
        {
            using (var client = new HttpClient(new HeaderHandler(_config)))
            {
                JokeSchema schema = null;
               
                    using (var response = await client.GetAsync(_config.Value.JokeAPIUrl))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        schema = JsonConvert.DeserializeObject<JokeSchema>(apiResponse);
                    }
                return schema;
            }
        }

        public async Task<JokeCountSchema> GetJokeCount()
        {
            using (var client = new HttpClient(new HeaderHandler(_config)))
            {
                JokeCountSchema schema = null;
               using (var response = await client.GetAsync(_config.Value.CountAPIUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    schema = JsonConvert.DeserializeObject<JokeCountSchema>(apiResponse);
                }
                return schema;
            }
           
        }
    }
}
