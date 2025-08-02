using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BandedTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            this.KeyPreview = true; 
            this.KeyDown += Form1_KeyDown;

            grid.Columns.Add("col1", "A1");
            grid.Columns.Add("col2", "A2");
            grid.Columns.Add("col3", "B1");
            grid.Columns.Add("col4", "B2");
            grid.Columns.Add("col5", "B3");

            for(int i = 0; i < 5; i++)
                grid.Columns[i].Width = 200;

            grid.AllowUserToAddRows = false;
            grid.RowHeadersVisible = false;

            for (int i = 0; i < 10; i++)
                grid.Rows.Add("1", "2", "3", "4", "5");

            grid.Scroll += Grid_Scroll;
            grid.ColumnWidthChanged += (s, e) => bandHeaderPanel.Invalidate();
            grid.SizeChanged += (s, e) => UpdateBandPanelWidth();

            SetPanelDoubleBuffered();
            bandHeaderPanel.Paint += BandHeaderPanel_Paint;

        }
        void SetPanelDoubleBuffered()
        {
            // 더블 버퍼링 활성화
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, bandHeaderPanel, new object[] { true });

            // 선택적으로 깜빡임 방지 스타일도 추가
            bandHeaderPanel.GetType().InvokeMember("SetStyle",
                BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic,
                null, bandHeaderPanel, new object[] {
                    ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint,
                    true
                });
        }

        private void UpdateBandPanelWidth()
        {
            int totalWidth = 0;
            foreach (DataGridViewColumn col in grid.Columns)
                totalWidth += col.Width;

            bandHeaderPanel.Width = totalWidth;
        }


        private void Grid_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                bandHeaderPanel.Left = -grid.HorizontalScrollingOffset;
            }
        }

        private void BandHeaderPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            using (Brush b = new SolidBrush(Color.LightSkyBlue))
            using (Pen pen = new Pen(Color.DarkBlue))
            using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                Rectangle aBand = new Rectangle(0, 0, 600-1, 30);
                Rectangle bBand = new Rectangle(600, 0, 400-1, 30);

                g.FillRectangle(b, aBand);
                g.DrawRectangle(pen, aBand);
                g.DrawString("Group A", this.Font, Brushes.Black, aBand, sf);

                g.FillRectangle(b, bBand);
                g.DrawRectangle(pen, bBand);
                g.DrawString("Group B", this.Font, Brushes.Black, bBand, sf);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Q)
            {
                Application.Exit(); // 프로그램 종료
            }
        }
    }
}
