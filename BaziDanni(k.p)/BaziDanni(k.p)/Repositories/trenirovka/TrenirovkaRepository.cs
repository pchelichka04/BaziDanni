using System.Data;
using BaziDanni_k.p_.Repositories.Common;
using Oracle.ManagedDataAccess.Client;

namespace BaziDanni_k.p_.Repositories.trenirovka;

public sealed class TrenirovkaRepository(string connectionString) : IRepository
{
    private static readonly string[] Columns = ["N_grupa", "datata", "chas", "N_chlen", "N_den"];

    public DataTable GetAll() => RepositoryGuard.Query(connectionString,
        "SELECT N_grupa, datata, chas, N_chlen, N_den FROM trenirovka ORDER BY N_grupa");

    public void Insert(Dictionary<string, object?> values)
    {
        var sql = $"INSERT INTO trenirovka ({string.Join(", ", Columns)}) VALUES ({string.Join(", ", Columns.Select(column => $":{column}"))})";
        RepositoryGuard.Execute(connectionString, sql, command => AddParameters(command, values), "Добавяне в TRENIROVKA");
    }

    public void Update(Dictionary<string, object?> values)
    {
        const string sql = "UPDATE trenirovka SET datata = :datata, chas = :chas, N_chlen = :N_chlen, N_den = :N_den WHERE N_grupa = :N_grupa";
        RepositoryGuard.Execute(connectionString, sql, command => AddParameters(command, values), "Редакция в TRENIROVKA", requireAffectedRow: true);
    }

    public void Delete(object key)
    {
        const string sql = "DELETE FROM trenirovka WHERE N_grupa = :p_key";
        RepositoryGuard.Execute(connectionString, sql, command => command.Parameters.Add(":p_key", key), "Изтриване от TRENIROVKA", requireAffectedRow: true);
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
