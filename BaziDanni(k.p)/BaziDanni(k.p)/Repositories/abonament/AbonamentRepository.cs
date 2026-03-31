using System.Data;
using BaziDanni_k.p_.Repositories.Common;
using Oracle.ManagedDataAccess.Client;

namespace BaziDanni_k.p_.Repositories.abonament;

public sealed class AbonamentRepository(string connectionString) : IRepository
{
    private static readonly string[] Columns = ["N_abonament", "Period_meseci", "Cena_lv"];

    public DataTable GetAll() => RepositoryGuard.Query(connectionString,
        "SELECT N_abonament, Period_meseci, Cena_lv FROM abonament ORDER BY N_abonament");

    public void Insert(Dictionary<string, object?> values)
    {
        var sql = $"INSERT INTO abonament ({string.Join(", ", Columns)}) VALUES ({string.Join(", ", Columns.Select(column => $":{column}"))})";
        RepositoryGuard.Execute(connectionString, sql, command => AddParameters(command, values), "Добавяне в ABONAMENT");
    }

    public void Update(Dictionary<string, object?> values)
    {
        const string sql = "UPDATE abonament SET Period_meseci = :Period_meseci, Cena_lv = :Cena_lv WHERE N_abonament = :N_abonament";
        RepositoryGuard.Execute(connectionString, sql, command => AddParameters(command, values), "Редакция в ABONAMENT", requireAffectedRow: true);
    }

    public void Delete(object key)
    {
        const string sql = "DELETE FROM abonament WHERE N_abonament = :p_key";
        RepositoryGuard.Execute(connectionString, sql, command => command.Parameters.Add(":p_key", key), "Изтриване от ABONAMENT", requireAffectedRow: true);
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
