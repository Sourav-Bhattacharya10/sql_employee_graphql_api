using Microsoft.Data.SqlClient;
using sql_employee_graphql_api.Models;
using sql_employee_graphql_api.Repositories;

namespace sql_employee_graphql_api
{
    public class Query<T> : IQuery<T> where T : class
    {
        private readonly IRepository<T> _repository;

        // private readonly IStoredProcedureConfigurationEntity _storedProcedureConfigurationEntity;
        
        public Query(IRepository<T> empRepo, IStoredProcedureConfigurations spConfigs){
            _repository = empRepo;
            // _storedProcedureConfigurationEntity = spConfigs.Entities
        }

        public T Get(int id){
            T foundEntity = null;

            try
            {
                var param = new SqlParameter("@EmployeeID", id);
                foundEntity = _repository.Get("GetEmployee @EmployeeID", param);
            }
            catch (System.Exception)
            {
                foundEntity = null;
            }

            return foundEntity;
        }
    }
}