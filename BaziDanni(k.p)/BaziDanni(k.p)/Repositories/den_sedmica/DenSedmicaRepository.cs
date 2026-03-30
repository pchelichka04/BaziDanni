using System.Data;
using BaziDanni_k.p_.Repositories.Common;
using Oracle.ManagedDataAccess.Client;

namespace BaziDanni_k.p_.Repositories.den_sedmica;

public sealed class DenSedmicaRepository(string connectionString) : IRepository
{
    private static readonly string[] Columns = ["N_den", "Den", "Cvyat"];

    public DataTable GetAll()
    {
        const string sql = "SELECT N_den, Den, Cvyat FROM den_sedmica ORDER BY N_den";

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
        var sql = $"INSERT INTO den_sedmica ({columnNames}) VALUES ({parameterNames})";

        using var connection = new OracleConnection(connectionString);
        connection.Open();

        using var command = new OracleCommand(sql, connection);
        AddParameters(command, values);
        command.ExecuteNonQuery();
    }

    public void Update(Dictionary<string, object?> values)
    {
        const string sql = "UPDATE den_sedmica SET Den = :Den, Cvyat = :Cvyat WHERE N_den = :N_den";

        using var connection = new OracleConnection(connectionString);
        connection.Open();

        using var command = new OracleCommand(sql, connection);
        AddParameters(command, values);
        command.ExecuteNonQuery();
    }

    public void Delete(object key)
    {
        const string sql = "DELETE FROM den_sedmica WHERE N_den = :p_key";

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
