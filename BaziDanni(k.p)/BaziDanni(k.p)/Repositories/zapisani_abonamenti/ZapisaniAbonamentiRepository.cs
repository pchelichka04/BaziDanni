using System.Data;
using BaziDanni_k.p_.Repositories.Common;
using Oracle.ManagedDataAccess.Client;

namespace BaziDanni_k.p_.Repositories.zapisani_abonamenti;

public sealed class ZapisaniAbonamentiRepository(string connectionString) : IRepository
{
    private static readonly string[] Columns = ["N_chlen", "N_grupa", "N_abonament", "Data_zapis"];

    public DataTable GetAll() => RepositoryGuard.Query(connectionString,
        "SELECT N_chlen, N_grupa, N_abonament, Data_zapis FROM zapisani_abonamenti ORDER BY N_chlen");

    public void Insert(Dictionary<string, object?> values)
    {
        var sql = $"INSERT INTO zapisani_abonamenti ({string.Join(", ", Columns)}) VALUES ({string.Join(", ", Columns.Select(column => $":{column}"))})";
        RepositoryGuard.Execute(connectionString, sql, command => AddParameters(command, values), "Добавяне в ZAPISANI_ABONAMENTI");
    }

    public void Update(Dictionary<string, object?> values)
    {
        const string sql = "UPDATE zapisani_abonamenti SET N_grupa = :N_grupa, N_abonament = :N_abonament, Data_zapis = :Data_zapis WHERE N_chlen = :N_chlen";
        RepositoryGuard.Execute(connectionString, sql, command => AddParameters(command, values), "Редакция в ZAPISANI_ABONAMENTI", requireAffectedRow: true);
    }

    public void Delete(object key)
    {
        const string sql = "DELETE FROM zapisani_abonamenti WHERE N_chlen = :p_key";
        RepositoryGuard.Execute(connectionString, sql, command => command.Parameters.Add(":p_key", key), "Изтриване от ZAPISANI_ABONAMENTI", requireAffectedRow: true);
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
