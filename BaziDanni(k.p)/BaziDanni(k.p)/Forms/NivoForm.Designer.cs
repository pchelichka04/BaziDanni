namespace BaziDanni_k.p_.Forms;
partial class NivoForm
{
    private System.ComponentModel.IContainer? components = null;
    protected override void Dispose(bool disposing){ if (disposing && components!=null) components.Dispose(); base.Dispose(disposing);}
    private void InitializeComponent()
    {
        _grid = new DataGridView();
        _txtId = new TextBox();
        _txtName = new TextBox();
        _btnColor = new Button();
        _txtColor = new TextBox();
        _btnAdd = new Button();
        _btnEdit = new Button();
        _btnDelete = new Button();
        _lblId = new Label();
        _lblName = new Label();
        _lblColor = new Label();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        SuspendLayout();
        // 
        // _grid
        // 
        _grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _grid.ColumnHeadersHeight = 29;
        _grid.Location = new Point(12, 100);
        _grid.Name = "_grid";
        _grid.ReadOnly = true;
        _grid.RowHeadersWidth = 51;
        _grid.Size = new Size(926, 428);
        _grid.TabIndex = 0;
        _grid.SelectionChanged += Grid_SelectionChanged;
        // 
        // _txtId
        // 
        _txtId.Location = new Point(12, 38);
        _txtId.Name = "_txtId";
        _txtId.PlaceholderText = "N_nivo";
        _txtId.Size = new Size(120, 27);
        _txtId.TabIndex = 9;
        // 
        // _txtName
        // 
        _txtName.Location = new Point(152, 38);
        _txtName.Name = "_txtName";
        _txtName.PlaceholderText = "Ime_nivo";
        _txtName.Size = new Size(220, 27);
        _txtName.TabIndex = 7;
        // 
        // _btnColor
        // 
        _btnColor.Location = new Point(392, 36);
        _btnColor.Name = "_btnColor";
        _btnColor.Size = new Size(120, 23);
        _btnColor.TabIndex = 6;
        _btnColor.Text = "Избери цвят";
        _btnColor.Click += BtnColor_Click;
        // 
        // _txtColor
        // 
        _txtColor.Location = new Point(532, 38);
        _txtColor.Name = "_txtColor";
        _txtColor.ReadOnly = true;
        _txtColor.Size = new Size(120, 27);
        _txtColor.TabIndex = 4;
        // 
        // _btnAdd
        // 
        _btnAdd.Location = new Point(672, 36);
        _btnAdd.Name = "_btnAdd";
        _btnAdd.Size = new Size(100, 29);
        _btnAdd.TabIndex = 3;
        _btnAdd.Text = "Добави";
        _btnAdd.Click += BtnAdd_Click;
        // 
        // _btnEdit
        // 
        _btnEdit.Location = new Point(778, 36);
        _btnEdit.Name = "_btnEdit";
        _btnEdit.Size = new Size(100, 23);
        _btnEdit.TabIndex = 2;
        _btnEdit.Text = "Запази";
        _btnEdit.Click += BtnEdit_Click;
        // 
        // _btnDelete
        // 
        _btnDelete.Location = new Point(884, 36);
        _btnDelete.Name = "_btnDelete";
        _btnDelete.Size = new Size(100, 23);
        _btnDelete.TabIndex = 1;
        _btnDelete.Text = "Изтрий";
        _btnDelete.Click += BtnDelete_Click;
        // 
        // _lblId
        // 
        _lblId.AutoSize = true;
        _lblId.Location = new Point(12, 15);
        _lblId.Name = "_lblId";
        _lblId.Size = new Size(57, 20);
        _lblId.TabIndex = 10;
        _lblId.Text = "Номер";
        // 
        // _lblName
        // 
        _lblName.AutoSize = true;
        _lblName.Location = new Point(152, 15);
        _lblName.Name = "_lblName";
        _lblName.Size = new Size(46, 20);
        _lblName.TabIndex = 8;
        _lblName.Text = "Ниво";
        // 
        // _lblColor
        // 
        _lblColor.AutoSize = true;
        _lblColor.Location = new Point(532, 15);
        _lblColor.Name = "_lblColor";
        _lblColor.Size = new Size(42, 20);
        _lblColor.TabIndex = 5;
        _lblColor.Text = "Цвят";
        // 
        // NivoForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(950, 540);
        Controls.Add(_grid);
        Controls.Add(_btnDelete);
        Controls.Add(_btnEdit);
        Controls.Add(_btnAdd);
        Controls.Add(_txtColor);
        Controls.Add(_lblColor);
        Controls.Add(_btnColor);
        Controls.Add(_txtName);
        Controls.Add(_lblName);
        Controls.Add(_txtId);
        Controls.Add(_lblId);
        Name = "NivoForm";
        Text = "Управление: NIVO";
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
    private DataGridView _grid=null!; private TextBox _txtId=null!; private TextBox _txtName=null!; private Button _btnColor=null!; private TextBox _txtColor=null!; private Button _btnAdd=null!; private Button _btnEdit=null!; private Button _btnDelete=null!; private Label _lblId=null!; private Label _lblName=null!; private Label _lblColor=null!;
}
