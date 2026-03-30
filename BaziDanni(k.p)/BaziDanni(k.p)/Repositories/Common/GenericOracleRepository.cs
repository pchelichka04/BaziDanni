using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace BaziDanni_k.p_.Repositories.Common;

public class GenericOracleRepository
{
    private readonly string _connectionString;
    private readonly string _tableName;
    private readonly string[] _columns;
    private readonly string _keyColumn;

    public GenericOracleRepository(string connectionString, string tableName, string keyColumn, params string[] columns)
    {
        _connectionString = connectionString;
        _tableName = tableName;
        _columns = columns;
        _keyColumn = keyColumn;
    }

    public DataTable GetAll()
    {
        var sql = $"SELECT {string.Join(", ", _columns)} FROM {_tableName} ORDER BY {_keyColumn}";
        using var conn = new OracleConnection(_connectionString);
        using var cmd = new OracleCommand(sql, conn);
        using var adapter = new OracleDataAdapter(cmd);
        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    public void Insert(Dictionary<string, object?> values)
    {
        var cols = string.Join(", ", values.Keys);
        var pars = string.Join(", ", values.Keys.Select(k => ":" + k));
        var sql = $"INSERT INTO {_tableName} ({cols}) VALUES ({pars})";

        using var conn = new OracleConnection(_connectionString);
        conn.Open();
        using var cmd = new OracleCommand(sql, conn);
        AddParameters(cmd, values);
        cmd.ExecuteNonQuery();
    }

    public void Update(Dictionary<string, object?> values)
    {
        var setClause = string.Join(", ", values.Keys.Where(k => k != _keyColumn).Select(k => $"{k}=:{k}"));
        var sql = $"UPDATE {_tableName} SET {setClause} WHERE {_keyColumn} = :{_keyColumn}";

        using var conn = new OracleConnection(_connectionString);
        conn.Open();
        using var cmd = new OracleCommand(sql, conn);
        AddParameters(cmd, values);
        cmd.ExecuteNonQuery();
    }

    public void Delete(object key)
    {
        var sql = $"DELETE FROM {_tableName} WHERE {_keyColumn} = :p_key";
        using var conn = new OracleConnection(_connectionString);
        conn.Open();
        using var cmd = new OracleCommand(sql, conn);
        cmd.Parameters.Add(":p_key", key);
        cmd.ExecuteNonQuery();
    }

    private static void AddParameters(OracleCommand cmd, Dictionary<string, object?> values)
    {
        foreach (var pair in values)
        {
            cmd.Parameters.Add(":" + pair.Key, pair.Value ?? DBNull.Value);
        }
    }
}
