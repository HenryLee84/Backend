using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Repository.Repository;
using System.ComponentModel.DataAnnotations;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly ParameterRepository _repository;

        public WeatherController(HttpClient client, IConfiguration configuration, ParameterRepository repository)
        {
            _client = client;
            _configuration = configuration;
            _repository = repository;
        }

        /// <summary>
        /// 取得氣象資料
        /// </summary>
        /// <param name="locationName">地點名稱</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([Required] string locationName)
        {
            var authorization = await _repository.GetAsync("WeatherAuthorization");

            if (authorization == null)
            {
                return NotFound("No authorization");
            }

            var url = new Uri(_configuration.GetValue<string>("Weather:Url"));

            var query = new Dictionary<string, string?>
            {
                { "authorization", authorization.Value },
                { "locationName", locationName },
            };

            var response = await _client.GetAsync(QueryHelpers.AddQueryString(url.AbsoluteUri, query));

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("Not success");
            }

            var content = await response.Content.ReadAsStringAsync();

            return Ok(content);
        }
    }
}
