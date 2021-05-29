using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using sql_employee_graphql_api.Models;

namespace sql_employee_graphql_api.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly WorkDBContext _dbContext;
        private DbSet<T> _dbSet;

        private readonly string _connectionString;

        public Repository(WorkDBContext dBContext)
        {
            _dbContext = dBContext;
            _dbSet = _dbContext.Set<T>();
            _connectionString = dBContext.Database.GetDbConnection().ConnectionString;
        }
        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public T Get(string procedureName, SqlParameter param)
        {
            return _dbSet.FromSqlRaw<T>(procedureName, param).AsEnumerable().FirstOrDefault();
        }

        public List<T> GetAll(string procedureName)
        {
            return _dbSet.FromSqlRaw<T>(procedureName).ToList();
        }
    }
}