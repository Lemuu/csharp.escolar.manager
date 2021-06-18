
namespace EscolarManager.Forms
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
            this.backgroundForm = new System.Windows.Forms.PictureBox();
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.password = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonJoin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundForm)).BeginInit();
            this.groupBoxLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundForm
            // 
            this.backgroundForm.Image = ((System.Drawing.Image)(resources.GetObject("backgroundForm.Image")));
            this.backgroundForm.Location = new System.Drawing.Point(12, 12);
            this.backgroundForm.Name = "backgroundForm";
            this.backgroundForm.Size = new System.Drawing.Size(539, 287);
            this.backgroundForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backgroundForm.TabIndex = 0;
            this.backgroundForm.TabStop = false;
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.BackColor = System.Drawing.Color.SeaGreen;
            this.groupBoxLogin.Controls.Add(this.password);
            this.groupBoxLogin.Controls.Add(this.email);
            this.groupBoxLogin.Controls.Add(this.username);
            this.groupBoxLogin.Controls.Add(this.labelPassword);
            this.groupBoxLogin.Controls.Add(this.labelEmail);
            this.groupBoxLogin.Controls.Add(this.labelUsername);
            this.groupBoxLogin.Location = new System.Drawing.Point(163, 80);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(247, 124);
            this.groupBoxLogin.TabIndex = 1;
            this.groupBoxLogin.TabStop = false;
            this.groupBoxLogin.Text = "Login";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(88, 90);
            this.password.Name = "password";
            this.password.PasswordChar = '#';
            this.password.Size = new System.Drawing.Size(145, 23);
            this.password.TabIndex = 5;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(88, 59);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(145, 23);
            this.email.TabIndex = 4;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(88, 26);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(145, 23);
            this.username.TabIndex = 3;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPassword.Location = new System.Drawing.Point(7, 93);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(49, 20);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Senha";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEmail.Location = new System.Drawing.Point(7, 62);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(46, 20);
            this.labelEmail.TabIndex = 1;
            this.labelEmail.Text = "Email";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelUsername.Location = new System.Drawing.Point(7, 29);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(75, 20);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username";
            // 
            // buttonJoin
            // 
            this.buttonJoin.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonJoin.FlatAppearance.BorderSize = 0;
            this.buttonJoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonJoin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonJoin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonJoin.Location = new System.Drawing.Point(237, 220);
            this.buttonJoin.Name = "buttonJoin";
            this.buttonJoin.Size = new System.Drawing.Size(96, 27);
            this.buttonJoin.TabIndex = 6;
            this.buttonJoin.Text = "Entrar";
            this.buttonJoin.UseVisualStyleBackColor = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(563, 307);
            this.Controls.Add(this.buttonJoin);
            this.Controls.Add(this.groupBoxLogin);
            this.Controls.Add(this.backgroundForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.Text = "Gestão Escolar - Login";
            ((System.ComponentModel.ISupportInitialize)(this.backgroundForm)).EndInit();
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox backgroundForm;
        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Button buttonJoin;
    }
}