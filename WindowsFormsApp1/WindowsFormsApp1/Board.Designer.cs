namespace WindowsFormsApp1
{
    partial class Board
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.NgayHienTai = new System.Windows.Forms.Label();
            this.TongDoanhThu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 65F);
            this.label1.Location = new System.Drawing.Point(3, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1177, 98);
            this.label1.TabIndex = 0;
            this.label1.Text = "VÃI LỒN GẮT ĐẦU CẮT MOI";
            // 
            // NgayHienTai
            // 
            this.NgayHienTai.AutoSize = true;
            this.NgayHienTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 65F);
            this.NgayHienTai.Location = new System.Drawing.Point(3, 44);
            this.NgayHienTai.Name = "NgayHienTai";
            this.NgayHienTai.Size = new System.Drawing.Size(1177, 98);
            this.NgayHienTai.TabIndex = 1;
            this.NgayHienTai.Text = "VÃI LỒN GẮT ĐẦU CẮT MOI";
            // 
            // TongDoanhThu
            // 
            this.TongDoanhThu.AutoSize = true;
            this.TongDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 65F);
            this.TongDoanhThu.Location = new System.Drawing.Point(3, 288);
            this.TongDoanhThu.Name = "TongDoanhThu";
            this.TongDoanhThu.Size = new System.Drawing.Size(1177, 98);
            this.TongDoanhThu.TabIndex = 2;
            this.TongDoanhThu.Text = "VÃI LỒN GẮT ĐẦU CẮT MOI";
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TongDoanhThu);
            this.Controls.Add(this.NgayHienTai);
            this.Controls.Add(this.label1);
            this.Name = "Board";
            this.Size = new System.Drawing.Size(820, 335);
            this.Load += new System.EventHandler(this.Board_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NgayHienTai;
        private System.Windows.Forms.Label TongDoanhThu;
    }
}
