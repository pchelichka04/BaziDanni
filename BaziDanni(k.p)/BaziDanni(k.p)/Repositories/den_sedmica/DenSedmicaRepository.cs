using System.Data;
using BaziDanni_k.p_.Repositories.Common;
using Oracle.ManagedDataAccess.Client;

namespace BaziDanni_k.p_.Repositories.den_sedmica;

public sealed class DenSedmicaRepository(string connectionString) : IRepository
{
    private static readonly string[] Columns = ["N_den", "Den", "Cvyat"];

    public DataTable GetAll() => RepositoryGuard.Query(connectionString,
        "SELECT N_den, Den, Cvyat FROM den_sedmica ORDER BY N_den");

    public void Insert(Dictionary<string, object?> values)
    {
        var sql = $"INSERT INTO den_sedmica ({string.Join(", ", Columns)}) VALUES ({string.Join(", ", Columns.Select(column => $":{column}"))})";
        RepositoryGuard.Execute(connectionString, sql, command => AddParameters(command, values), "Добавяне в DEN_SEDMICA");
    }

    public void Update(Dictionary<string, object?> values)
    {
        const string sql = "UPDATE den_sedmica SET Den = :Den, Cvyat = :Cvyat WHERE N_den = :N_den";
        RepositoryGuard.Execute(connectionString, sql, command => AddParameters(command, values), "Редакция в DEN_SEDMICA", requireAffectedRow: true);
    }

    public void Delete(object key)
    {
        const string sql = "DELETE FROM den_sedmica WHERE N_den = :p_key";
        RepositoryGuard.Execute(connectionString, sql, command => command.Parameters.Add(":p_key", key), "Изтриване от DEN_SEDMICA", requireAffectedRow: true);
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
