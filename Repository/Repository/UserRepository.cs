using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Repository
{
    public class UserRepository
    {
        private readonly DBContext _dbContext;

        public UserRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="user">使用者</param>
        /// <returns></returns>
        public async Task<User> CreateAsync(User user)
        {
            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        /// <summary>
        /// 取得使用者
        /// </summary>
        /// <param name="id">使用者Id</param>
        /// <returns></returns>
        public async Task<User?> GetAsync(int id)
        {
            return await _dbContext.User.AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// 取得使用者；密碼為空時只用帳號查詢
        /// </summary>
        /// <param name="account">使用者帳號</param>
        /// <param name="password">使用者密碼；可為空</param>
        /// <returns></returns>
        public async Task<User?> GetAsync(string account, string? password = null)
        {
            return await _dbContext.User.AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.Account == account
                                                                  && (string.IsNullOrEmpty(password) || x.Password == password));
        }
    }
}
