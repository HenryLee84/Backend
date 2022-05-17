using Microsoft.AspNetCore.Mvc;
using Repository.DTO;
using Repository.Repository;
using Utilities.Helper;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserRepository _repository;
        private readonly TokenHelper _tokenHelper;

        public LoginController(UserRepository repository, TokenHelper tokenHelper)
        {
            _repository = repository;
            _tokenHelper = tokenHelper;
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _repository.GetAsync(model.Account, model.Password);

            // 找不到會員，回傳錯誤
            if (user == null)
                return NotFound("Invalid user");

            var token = _tokenHelper.GenerateJwtToken(user.Id, user.Account);

            // 找到會員，回傳Jwt Token
            return Ok(new { token });
        }
    }
}
