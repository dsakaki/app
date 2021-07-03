namespace WindowsFormsApp1
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBoard = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnBlank01 = new System.Windows.Forms.Button();
            this.About = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Crimson;
            this.panel2.Controls.Add(this.btnBoard);
            this.panel2.Controls.Add(this.btnMenu);
            this.panel2.Controls.Add(this.btnBlank01);
            this.panel2.Controls.Add(this.About);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(864, 54);
            this.panel2.TabIndex = 2;
            // 
            // btnBoard
            // 
            this.btnBoard.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBoard.FlatAppearance.BorderSize = 0;
            this.btnBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoard.Image = ((System.Drawing.Image)(resources.GetObject("btnBoard.Image")));
            this.btnBoard.Location = new System.Drawing.Point(0, 0);
            this.btnBoard.Name = "btnBoard";
            this.btnBoard.Size = new System.Drawing.Size(82, 54);
            this.btnBoard.TabIndex = 3;
            this.btnBoard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBoard.UseVisualStyleBackColor = true;
            this.btnBoard.Click += new System.EventHandler(this.btnBoard_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.Image")));
            this.btnMenu.Location = new System.Drawing.Point(0, 0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(739, 54);
            this.btnMenu.TabIndex = 2;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click_1);
            // 
            // btnBlank01
            // 
            this.btnBlank01.CausesValidation = false;
            this.btnBlank01.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBlank01.FlatAppearance.BorderSize = 0;
            this.btnBlank01.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlank01.Image = ((System.Drawing.Image)(resources.GetObject("btnBlank01.Image")));
            this.btnBlank01.Location = new System.Drawing.Point(739, 0);
            this.btnBlank01.Name = "btnBlank01";
            this.btnBlank01.Size = new System.Drawing.Size(67, 54);
            this.btnBlank01.TabIndex = 1;
            this.btnBlank01.UseMnemonic = false;
            this.btnBlank01.UseVisualStyleBackColor = false;
            this.btnBlank01.Click += new System.EventHandler(this.btnBlank01_Click);
            // 
            // About
            // 
            this.About.BackColor = System.Drawing.Color.Crimson;
            this.About.Cursor = System.Windows.Forms.Cursors.Default;
            this.About.Dock = System.Windows.Forms.DockStyle.Right;
            this.About.FlatAppearance.BorderSize = 0;
            this.About.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.About.Image = ((System.Drawing.Image)(resources.GetObject("About.Image")));
            this.About.Location = new System.Drawing.Point(806, 0);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(58, 54);
            this.About.TabIndex = 0;
            this.About.UseVisualStyleBackColor = false;
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 54);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(864, 396);
            this.pnlMain.TabIndex = 1;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(864, 450);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button About;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnBlank01;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnBoard;
    }
}

