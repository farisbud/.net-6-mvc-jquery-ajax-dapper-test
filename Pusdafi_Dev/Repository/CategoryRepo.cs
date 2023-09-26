using Dapper;
using Pusdafi_Dev.Interface;
using Pusdafi_Dev.Models;
using Pusdafi_Dev.Models.Data;

namespace Pusdafi_Dev.Repository
{
    public class CategoryRepo : CategoryIntf
    {
        private readonly DapperDBContext dbContext;

        public CategoryRepo (DapperDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> getAll()
        {
            var db = dbContext.CreateConnection();
            string sql = "select * from CATEGORYS order by Id desc";
            // var result = await db.QueryAsync<Category>(sql).ConfigureAwait(false);

            IEnumerable<Category> categories = await db.QueryAsync<Category>(sql).ConfigureAwait(false);

            return categories.ToList();

        }

      

        public bool Add(Category category)
        {
            var db = dbContext.CreateConnection();
            string sql = @"insert into CATEGORYS (Name_cat,created_at) values (@name, @created);" + "Select CAST(SCOPE_IDENTITY() as int);";

            var id = db.Query<int>(sql, new
            {
                @name = category.Name_cat,
                @created = DateTime.Now

            }).Single();

            category.Id = id;

            return true;
        }

        public async Task<Category> getByIdAsync(int id)
        {
            var db = dbContext.CreateConnection();
            string sql = @"select * from CATEGORYS where Id = @catId";

            var result = await db.QueryAsync<Category>(sql, new { catId = id }).ConfigureAwait(false);

            return result.FirstOrDefault();

        }

        public bool Update(Category category)
        {
            var db = dbContext.CreateConnection();
            string sql = @"update CATEGORYS set Name_cat=@name, updated_at = @updated where Id = @catId";
           
            db.Execute(sql, new
            {
                @name = category.Name_cat,
                @updated = DateTime.Now,
                @catId = category.Id
            });

            return true;
        }

        public bool Delete(int id)
        {
            var db = dbContext.CreateConnection();
            string sql = @"delete CATEGORYS where Id = @catId";

            //db.Execute(sql, new { catId = id });
            db.Query<Category>(sql, new { catId = id });
            
            return true;
        }
    }
}
