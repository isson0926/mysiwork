namespace WinFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            updateUITimer = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            업무ToolStripMenuItem = new ToolStripMenuItem();
            업무AToolStripMenuItem = new ToolStripMenuItem();
            tablesToolStripMenuItem = new ToolStripMenuItem();
            windowsToolStripMenuItem = new ToolStripMenuItem();
            closeAllToolStripMenuItem = new ToolStripMenuItem();
            verticalTiledToolStripMenuItem = new ToolStripMenuItem();
            horizontalTiledToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // updateUITimer
            // 
            updateUITimer.Enabled = true;
            updateUITimer.Interval = 300;
            updateUITimer.Tick += updateUITimer_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 업무ToolStripMenuItem, tablesToolStripMenuItem, windowsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // 업무ToolStripMenuItem
            // 
            업무ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 업무AToolStripMenuItem });
            업무ToolStripMenuItem.Name = "업무ToolStripMenuItem";
            업무ToolStripMenuItem.Size = new Size(43, 20);
            업무ToolStripMenuItem.Text = "업무";
            // 
            // 업무AToolStripMenuItem
            // 
            업무AToolStripMenuItem.Name = "업무AToolStripMenuItem";
            업무AToolStripMenuItem.Size = new Size(110, 22);
            업무AToolStripMenuItem.Text = "업무 A";
            업무AToolStripMenuItem.Click += 업무AToolStripMenuItem_Click;
            // 
            // tablesToolStripMenuItem
            // 
            tablesToolStripMenuItem.Name = "tablesToolStripMenuItem";
            tablesToolStripMenuItem.Size = new Size(52, 20);
            tablesToolStripMenuItem.Text = "Tables";
            // 
            // windowsToolStripMenuItem
            // 
            windowsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { closeAllToolStripMenuItem, verticalTiledToolStripMenuItem, horizontalTiledToolStripMenuItem });
            windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            windowsToolStripMenuItem.Size = new Size(68, 20);
            windowsToolStripMenuItem.Text = "Windows";
            // 
            // closeAllToolStripMenuItem
            // 
            closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            closeAllToolStripMenuItem.Size = new Size(180, 22);
            closeAllToolStripMenuItem.Text = "Close All";
            closeAllToolStripMenuItem.Click += closeAllToolStripMenuItem_Click;
            // 
            // verticalTiledToolStripMenuItem
            // 
            verticalTiledToolStripMenuItem.Name = "verticalTiledToolStripMenuItem";
            verticalTiledToolStripMenuItem.Size = new Size(180, 22);
            verticalTiledToolStripMenuItem.Text = "Vertical Tiled";
            verticalTiledToolStripMenuItem.Click += tiledToolStripMenuItem_Click;
            // 
            // horizontalTiledToolStripMenuItem
            // 
            horizontalTiledToolStripMenuItem.Name = "horizontalTiledToolStripMenuItem";
            horizontalTiledToolStripMenuItem.Size = new Size(180, 22);
            horizontalTiledToolStripMenuItem.Text = "Horizontal Tiled";
            horizontalTiledToolStripMenuItem.Click += horizontalTiledToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 100);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 24);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            KeyDown += Form1_KeyDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer updateUITimer;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem windowsToolStripMenuItem;
        private ToolStripMenuItem tablesToolStripMenuItem;
        private ToolStripMenuItem 업무ToolStripMenuItem;
        private ToolStripMenuItem 업무AToolStripMenuItem;
        private ToolStripMenuItem closeAllToolStripMenuItem;
        private ToolStripMenuItem verticalTiledToolStripMenuItem;
        private ToolStripMenuItem horizontalTiledToolStripMenuItem;
        private Panel panel1;
        private Label label1;
    }
}
