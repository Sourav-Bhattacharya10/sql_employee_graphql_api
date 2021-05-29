namespace sql_employee_graphql_api.Models
{
    public interface IStoredProcedureConfigurationEntity
    {
        string Name { get; set; }
        string Get { get; set; }
        string GetAll { get; set; }
        string Create { get; set; }
        string Update { get; set; }
        string Delete { get; set; }
    }
}