using System.Data;
using BaziDanni_k.p_.Repositories.Common;
using Oracle.ManagedDataAccess.Client;

namespace BaziDanni_k.p_.Repositories.trenior;

public sealed class TreniorRepository(string connectionString) : IRepository
{
    private static readonly string[] Columns = ["N_trenior", "Ime_trenior", "N_sport", "Telefon_trenior"];

    public DataTable GetAll() => RepositoryGuard.Query(connectionString,
        "SELECT N_trenior, Ime_trenior, N_sport, Telefon_trenior FROM trenior ORDER BY N_trenior");

    public void Insert(Dictionary<string, object?> values)
    {
        var sql = $"INSERT INTO trenior ({string.Join(", ", Columns)}) VALUES ({string.Join(", ", Columns.Select(column => $":{column}"))})";
        RepositoryGuard.Execute(connectionString, sql, command => AddParameters(command, values), "Добавяне в TRENIOR");
    }

    public void Update(Dictionary<string, object?> values)
    {
        const string sql = "UPDATE trenior SET Ime_trenior = :Ime_trenior, N_sport = :N_sport, Telefon_trenior = :Telefon_trenior WHERE N_trenior = :N_trenior";
        RepositoryGuard.Execute(connectionString, sql, command => AddParameters(command, values), "Редакция в TRENIOR", requireAffectedRow: true);
    }

    public void Delete(object key)
    {
        const string sql = "DELETE FROM trenior WHERE N_trenior = :p_key";
        RepositoryGuard.Execute(connectionString, sql, command => command.Parameters.Add(":p_key", key), "Изтриване от TRENIOR", requireAffectedRow: true);
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
