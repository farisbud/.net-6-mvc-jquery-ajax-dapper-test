using Dapper;
using Pusdafi_Dev.Interface;
using Pusdafi_Dev.Models;
using Pusdafi_Dev.Models.Data;
using Pusdafi_Dev.ViewModels.SubCategoryVM;
using System.Text;

namespace Pusdafi_Dev.Services
{
    public class SubCategoryDataSVC : SubCategoryDataIntf
    {
        private readonly DapperDBContext _dbcontext;

        public SubCategoryDataSVC(DapperDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public Dictionary<string, object> indexDataTable()
        {
            var resEnkrip = new Dictionary<string, object>();
            var res = new Dictionary<string, object>();

            try
            {
                var db = _dbcontext.CreateConnection();

                string sql = @"select c.Id, c.Name_cat,COUNT(sc.Id) AS SubCount from CATEGORYS c LEFT JOIN SUB_CATEGORYS sc on sc.Category_id = c.Id GROUP BY c.Id,c.Name_Cat";
                var result = db.Query<SubCategoryDtVM>(sql).ToList();

                List<Dictionary<string, object>> listField = new List<Dictionary<string, object>>();
                if (result != null)
                {

                    //foreach (var item in result)
                    //{
                    //        var aksiHtml = new StringBuilder("<div class=\"project-actions text-center\">");
                    //        aksiHtml.Append("<a href=\"SubCategory/view/" + item?.Id + " \" class=\"btn btn-info btn-sm\">");
                    //        aksiHtml.Append("<i class=\"fas fa-folder\"></i> view</a>");
                    //        aksiHtml.Append("</div>");

                    //    var isPanel = new Dictionary<string, object>();
                    //    //var table = new Dictionary<string, object>();
                        
                    //    isPanel["id"] = item?.Id;
                    //    isPanel["nameCat"] = item?.Name_cat;
                    //    isPanel["jumlah"] = item?.SubCount;
                    //    isPanel["aksi"] = aksiHtml.ToString();

                    //    listField.Add(isPanel);
                    //}

                };
                res["data"] = listField;

                resEnkrip = res;
            }
            catch (Exception ex)
            {
                resEnkrip.Add("status", "0");
                resEnkrip.Add("message", ex.Message.ToString());
                return resEnkrip;
            }


            return resEnkrip;

            //throw new NotImplementedException();
        }

        public Dictionary<string, object> indexSubDataTable(int id)
        {
            var resEnkrip = new Dictionary<string, object>();
            var res = new Dictionary<string, object>();

            try
            {
                var db = _dbcontext.CreateConnection();

                string sql = @"select c.Id, c.Name_cat,COUNT(sc.Id) AS SubCount from CATEGORYS c LEFT JOIN SUB_CATEGORYS sc on sc.Category_id = c.Id GROUP BY c.Id,c.Name_Cat";
                var result = db.Query<SubCategoryDtVM>(sql).ToList();

                List<Dictionary<string, object>> listField = new List<Dictionary<string, object>>();
                if (result != null)
                {

                    //foreach (var item in result)
                    //{
                    //    var aksiHtml = new StringBuilder("<div class=\"project-actions text-center\">");
                    //    aksiHtml.Append("<a href=\"SubCategory/view/" + item?.Id + " \" class=\"btn btn-info btn-sm\">");
                    //    aksiHtml.Append("<i class=\"fas fa-folder\"></i> view</a>");
                    //    aksiHtml.Append("</div>");

                    //    var isPanel = new Dictionary<string, object>();
                    //    //var table = new Dictionary<string, object>();

                    //    isPanel["id"] = item?.Id;
                    //    isPanel["nameCat"] = item?.Name_cat;
                    //    isPanel["jumlah"] = item?.SubCount;
                    //    isPanel["aksi"] = aksiHtml.ToString();

                    //    listField.Add(isPanel);
                    //}

                };
                res["data"] = listField;

                resEnkrip = res;
            }
            catch (Exception ex)
            {
                resEnkrip.Add("status", "0");
                resEnkrip.Add("message", ex.Message.ToString());
                return resEnkrip;
            }


            return resEnkrip;

            //throw new NotImplementedException();
        }


    }
}
