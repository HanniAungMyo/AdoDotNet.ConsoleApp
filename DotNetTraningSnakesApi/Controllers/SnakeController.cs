using DotNetTraningSnakesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotNetTraningSnakesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnakeController : ControllerBase
    {
        private readonly string _url = "https://burma-project-ideas.vercel.app/snakes";

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(_url);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<SnakeDataModel>? Snakes = JsonConvert.DeserializeObject<List<SnakeDataModel>>(jsonString);
                List<SnakeViewModel>? lst = new List<SnakeViewModel>();

                foreach (var snake in Snakes)
                {
                    lst.Add(new SnakeViewModel
                    {
                        Id = snake.Id,
                        PhotoUrl = snake.ImageUrl,
                        MyanmarName = snake.MMName,
                        EnglishName = snake.EngName,
                        Detail = snake.Detail,
                        IsPoison = snake.IsPoison,
                        IsDanger = snake.IsDanger,
                    });
                }
                return Ok(lst);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"{_url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<SnakeDataModel>? Snakes = JsonConvert.DeserializeObject<List<SnakeDataModel>>(jsonString);
                List<SnakeViewModel> lst=new List<SnakeViewModel>();
                foreach (var snake in Snakes)
                {
                    lst.Add(new SnakeViewModel
                    {
                        Id = snake.Id,
                        PhotoUrl = snake.ImageUrl,
                        MyanmarName = snake.MMName,
                        EnglishName = snake.EngName,
                        Detail = snake.Detail,
                        IsPoison = snake.IsPoison,
                        IsDanger = snake.IsDanger,
                    });
                }
                return Ok(lst);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
