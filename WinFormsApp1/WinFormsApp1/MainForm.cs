using System.Runtime.InteropServices;
using System.Threading;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        List<string> open_list = new List<string>();
        Dictionary<string, ToolStripMenuItem> menu_items = new Dictionary<string, ToolStripMenuItem>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void AddChildMenu(string formName)
        {
            var item = new ToolStripMenuItem(formName);

            item.Click += (s, e) =>
            {
                OpenChildForm(formName);
            };

            tablesToolStripMenuItem.DropDownItems.Add(item);
            menu_items[formName] = item;
        }

        private void OpenChildForm(string formName)
        {
            Form child = formName == "FormA" ? (Form)new FormA()
                       : formName == "FormB" ? (Form)new FormB()
                       : formName == "FormC" ? (Form)new FormC()
                       : null;

            if (open_list.Contains(formName))
                return;

            open_list.Add(formName);

            child.MdiParent = this;
            child.Text = formName;
            child.Tag = formName; // 연결된 메뉴 저장
            child.FormClosed += Child_FormClosed;
            child.Show();
        }

        private void Child_FormClosed(object sender, FormClosedEventArgs e)
        {
            var child = sender as Form;
            string formName = child.Tag as string;
            open_list.Remove(formName);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                Application.Exit(); // 또는 this.Close();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AddChildMenu("FormA");
            AddChildMenu("FormB");
            AddChildMenu("FormC");
        }

        private void updateUITimer_Tick(object sender, EventArgs e)
        {

            foreach (KeyValuePair<string, ToolStripMenuItem> pair in menu_items)
            {
                string formName = pair.Key;
                ToolStripMenuItem menu_item = pair.Value;

                menu_item.Checked = open_list.Contains(formName);
            }

        }

        private void 업무AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllWindow();

            OpenChildForm("FormA");
            OpenChildForm("FormC");
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllWindow();
        }

        private void CloseAllWindow()
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }

        private void tiledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void horizontalTiledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }
    }
}
