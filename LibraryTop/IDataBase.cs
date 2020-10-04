using System.Data;

namespace LibraryTop
{
    internal interface IDataBase
    {
        DataTable Select(string query);
        DataTable SelectAll(string nameTable);
        DataTable SelectSomeColumns(string nameTable, params string[] columns);
        string Update(string query);
        string Delete(string query);
        string Insert(string query);
    }
}
