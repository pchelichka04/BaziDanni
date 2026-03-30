using System.Data;
using BaziDanni_k.p_.Repositories.Common;

namespace BaziDanni_k.p_.Forms.Common;

public class EntityManagementForm : Form
{
    private readonly GenericOracleRepository _repository;
    private readonly string _keyColumn;
    private readonly string[] _columns;
    private readonly Dictionary<string, TextBox> _inputs = [];
    private readonly DataGridView _grid = new() { Dock = DockStyle.Fill, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };

    public EntityManagementForm(string title, GenericOracleRepository repository, string keyColumn, params string[] columns)
    {
        Text = title;
        Width = 1100;
        Height = 620;

        _repository = repository;
        _keyColumn = keyColumn;
        _columns = columns;

        BuildUi();
        LoadData();
    }

    private void BuildUi()
    {
        var top = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 130, AutoScroll = true };

        foreach (var column in _columns)
        {
            var txt = new TextBox { Width = 150, PlaceholderText = column };
            _inputs[column] = txt;
            top.Controls.Add(txt);
        }

        var btnAdd = new Button { Text = "Добави" };
        var btnEdit = new Button { Text = "Редактирай" };
        var btnDelete = new Button { Text = "Изтрий" };
        var btnRefresh = new Button { Text = "Обнови" };

        btnAdd.Click += (_, _) => AddRecord();
        btnEdit.Click += (_, _) => UpdateRecord();
        btnDelete.Click += (_, _) => DeleteRecord();
        btnRefresh.Click += (_, _) => LoadData();
        _grid.SelectionChanged += (_, _) => BindSelectedRow();

        top.Controls.Add(btnAdd);
        top.Controls.Add(btnEdit);
        top.Controls.Add(btnDelete);
        top.Controls.Add(btnRefresh);

        Controls.Add(_grid);
        Controls.Add(top);
    }

    private void LoadData() => _grid.DataSource = _repository.GetAll();

    private void AddRecord()
    {
        _repository.Insert(GetValues());
        LoadData();
    }

    private void UpdateRecord()
    {
        _repository.Update(GetValues());
        LoadData();
    }

    private void DeleteRecord()
    {
        var key = _inputs[_keyColumn].Text.Trim();
        _repository.Delete(key);
        LoadData();
    }

    private Dictionary<string, object?> GetValues()
    {
        return _inputs.ToDictionary(x => x.Key, x => (object?)x.Value.Text.Trim());
    }

    private void BindSelectedRow()
    {
        if (_grid.CurrentRow?.DataBoundItem is not DataRowView row)
        {
            return;
        }

        foreach (var col in _columns)
        {
            if (row.Row.Table.Columns.Contains(col))
            {
                _inputs[col].Text = row[col]?.ToString() ?? string.Empty;
            }
        }
    }
}
