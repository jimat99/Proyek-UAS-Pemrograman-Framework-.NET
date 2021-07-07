namespace Project_UAS_Pemrograman_Framework.NET
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.MaskedTextBox();
            this.checkBoxTampilkanPassword = new System.Windows.Forms.CheckBox();
            this.iconUsername = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.iconPassword = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.Location = new System.Drawing.Point(252, 188);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 30);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textUsername
            // 
            this.textUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUsername.Location = new System.Drawing.Point(204, 72);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(180, 26);
            this.textUsername.TabIndex = 1;
            // 
            // textPassword
            // 
            this.textPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPassword.Location = new System.Drawing.Point(205, 130);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(180, 26);
            this.textPassword.TabIndex = 3;
            // 
            // checkBoxTampilkanPassword
            // 
            this.checkBoxTampilkanPassword.AutoSize = true;
            this.checkBoxTampilkanPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxTampilkanPassword.Location = new System.Drawing.Point(205, 162);
            this.checkBoxTampilkanPassword.Name = "checkBoxTampilkanPassword";
            this.checkBoxTampilkanPassword.Size = new System.Drawing.Size(153, 20);
            this.checkBoxTampilkanPassword.TabIndex = 4;
            this.checkBoxTampilkanPassword.Text = "Tampilkan password";
            this.checkBoxTampilkanPassword.UseVisualStyleBackColor = true;
            this.checkBoxTampilkanPassword.CheckedChanged += new System.EventHandler(this.checkBoxTampilkanPassword_CheckedChanged);
            // 
            // iconUsername
            // 
            this.iconUsername.Image = ((System.Drawing.Image)(resources.GetObject("iconUsername.Image")));
            this.iconUsername.Location = new System.Drawing.Point(172, 72);
            this.iconUsername.Name = "iconUsername";
            this.iconUsername.Size = new System.Drawing.Size(26, 26);
            this.iconUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconUsername.TabIndex = 5;
            this.iconUsername.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(201, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            // 
            // iconPassword
            // 
            this.iconPassword.Image = ((System.Drawing.Image)(resources.GetObject("iconPassword.Image")));
            this.iconPassword.Location = new System.Drawing.Point(173, 130);
            this.iconPassword.Name = "iconPassword";
            this.iconPassword.Size = new System.Drawing.Size(26, 26);
            this.iconPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPassword.TabIndex = 8;
            this.iconPassword.TabStop = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 310);
            this.Controls.Add(this.iconPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iconUsername);
            this.Controls.Add(this.checkBoxTampilkanPassword);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.buttonLogin);
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Aplikasi Inventori Toko";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLogin_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.iconUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.MaskedTextBox textPassword;
        private System.Windows.Forms.CheckBox checkBoxTampilkanPassword;
        private System.Windows.Forms.PictureBox iconUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox iconPassword;
    }
}

