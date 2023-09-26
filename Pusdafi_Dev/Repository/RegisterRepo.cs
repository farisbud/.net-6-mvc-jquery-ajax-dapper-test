using Dapper;
using Pusdafi_Dev.Interface;
using Pusdafi_Dev.Models;
using Pusdafi_Dev.Models.Data;
using System.Data;
using System.Data.SqlClient;

namespace Pusdafi_Dev.Repository
{
    public class RegisterRepo : RegisterIntf
    {
        private readonly DapperDBContext _dbContext;

        public RegisterRepo(DapperDBContext dbContext)
        {
           _dbContext = dbContext;
        }

        public bool Add(User user)
        {
            var db = _dbContext.CreateConnection();
            var sql = @"Insert Into USERS ([Name], [Username], Email,Password,Create_At) Values (@name, @user, @email,@pass,@created);" + "Select CAST(SCOPE_IDENTITY() as int);";

            var cek = user;
            var Id = db.Query<int>(sql, new
            {
                @name = user.Name,
                @user = user.Username,
                @email = user.Email,
                @pass = user.Password,
                @created = DateTime.Now,

            }).Single();
            user.Id = Id;

            return true;
        }
    }
}
