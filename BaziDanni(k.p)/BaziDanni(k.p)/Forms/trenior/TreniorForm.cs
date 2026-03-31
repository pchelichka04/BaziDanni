using System.Data;
using BaziDanni_k.p_.Repositories.trenior;
using BaziDanni_k.p_.Infrastructure;

namespace BaziDanni_k.p_.Forms.trenior;

public sealed class TreniorForm : Form
{
    private readonly TreniorRepository _repository;
    private readonly DataGridView _grid = new() { Dock = DockStyle.Fill, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
    private readonly TextBox _txtId = new() { Width = 100 };
    private readonly TextBox _txtName = new() { Width = 220 };
    private readonly TextBox _txtSportId = new() { Width = 120 };
    private readonly MaskedTextBox _txtPhone = new("0000-000-000") { Width = 130 };

    public TreniorForm(string cs)
    {
        Text = "Управление: TRENIOR";
        Width = 980;
        Height = 560;
        _repository = new TreniorRepository(cs);

        BuildUi();
        LoadData();
    }

    private void BuildUi()
    {
        var top = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, Padding = new Padding(10) };

        top.Controls.Add(CreateLabeled("Номер", _txtId));
        top.Controls.Add(CreateLabeled("Име на треньор", _txtName));
        top.Controls.Add(CreateLabeled("Номер спорт", _txtSportId));
        top.Controls.Add(CreateLabeled("Телефон", _txtPhone));

        var btnAdd = new Button { Text = "Добави" };
        var btnEdit = new Button { Text = "Редактирай" };
        var btnDelete = new Button { Text = "Изтрий" };

        btnAdd.Click += (_, _) => { _repository.Insert(GetValues()); LoadData(); };
        btnEdit.Click += (_, _) => { _repository.Update(GetValues()); LoadData(); };
        btnDelete.Click += (_, _) => { _repository.Delete(_txtId.Text.Trim()); LoadData(); };
        _grid.SelectionChanged += (_, _) => BindSelected();

        top.Controls.Add(btnAdd);
        top.Controls.Add(btnEdit);
        top.Controls.Add(btnDelete);

        Controls.Add(_grid);
        Controls.Add(top);

        UiStyler.MakeButtonsMoreVisible(this);
    }

    private static Panel CreateLabeled(string label, Control control)
    {
        var wrapper = new Panel { Width = control.Width + 8, Height = 52 };
        wrapper.Controls.Add(new Label { Text = label, Dock = DockStyle.Top, Height = 20 });
        control.Top = 22;
        wrapper.Controls.Add(control);
        return wrapper;
    }

    private Dictionary<string, object?> GetValues() => new()
    {
        ["N_trenior"] = _txtId.Text.Trim(),
        ["Ime_trenior"] = _txtName.Text.Trim(),
        ["N_sport"] = _txtSportId.Text.Trim(),
        ["Telefon_trenior"] = _txtPhone.Text.Trim()
    };

    private void LoadData() => _grid.DataSource = _repository.GetAll();

    private void BindSelected()
    {
        if (_grid.CurrentRow?.DataBoundItem is not DataRowView row) return;
        _txtId.Text = row["N_trenior"]?.ToString() ?? string.Empty;
        _txtName.Text = row["Ime_trenior"]?.ToString() ?? string.Empty;
        _txtSportId.Text = row["N_sport"]?.ToString() ?? string.Empty;
        _txtPhone.Text = row["Telefon_trenior"]?.ToString() ?? string.Empty;
    }
}
