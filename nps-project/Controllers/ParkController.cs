﻿using Microsoft.AspNetCore.Mvc;
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
        //enumeration which contains states we would like to focus on getting parks from
        public enum states { DE, NJ, NY, PA };

        /*
            Please be sure to enter a valid API key or the app will not be able to gather the information needed to update the park tables. 
            You can go to https://www.nps.gov/subjects/developer/index.htm and sign up for free. You will get an API key which then you can 
            update on the API_Key string.
        */
        const string API_KEY = "H0lH6eKP2De4ClAPvrHS3OtvHCZtUoBvEwP6zhuf";

        private readonly ILogger<ParkController> _logger;
        

        public ParkController(ILogger<ParkController> logger)
        {
            _logger = logger;
        }

        // GET: <ParkController>
        [HttpGet]
        public async Task<IEnumerable<Park>> Get()
        {
            // list which will contain all parks in PA, DE, NJ, and NY
            List<Park> masterList= new List<Park>();

            //Loops through four queires and updates the parks gathered to the master list.
            for (int i = 0; i < 4; i++)
            {   
                //uses private method in order to use the get call on the API
                ListOfParks parks = await GetParks(i);
                
                //for each park gathered by the private method, add them to the master list.
                foreach (var park in parks.data)
                {
                    //adds a park to the master list
                    masterList.Add(park);
                   
                }
            }

            //return list
            return masterList;

            
        }

        // GET <ParkController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Park>> Get(int id)
        {
            // list which will contain parks from specific state depending on id
            List<Park> masterList = new List<Park>();

            //uses private method in order to use the get call on the API
            ListOfParks parks = await GetParks(id);

            //for each park gathered by the private method, add them to the master list.
            foreach (var park in parks.data)
                {
                //adds a park to the master list
                masterList.Add(park);

                }

            //return list
            return masterList;


        }

        //private method which will create a client object and conduct the GET request to the NPS API
        private async Task<ListOfParks> GetParks(int id)
        {
            //uses ID to get the desired state from the state enum object
            var stateCode = (states)id;

            //holds the query for the API
            string query =
                "/parks?q=Biking&stateCode=" + stateCode + "&api_key=" + API_KEY;


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

                if (response.IsSuccessStatusCode)
                {
                    //Read reponse and convert to string
                    string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);



                    //parses json
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    ListOfParks parks = JsonSerializer.Deserialize<ListOfParks>(json);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.


                    //returns a list of parks from desired state
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
