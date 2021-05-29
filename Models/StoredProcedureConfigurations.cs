using System.Collections.Generic;

namespace sql_employee_graphql_api.Models
{
    public class StoredProcedureConfigurations : IStoredProcedureConfigurations
    {
        public StoredProcedureConfigurationEntity[] Entities { get; set; }
    }
}