using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WideBotApi.Models;

namespace WideBotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleApiController : ControllerBase
    {
        private readonly HttpClient httpClient;
        private readonly IMapper _mapper;

        public SampleApiController(HttpClient httpClient, IMapper mapper)
        {
            this.httpClient = httpClient;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFromFakeApi([FromQuery]int page = 1, int per_page = 6)
        {
            // The URL of the fake API endpoint
            string apiUrl = $"https://reqres.in/api/users/?page={page}&per_page={per_page}";

            try
            {
                // Make the HTTP GET request to the API
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<ResponseData>(responseBody);

                    //Mapping from responseData to FacebookGC
                    List<FacebookGC> facebookGCs = new List<FacebookGC>();
                    
                    foreach(var i in responseData.data)
                    {
                       FacebookGC facebookGC = _mapper.Map<FacebookGC>(i);
                        facebookGC.DefaultAction = new DefaultAction(i.Email);
                        facebookGC.Buttons = new List<Button>() { new Button(i.Email) };
                        facebookGCs.Add(facebookGC);
                    }
                    return Ok(facebookGCs);
                }
                else
                {
                    // Return an error response if the request was not successful
                    return BadRequest($"Request to {apiUrl} failed with status code {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


    }
}
