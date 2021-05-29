using System.Collections.Generic;

namespace sql_employee_graphql_api.Models
{
    public interface IStoredProcedureConfigurations
    {
        StoredProcedureConfigurationEntity[] Entities { get; set; }
    }
}