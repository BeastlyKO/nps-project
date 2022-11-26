using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using nps_project.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace nps_project.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ParkController : ControllerBase
    {
        public enum states { DE, NJ, NY, PA };
        const string API_KEY = "H0lH6eKP2De4ClAPvrHS3OtvHCZtUoBvEwP6zhuf";

        private readonly ILogger<ParkController> _logger;

        public ParkController(ILogger<ParkController> logger)
        {
            _logger = logger;
        }

        // GET: api/<ParkController>
        [HttpGet]
        public async Task<IEnumerable<Park>> Get()
        {

            List<Park> masterList= new List<Park>();

            for (int i = 0; i < 4; i++)
            {
                ListOfParks parks = await GetParks(i);
                
                foreach (var park in parks.data)
                {
                    masterList.Add(park);
                   
                }
            }

            return masterList;

            
        }

        // GET <ParkController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Park>> Get(int id)
        {

            List<Park> masterList = new List<Park>();

           
                ListOfParks parks = await GetParks(id);
               
                foreach (var park in parks.data)
                {
                    masterList.Add(park);

                }
           

            return masterList;


        }


        private async Task<ListOfParks> GetParks(int id)
        {
            var stateCode = (states)id;
            string query =
                "/parks?q=Biking&stateCode=" + stateCode + "&api_key=" + API_KEY;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = new HttpResponseMessage();

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                response = await client.GetAsync("https://developer.nps.gov/api/v1" +
                       query).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    //Read reponse and convert to string
                    string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);



                    //parses json
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    ListOfParks parks = JsonSerializer.Deserialize<ListOfParks>(json);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

#pragma warning disable CS8603 // Possible null reference return.
                    return parks;
#pragma warning restore CS8603 // Possible null reference return.
                }
                else
                {
#pragma warning disable CS8603 // Possible null reference return.
                    return null;
#pragma warning restore CS8603 // Possible null reference return.
                }
            }

        }
    }
}
