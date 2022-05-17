using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.DTO;
using Repository.Models;
using Repository.Repository;
using Utilities.Extensions;

namespace Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repository;

        public UserController(UserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 取得該會員會員資料
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

            return Ok(user);
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

            await _repository.CreateAsync(user);

            return Ok(user);
        }
    }
}
