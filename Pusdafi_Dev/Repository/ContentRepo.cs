using Dapper;
using Pusdafi_Dev.Interface;
using Pusdafi_Dev.Models;
using Pusdafi_Dev.Models.Data;

namespace Pusdafi_Dev.Repository
{
    public class ContentRepo : ContenIntf
    {
        private readonly DapperDBContext _dbContext;

        public ContentRepo(DapperDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<Content>> getAll()
        {
            var db = _dbContext.CreateConnection();

            string sql = @"select id,sub_category_id,caption,judul,sub_content from CONTENT";

            var result = await db.QueryAsync<Content>(sql);

            return result.ToList();

        }
    }
}
