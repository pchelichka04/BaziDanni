using System.Data;
using BaziDanni_k.p_.Repositories.Common;
using Oracle.ManagedDataAccess.Client;

namespace BaziDanni_k.p_.Repositories.chlen;

public sealed class ChlenRepository(string connectionString) : IRepository
{
    private static readonly string[] Columns = ["N_chlen", "Ime_chlen", "EGN", "Telefon", "Adres"];

    public DataTable GetAll() => RepositoryGuard.Query(connectionString,
        "SELECT N_chlen, Ime_chlen, EGN, Telefon, Adres FROM chlen ORDER BY N_chlen");

    public void Insert(Dictionary<string, object?> values)
    {
        var sql = $"INSERT INTO chlen ({string.Join(", ", Columns)}) VALUES ({string.Join(", ", Columns.Select(column => $":{column}"))})";
        RepositoryGuard.Execute(connectionString, sql, command => AddParameters(command, values), "Добавяне в CHLEN");
    }

    public void Update(Dictionary<string, object?> values)
    {
        const string sql = "UPDATE chlen SET Ime_chlen = :Ime_chlen, EGN = :EGN, Telefon = :Telefon, Adres = :Adres WHERE N_chlen = :N_chlen";
        RepositoryGuard.Execute(connectionString, sql, command => AddParameters(command, values), "Редакция в CHLEN", requireAffectedRow: true);
    }

    public void Delete(object key)
    {
        const string sql = "DELETE FROM chlen WHERE N_chlen = :p_key";
        RepositoryGuard.Execute(connectionString, sql, command => command.Parameters.Add(":p_key", key), "Изтриване от CHLEN", requireAffectedRow: true);
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
