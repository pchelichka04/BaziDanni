using System.Data;
using BaziDanni_k.p_.Repositories.Common;
using Oracle.ManagedDataAccess.Client;

namespace BaziDanni_k.p_.Repositories.nivo;

public sealed class NivoRepository(string connectionString) : IRepository
{
    private static readonly string[] Columns = ["N_nivo", "Ime_nivo", "Cvyat"];

    public DataTable GetAll() => RepositoryGuard.Query(connectionString,
        "SELECT N_nivo, Ime_nivo, Cvyat FROM nivo ORDER BY N_nivo");

    public void Insert(Dictionary<string, object?> values)
    {
        var sql = $"INSERT INTO nivo ({string.Join(", ", Columns)}) VALUES ({string.Join(", ", Columns.Select(column => $":{column}"))})";
        RepositoryGuard.Execute(connectionString, sql, command => AddParameters(command, values), "Добавяне в NIVO");
    }

    public void Update(Dictionary<string, object?> values)
    {
        const string sql = "UPDATE nivo SET Ime_nivo = :Ime_nivo, Cvyat = :Cvyat WHERE N_nivo = :N_nivo";
        RepositoryGuard.Execute(connectionString, sql, command => AddParameters(command, values), "Редакция в NIVO", requireAffectedRow: true);
    }

    public void Delete(object key)
    {
        const string sql = "DELETE FROM nivo WHERE N_nivo = :p_key";
        RepositoryGuard.Execute(connectionString, sql, command => command.Parameters.Add(":p_key", key), "Изтриване от NIVO", requireAffectedRow: true);
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
