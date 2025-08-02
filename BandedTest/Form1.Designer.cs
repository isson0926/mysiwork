namespace BandedTest
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.bandHeaderPanel = new System.Windows.Forms.Panel();
            this.grid = new System.Windows.Forms.DataGridView();
            this.banedHeaderContainer = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.banedHeaderContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.banedHeaderContainer);
            this.panel1.Controls.Add(this.grid);
            this.panel1.Location = new System.Drawing.Point(117, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 308);
            this.panel1.TabIndex = 1;
            // 
            // bandHeaderPanel
            // 
            this.bandHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.bandHeaderPanel.Name = "bandHeaderPanel";
            this.bandHeaderPanel.Size = new System.Drawing.Size(1000, 37);
            this.bandHeaderPanel.TabIndex = 0;
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowTemplate.Height = 23;
            this.grid.Size = new System.Drawing.Size(509, 308);
            this.grid.TabIndex = 1;
            // 
            // banedHeaderContainer
            // 
            this.banedHeaderContainer.Controls.Add(this.bandHeaderPanel);
            this.banedHeaderContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.banedHeaderContainer.Location = new System.Drawing.Point(0, 0);
            this.banedHeaderContainer.Name = "banedHeaderContainer";
            this.banedHeaderContainer.Size = new System.Drawing.Size(509, 39);
            this.banedHeaderContainer.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.banedHeaderContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel bandHeaderPanel;
        private System.Windows.Forms.Panel banedHeaderContainer;
    }
}

