namespace BaziDanni_k.p_.Infrastructure;

internal static class UiStyler
{
    public static void MakeButtonsMoreVisible(Control root)
    {
        foreach (Control control in root.Controls)
        {
            if (control is Button button)
            {
                button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                button.MinimumSize = new Size(140, 44);
                button.Height = Math.Max(button.Height, 44);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = Color.FromArgb(30, 136, 229);
                button.ForeColor = Color.White;
                button.Padding = new Padding(10, 6, 10, 6);
                button.Margin = new Padding(8);
                button.Cursor = Cursors.Hand;
            }

            if (control.HasChildren)
            {
                MakeButtonsMoreVisible(control);
            }
        }
    }

    public static void StyleToolStrip(ToolStrip toolStrip)
    {
        toolStrip.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        toolStrip.Padding = new Padding(8);

        foreach (ToolStripItem item in toolStrip.Items)
        {
            if (item is ToolStripButton button)
            {
                button.BackColor = Color.FromArgb(30, 136, 229);
                button.ForeColor = Color.White;
                button.Margin = new Padding(4);
                button.Padding = new Padding(10, 8, 10, 8);
            }

            if (item is ToolStripDropDownButton dropDown)
            {
                dropDown.BackColor = Color.FromArgb(30, 136, 229);
                dropDown.ForeColor = Color.White;
                dropDown.Margin = new Padding(4);
                dropDown.Padding = new Padding(10, 8, 10, 8);
            }
        }
    }
}
