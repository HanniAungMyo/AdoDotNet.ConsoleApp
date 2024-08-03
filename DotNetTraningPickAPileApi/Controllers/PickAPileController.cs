using DotNetTraningPickAPileApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNetTraningPickAPileApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickAPileController : ControllerBase
    {
        private readonly string _url = "https://burma-project-ideas.vercel.app/pick-a-pile";
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(_url);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                List<PileDataModel>? picks = JsonConvert.DeserializeObject<List<PileDataModel>>(jsonStr);
                List<PileViewModel> lst = new List<PileViewModel>();
                foreach (var pick in picks)
                {
                    var item = new PileViewModel
                    {
                        QuestionId = pick.QuestionId,
                        QuestionName = pick.QuestionName,
                        QuestionDescription = pick.QuestionDesp
                    };
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
                List<PileAnswerDataModel>? piles = JsonConvert.DeserializeObject<List<PileAnswerDataModel>>(jsonString);

                List<PileAnswerViewModel> lst = new List<PileAnswerViewModel>();
                foreach (var pile in piles)
                {
                    var item = new PileAnswerViewModel
                    {
                        AnswerImageUrl =$" https://burma-project-ideas.vercel.app/{pile.AnswerImageUrl}",
                        AnswerName = pile.AnswerName,
                        AnswerDesp = pile.AnswerDesp,
                    };
                    lst.Add(item);
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
