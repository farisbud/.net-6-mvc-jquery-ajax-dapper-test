namespace Pusdafi_Dev.Interface
{
    public interface SubCategoryDataIntf
    {
        Dictionary<string, object> indexDataTable();
        Dictionary<string, object> indexSubDataTable(int id);
    }
}
