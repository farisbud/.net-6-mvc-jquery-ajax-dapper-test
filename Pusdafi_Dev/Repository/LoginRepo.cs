using Dapper;
using Pusdafi_Dev.Interface;
using Pusdafi_Dev.Models;
using Pusdafi_Dev.Models.Data;

namespace Pusdafi_Dev.Repository
{
    public class LoginRepo : LoginIntf
    {
        private readonly DapperDBContext _dbContext;

        public LoginRepo(DapperDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AuthenticatePassAsync(string pass)
        {
            var db = _dbContext.CreateConnection();
            var sql = @"select * from USERS where Password = @password";

            var result = await db.QueryAsync<User>(sql, new { password = pass }).ConfigureAwait(false);

            return result.FirstOrDefault();
        }

        public async Task<User> AuthenticateUserAsync(string mail)
        {
            var db = _dbContext.CreateConnection();
            var sql = @"select * from USERS where Email = @email";

            var result = await db.QueryAsync<User>(sql, new {email = mail }).ConfigureAwait(false);

            return result.FirstOrDefault();
        }
    }
}
