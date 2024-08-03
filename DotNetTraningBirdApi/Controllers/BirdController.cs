using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DotNetTraningBirdApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdController : ControllerBase
    {
        private readonly string _url = "https://burma-project-ideas.vercel.app/birds";
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(_url);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<BirdDataModel>? birds = JsonConvert.DeserializeObject<List<BirdDataModel>>(jsonString);

                List<BirdViewModel> lst = new List<BirdViewModel>();

                foreach (var bird in birds)
                {
                    BirdViewModel item = Change(bird);
                    lst.Add(item);
                }
                return Ok(lst);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"{_url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                BirdDataModel? bird = JsonConvert.DeserializeObject<BirdDataModel>(jsonString);
                var item = Change(bird);
                return Ok(item);
            }
            else
            {
                return BadRequest();
            }
        }

        private BirdViewModel Change(BirdDataModel bird)
        {
            var item = new BirdViewModel
            {
                BirdId = bird.Id,
                BirdName = bird.BirdMyanmarName,
                Desc = bird.Description,
                PhotoUrl = $"{_url}/{bird.ImagePath}"
            };
            return item;
        }
    }
}
