using sql_employee_graphql_api.Models;

namespace sql_employee_graphql_api
{
    public interface IQuery<T> where T : class
    {
        T Get(int id);
    }
}