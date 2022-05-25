using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Repository
{
    public class ParameterRepository
    {
        private readonly DBContext _dbContext;

        public ParameterRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 取得參數
        /// </summary>
        /// <param name="code">代碼</param>
        /// <returns></returns>
        public async Task<Parameter?> GetAsync(string code)
        {
            return await _dbContext.Parameter.FirstOrDefaultAsync(x => x.Code == code);
        }
    }
}
