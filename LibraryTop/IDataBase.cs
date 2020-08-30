using System.Data;

namespace LibraryTop
{
    interface IDataBase
    {
        DataTable Select(string query);
        string Update(string query);
        string Delete(string query);
        string Insert(string query);
    }
}
