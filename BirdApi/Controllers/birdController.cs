using BirdApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BirdApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class birdController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://burma-project-ideas.vercel.app/birds");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<birdDataModel> birds = JsonConvert.DeserializeObject<List<birdDataModel>>(json)!;

                List<birdViewModel> lst = birds.Select(bird => new birdViewModel
                {
                    BirdId = bird.Id,
                    BirdName = bird.BirdMyanmarName,
                    Desc = bird.Description,
                    PhotoUrl = $"img/birds/img/1_Orange-belliedLeafbird.jpg/{bird.ImagePath}",
                }).ToList();
                return Ok(lst);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok();
        }
    }
}
