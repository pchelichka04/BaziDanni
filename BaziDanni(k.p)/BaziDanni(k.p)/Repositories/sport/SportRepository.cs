using System.Data;
using BaziDanni_k.p_.Repositories.Common;
using Oracle.ManagedDataAccess.Client;

namespace BaziDanni_k.p_.Repositories.sport;

public sealed class SportRepository(string connectionString) : IRepository
{
    private static readonly string[] Columns = ["N_sport", "Ime_sport", "Cvyat"];

    public DataTable GetAll() => RepositoryGuard.Query(connectionString,
        "SELECT N_sport, Ime_sport, Cvyat FROM sport ORDER BY N_sport");

    public void Insert(Dictionary<string, object?> values)
    {
        var sql = $"INSERT INTO sport ({string.Join(", ", Columns)}) VALUES ({string.Join(", ", Columns.Select(column => $":{column}"))})";
        RepositoryGuard.Execute(connectionString, sql, command => AddParameters(command, values), "Добавяне в SPORT");
    }

    public void Update(Dictionary<string, object?> values)
    {
        const string sql = "UPDATE sport SET Ime_sport = :Ime_sport, Cvyat = :Cvyat WHERE N_sport = :N_sport";
        RepositoryGuard.Execute(connectionString, sql, command => AddParameters(command, values), "Редакция в SPORT", requireAffectedRow: true);
    }

    public void Delete(object key)
    {
        const string sql = "DELETE FROM sport WHERE N_sport = :p_key";
        RepositoryGuard.Execute(connectionString, sql, command => command.Parameters.Add(":p_key", key), "Изтриване от SPORT", requireAffectedRow: true);
    }

    private static void AddParameters(OracleCommand command, IReadOnlyDictionary<string, object?> values)
    {
        foreach (var column in Columns)
        {
            if (!values.TryGetValue(column, out var value))
            {
                throw new ArgumentException($"Missing required value for column '{column}'.", nameof(values));
            }

            command.Parameters.Add($":{column}", value ?? DBNull.Value);
        }
    }
}
