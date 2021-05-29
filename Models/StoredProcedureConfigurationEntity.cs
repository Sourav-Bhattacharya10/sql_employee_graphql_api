namespace sql_employee_graphql_api.Models
{
    public class StoredProcedureConfigurationEntity : IStoredProcedureConfigurationEntity
    {
        public string Name { get; set; }
        public string Get { get; set; }
        public string GetAll { get; set;}
        public string Create { get; set; }
        public string Update { get; set; }
        public string Delete { get; set; }
    }
}