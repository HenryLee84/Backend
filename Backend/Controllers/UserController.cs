using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.DTO;
using Repository.Models;
using Repository.Repository;
using Utilities.Extensions;
using Utilities.Helper;

namespace Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repository;
        private readonly TokenHelper _tokenHelper;

        public UserController(UserRepository repository, TokenHelper tokenHelper)
        {
            _repository = repository;
            _tokenHelper = tokenHelper;
        }

        /// <summary>
        /// 取得該會員資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var id = User.GetUserID();

            if (id == null)
                return NotFound("Invalid User");

            var user = await _repository.GetAsync(id.Value);

            if (user == null)
                return NotFound("Invalid User");

            return Ok(new GetUserViewModel(user.Id, user.Name, user.Account));
        }

        /// <summary>
        /// 新建會員
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            // 取得是否有帳號相同的使用者
            var existUser = await _repository.GetAsync(model.Account);

            if (existUser != null)
                return Conflict("Already created");

            var user = new User
            {
                Name = model.Account,
                Account = model.Account,
                Password = model.Password,
                CreateTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            };

            user = await _repository.CreateAsync(user);

            return Ok(new { user = new GetUserViewModel(user.Id, user.Name, user.Account), token = _tokenHelper.GenerateJwtToken(user.Id, user.Account)  });
        }
    }
}
