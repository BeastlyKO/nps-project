using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using nps_project.Models;
#pragma warning disable
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace nps_project.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ParkController : ControllerBase
    {


        /*
            Please be sure to enter a valstate API key or the app will not be able to gather the information needed to update the park tables. 
            You can go to https://www.nps.gov/subjects/developer/index.htm and sign up for free. You will get an API key which then you can 
            update on the API_Key string.
        */
        const string API_KEY = "k3vd3ToWnX0UphPayTku5FnBNH4DAFrRujMfZqYk";



        private readonly ILogger<ParkController> _logger;


        public ParkController(ILogger<ParkController> logger)
        {
            _logger = logger;
        }



        /*
          This method is to push a get request to the NPS API and request all parks with a biking activity in PA, DE, NJ and NY.
          It will return with a master list with all the parks in all the mentioned states.
         */
        // GET: <ParkController>
        [HttpGet]
        public async Task<IEnumerable<Park>> Get()
        {
            // list of states
            List<string> states = new List<string> { "PA", "NY", "DE", "NJ"};

            // list which will contain all parks in PA, DE, NJ, and NY
            List<Park> masterList = new List<Park>();


            //uses private method in order to get the information from the API
            foreach (var state in states) {

                ListOfParks parks = await GetParks(state);

                //for each park gathered by the private method, add them to the master list.
                foreach (var park in parks.data)
                {

                    masterList.Add(park);


                }
            }


            //return list
            return masterList;


        }



        /*
            This mehthod with send a get request for a specific state we want to get the parks for. An state is passed which then will pull a state from our state enumorator
            and pass the GET request to the API for that particular state. This type of GET request will be used to pull filtered information depenstateng on the state the
            user chooses.
         */
        // GET <ParkController>/5
        [HttpGet("{state}")]
        public async Task<IEnumerable<Park>> Get(string state)
        {
            // list which will contain parks from specific state depending on state
            List<Park> masterList = new List<Park>();

            //uses private method in order to get a list of parks for the specific state
            ListOfParks parks = await GetParks(state);

            //for each park gathered by the private method, add them to the master list.
            foreach (var park in parks.data)
            {
                //adds a park to the master list
                masterList.Add(park);

            }

            //return list
            return masterList;


        }

        /*
         * This is a private method which will create a client object and conduct the GET request to the NPS API.
           It will use the ID argument as a selector of which state to pull a list of parks from. It will then send the GET
           request, parse the information retrieved. and return a list for all parks with a biking activity for a particular state 
        */
        private async Task<ListOfParks> GetParks(string state)
        {
            //checks if the state
            if (!string.IsNullOrEmpty(state) && (string.Equals(state, "PA") || string.Equals(state, "NY") || string.Equals(state, "NJ") || string.Equals(state, "DE")))
            {

                //holds the query for the API
                string query =
                    "/parks?q=Biking&stateCode=" + state + "&api_key=" + API_KEY;


                //block that creates the HTTPclient object
                using (HttpClient client = new HttpClient())
                {
                    //response will be what holds the information obtained from API
                    HttpResponseMessage response = new HttpResponseMessage();

                    //sets the default to json header
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    //makes the get call to the API and stores the data in response
                    response = await client.GetAsync("https://developer.nps.gov/api/v1" +
                           query).ConfigureAwait(false);

                    //if statement to confirm it was able to establish a connect and receive a response back
                    if (response.IsSuccessStatusCode)
                    {
                        //Read reponse and convert to string
                        string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        //parses json
                        ListOfParks parks = JsonSerializer.Deserialize<ListOfParks>(json);

                        //returns a list of parks from desired state
                        return parks;

                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalstate State");
                return null;
            }

        }

    }
}
