using Dapper;
using Pusdafi_Dev.Interface;
using Pusdafi_Dev.Models;
using Pusdafi_Dev.Models.Data;
using Pusdafi_Dev.ViewModels.ContentViewModels;

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

        public async Task<IEnumerable<ContentVM>> getEditContent(int id)
        {
            var db = _dbContext.CreateConnection();
            string sql = @"select c.id,sc.Category_id as categoryId ,c.sub_category_id as subCategoryId,c.caption,c.judul,c.sub_content as subContent,c.description,c.image
from CONTENT c join SUB_CATEGORYS sc 
on sc.Id = c.sub_category_id
where c.id = @Id";

            var result = await db.QueryAsync<ContentVM>(sql,new {Id = id}).ConfigureAwait(false);

            return result.ToList();

        }

        public async Task<IEnumerable<SubCategory>> getSubCategory(int id)
        {
            var db = _dbContext.CreateConnection();

            string sql = @"select Id,Name_sub from SUB_CATEGORYS where Category_id = @catId";

            var result = await db.QueryAsync<SubCategory>(sql,new {catId = id}).ConfigureAwait(false);

            return result.ToList();

        }
    }
}
