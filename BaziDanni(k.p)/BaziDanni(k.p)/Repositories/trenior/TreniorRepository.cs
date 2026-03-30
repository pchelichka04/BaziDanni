using System.Data;
using BaziDanni_k.p_.Repositories.Common;
using Oracle.ManagedDataAccess.Client;

namespace BaziDanni_k.p_.Repositories.trenior;

public sealed class TreniorRepository(string connectionString) : IRepository
{
    private static readonly string[] Columns = ["N_trenior", "Ime_trenior", "N_sport", "Telefon_trenior"];

    public DataTable GetAll()
    {
        const string sql = "SELECT N_trenior, Ime_trenior, N_sport, Telefon_trenior FROM trenior ORDER BY N_trenior";

        using var connection = new OracleConnection(connectionString);
        using var command = new OracleCommand(sql, connection);
        using var adapter = new OracleDataAdapter(command);

        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    public void Insert(Dictionary<string, object?> values)
    {
        var columnNames = string.Join(", ", Columns);
        var parameterNames = string.Join(", ", Columns.Select(column => $":{column}"));
        var sql = $"INSERT INTO trenior ({columnNames}) VALUES ({parameterNames})";

        using var connection = new OracleConnection(connectionString);
        connection.Open();

        using var command = new OracleCommand(sql, connection);
        AddParameters(command, values);
        command.ExecuteNonQuery();
    }

    public void Update(Dictionary<string, object?> values)
    {
        const string sql = "UPDATE trenior SET Ime_trenior = :Ime_trenior, N_sport = :N_sport, Telefon_trenior = :Telefon_trenior WHERE N_trenior = :N_trenior";

        using var connection = new OracleConnection(connectionString);
        connection.Open();

        using var command = new OracleCommand(sql, connection);
        AddParameters(command, values);
        command.ExecuteNonQuery();
    }

    public void Delete(object key)
    {
        const string sql = "DELETE FROM trenior WHERE N_trenior = :p_key";

        using var connection = new OracleConnection(connectionString);
        connection.Open();

        using var command = new OracleCommand(sql, connection);
        command.Parameters.Add(":p_key", key);
        command.ExecuteNonQuery();
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
