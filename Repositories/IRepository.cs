using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Data.SqlClient;

namespace sql_employee_graphql_api.Repositories
{
    public interface IRepository<T> where T : class{
        T Get(int id);

        T Get(string procedureName, SqlParameter param);

        List<T> GetAll(string procedureName);
    }
}