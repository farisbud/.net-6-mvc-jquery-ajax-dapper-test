using Dapper;
using Pusdafi_Dev.Interface;
using Pusdafi_Dev.Models;
using Pusdafi_Dev.Models.Data;
using Pusdafi_Dev.ViewModels.SubCategoryVM;

namespace Pusdafi_Dev.Repository
{
    public class SubCategoryRepo : SubCategoryIntf
    {
        private readonly DapperDBContext _dbContext;

        public SubCategoryRepo(DapperDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(SubCategory sub)
        {
            var db = _dbContext.CreateConnection();

            string sql = @"Insert Into SUB_CATEGORYS (Category_id,Name_sub,created_at) values(@catId, @nameSub,@created);" + "Select CAST(SCOPE_IDENTITY() as int);";
            var idSub = db.Query<int>(sql, new
            {
                @catId = sub.Category_id,
                @nameSub = sub.Name_sub,
                @created = DateTime.Now
            }).Single();

            sub.Id = idSub;

            return true;
        }

        public bool Delete(int id)
        {
            var db = _dbContext.CreateConnection();

            string sql = @"delete SUB_CATEGORYS where Id = @subId";
            
            db.ExecuteAsync(sql, new 
            { 
                @subId = id
            });

            return true;
        }
       
        public async Task<IList<SubCategoryDtVM?>> getAll()
        {
            var db = _dbContext.CreateConnection();
            //string sql = @"select c.Id, c.Name_cat,sc.Id, sc.Category_id, sc.Name_sub from CATEGORYS c LEFT JOIN SUB_CATEGORYS sc on sc.Category_id = c.Id";

            string sql = @"select c.Id, c.Name_cat as nameCat,COUNT(sc.Id) AS SubCount from CATEGORYS c LEFT JOIN SUB_CATEGORYS sc on sc.Category_id = c.Id GROUP BY c.Id,c.Name_Cat";
            var result = await db.QueryAsync<SubCategoryDtVM>(sql).ConfigureAwait(false);


            return result.ToList();
        }

        public async Task<IEnumerable<SubCategory>> getAllById(int id)
        {
            var db = _dbContext.CreateConnection();
           
            string sql = @"select Id, Category_id, Name_sub from SUB_CATEGORYS sc where Category_id = @catId";
            var result = await db.QueryAsync<SubCategory>(sql, new { catId = id}).ConfigureAwait(false);

            return result.ToList();
            //throw new NotImplementedException();
        }

        public async Task<Category> getByCategoryId(int id)
        {
            var db = _dbContext.CreateConnection();

            var sql = "select Id,Name_cat from CATEGORYS where Id = @catId";

            var result = await db.QueryAsync<Category>(sql,new { catId = id }).ConfigureAwait(false);

            return result.Single();

        }

        public Task<SubCategory> getByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> getCategory()
        {
            var db = _dbContext.CreateConnection();
            string sql = @"select Id,Name_cat from CATEGORYS ";
            var result = await db.QueryAsync<Category>(sql).ConfigureAwait(false);
            return result.ToList();
        }

        public async Task<SubCategory> getBySubId(int id)
        {
            var db = _dbContext.CreateConnection();

            string sql = @"select * from SUB_CATEGORYS where Id = @subId";

            var result = await db.QueryAsync<SubCategory>(sql, new { subId = id }).ConfigureAwait (false);

            return result.Single();
        }

        public bool Update(SubCategory sub)
        {
            var db = _dbContext.CreateConnection();

            string sql = @"update SUB_CATEGORYS set Category_id = @catId, Name_sub = @name where Id = @subId";

             db.ExecuteAsync(sql, new 
            {
                @catId = sub.Category_id,
                @name = sub.Name_sub,
                @subId = sub.Id
            });

            return true;
        }

      
    }
}
