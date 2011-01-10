namespace Doctor
{
    public partial class filechk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(filechk));
            this.uninstallerTest_btn = new System.Windows.Forms.Button();
            this.err_list = new System.Windows.Forms.ListBox();
            this.Registry_Values_lbl = new System.Windows.Forms.Label();
            this.load_text = new System.Windows.Forms.Label();
            this.list_head_lbl = new System.Windows.Forms.Label();
            this.messages = new System.Windows.Forms.ListBox();
            this.installerTest_btn = new System.Windows.Forms.Button();
            this.message_lbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Reg_lbl = new System.Windows.Forms.Label();
            this.pop1 = new System.Windows.Forms.PictureBox();
            this.pop2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pop1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pop2)).BeginInit();
            this.SuspendLayout();
            // 
            // uninstallerTest_btn
            // 
            this.uninstallerTest_btn.BackColor = System.Drawing.Color.Maroon;
            this.uninstallerTest_btn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.uninstallerTest_btn.Location = new System.Drawing.Point(851, 427);
            this.uninstallerTest_btn.Name = "uninstallerTest_btn";
            this.uninstallerTest_btn.Size = new System.Drawing.Size(116, 49);
            this.uninstallerTest_btn.TabIndex = 2;
            this.uninstallerTest_btn.Text = "UNINSTALLER TEST";
            this.uninstallerTest_btn.UseVisualStyleBackColor = false;
            this.uninstallerTest_btn.Click += new System.EventHandler(this.uninstallerTest_btn_Click);
            // 
            // err_list
            // 
            this.err_list.BackColor = System.Drawing.Color.Snow;
            this.err_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.err_list.FormattingEnabled = true;
            this.err_list.HorizontalScrollbar = true;
            this.err_list.Location = new System.Drawing.Point(3, 121);
            this.err_list.Name = "err_list";
            this.err_list.Size = new System.Drawing.Size(204, 364);
            this.err_list.TabIndex = 3;
            this.err_list.Visible = false;
            // 
            // Registry_Values_lbl
            // 
            this.Registry_Values_lbl.AutoSize = true;
            this.Registry_Values_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Registry_Values_lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Registry_Values_lbl.Location = new System.Drawing.Point(319, 121);
            this.Registry_Values_lbl.Name = "Registry_Values_lbl";
            this.Registry_Values_lbl.Size = new System.Drawing.Size(83, 13);
            this.Registry_Values_lbl.TabIndex = 5;
            this.Registry_Values_lbl.Text = "Registry Values ";
            this.Registry_Values_lbl.Visible = false;
            // 
            // load_text
            // 
            this.load_text.AutoSize = true;
            this.load_text.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.load_text.Location = new System.Drawing.Point(80, 222);
            this.load_text.Name = "load_text";
            this.load_text.Size = new System.Drawing.Size(836, 120);
            this.load_text.TabIndex = 7;
            this.load_text.Text = "Problem after installtion/uninstallation? \n                 Don\'t worry, Choose a" +
                " test:";
            // 
            // list_head_lbl
            // 
            this.list_head_lbl.AutoSize = true;
            this.list_head_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_head_lbl.ForeColor = System.Drawing.Color.DarkRed;
            this.list_head_lbl.Location = new System.Drawing.Point(25, 78);
            this.list_head_lbl.Name = "list_head_lbl";
            this.list_head_lbl.Size = new System.Drawing.Size(147, 25);
            this.list_head_lbl.TabIndex = 8;
            this.list_head_lbl.Text = "Untracked Files";
            this.list_head_lbl.Visible = false;
            // 
            // messages
            // 
            this.messages.BackColor = System.Drawing.Color.Snow;
            this.messages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messages.FormattingEnabled = true;
            this.messages.HorizontalScrollbar = true;
            this.messages.Location = new System.Drawing.Point(736, 121);
            this.messages.Name = "messages";
            this.messages.Size = new System.Drawing.Size(276, 208);
            this.messages.TabIndex = 9;
            this.messages.Visible = false;
            // 
            // installerTest_btn
            // 
            this.installerTest_btn.BackColor = System.Drawing.Color.Maroon;
            this.installerTest_btn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.installerTest_btn.Location = new System.Drawing.Point(851, 345);
            this.installerTest_btn.Name = "installerTest_btn";
            this.installerTest_btn.Size = new System.Drawing.Size(116, 49);
            this.installerTest_btn.TabIndex = 1;
            this.installerTest_btn.Text = "INSTALLER TEST";
            this.installerTest_btn.UseVisualStyleBackColor = false;
            this.installerTest_btn.Click += new System.EventHandler(this.installerTest_btn_Click);
            // 
            // message_lbl
            // 
            this.message_lbl.AutoSize = true;
            this.message_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message_lbl.ForeColor = System.Drawing.Color.DarkRed;
            this.message_lbl.Location = new System.Drawing.Point(748, 78);
            this.message_lbl.Name = "message_lbl";
            this.message_lbl.Size = new System.Drawing.Size(103, 25);
            this.message_lbl.TabIndex = 10;
            this.message_lbl.Text = "Messages";
            this.message_lbl.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::ChkTest.Properties.Resources.AdoMado;
            this.pictureBox1.Location = new System.Drawing.Point(-3, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1015, 64);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Reg_lbl
            // 
            this.Reg_lbl.AutoSize = true;
            this.Reg_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reg_lbl.ForeColor = System.Drawing.Color.DarkRed;
            this.Reg_lbl.Location = new System.Drawing.Point(340, 78);
            this.Reg_lbl.Name = "Reg_lbl";
            this.Reg_lbl.Size = new System.Drawing.Size(148, 25);
            this.Reg_lbl.TabIndex = 11;
            this.Reg_lbl.Text = "Registry Values";
            this.Reg_lbl.Visible = false;
            // 
            // pop1
            // 
            this.pop1.Location = new System.Drawing.Point(781, 335);
            this.pop1.Name = "pop1";
            this.pop1.Size = new System.Drawing.Size(70, 64);
            this.pop1.TabIndex = 12;
            this.pop1.TabStop = false;
            this.pop1.Visible = false;
            // 
            // pop2
            // 
            this.pop2.Location = new System.Drawing.Point(782, 416);
            this.pop2.Name = "pop2";
            this.pop2.Size = new System.Drawing.Size(69, 64);
            this.pop2.TabIndex = 13;
            this.pop2.TabStop = false;
            this.pop2.Visible = false;
            // 
            // filechk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1012, 521);
            this.Controls.Add(this.pop2);
            this.Controls.Add(this.pop1);
            this.Controls.Add(this.Reg_lbl);
            this.Controls.Add(this.message_lbl);
            this.Controls.Add(this.messages);
            this.Controls.Add(this.list_head_lbl);
            this.Controls.Add(this.load_text);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Registry_Values_lbl);
            this.Controls.Add(this.err_list);
            this.Controls.Add(this.uninstallerTest_btn);
            this.Controls.Add(this.installerTest_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "filechk";
            this.Text = "AdoMado Doctor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pop1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pop2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button installerTest_btn;
        private System.Windows.Forms.Button uninstallerTest_btn;
        public System.Windows.Forms.ListBox err_list;
        private System.Windows.Forms.Label Registry_Values_lbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label load_text;
        private System.Windows.Forms.Label list_head_lbl;
        private System.Windows.Forms.ListBox messages;
        private System.Windows.Forms.Label message_lbl;
        private System.Windows.Forms.Label Reg_lbl;
        private System.Windows.Forms.PictureBox pop1;
        private System.Windows.Forms.PictureBox pop2;
    }
}

