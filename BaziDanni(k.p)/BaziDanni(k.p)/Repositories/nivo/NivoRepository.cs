using System.Data;
using BaziDanni_k.p_.Repositories.Common;
using Oracle.ManagedDataAccess.Client;

namespace BaziDanni_k.p_.Repositories.nivo;

public sealed class NivoRepository(string connectionString) : IRepository
{
    private static readonly string[] Columns = ["N_nivo", "Ime_nivo", "Cvyat"];

    public DataTable GetAll()
    {
        const string sql = "SELECT N_nivo, Ime_nivo, Cvyat FROM nivo ORDER BY N_nivo";

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
        var sql = $"INSERT INTO nivo ({columnNames}) VALUES ({parameterNames})";

        using var connection = new OracleConnection(connectionString);
        connection.Open();

        using var command = new OracleCommand(sql, connection);
        AddParameters(command, values);
        command.ExecuteNonQuery();
    }

    public void Update(Dictionary<string, object?> values)
    {
        const string sql = "UPDATE nivo SET Ime_nivo = :Ime_nivo, Cvyat = :Cvyat WHERE N_nivo = :N_nivo";

        using var connection = new OracleConnection(connectionString);
        connection.Open();

        using var command = new OracleCommand(sql, connection);
        AddParameters(command, values);
        command.ExecuteNonQuery();
    }

    public void Delete(object key)
    {
        const string sql = "DELETE FROM nivo WHERE N_nivo = :p_key";

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
