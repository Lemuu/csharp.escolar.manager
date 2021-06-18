
namespace EscolarManager.Forms
{
    partial class FormRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegister));
            this.backgroundForm = new System.Windows.Forms.PictureBox();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.groupBoxRegister = new System.Windows.Forms.GroupBox();
            this.password = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundForm)).BeginInit();
            this.groupBoxRegister.SuspendLayout();
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
            // buttonRegister
            // 
            this.buttonRegister.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonRegister.FlatAppearance.BorderSize = 0;
            this.buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegister.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRegister.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonRegister.Location = new System.Drawing.Point(237, 220);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(96, 27);
            this.buttonRegister.TabIndex = 8;
            this.buttonRegister.Text = "Cadastrar";
            this.buttonRegister.UseVisualStyleBackColor = false;
            // 
            // groupBoxRegister
            // 
            this.groupBoxRegister.BackColor = System.Drawing.Color.SeaGreen;
            this.groupBoxRegister.Controls.Add(this.password);
            this.groupBoxRegister.Controls.Add(this.email);
            this.groupBoxRegister.Controls.Add(this.username);
            this.groupBoxRegister.Controls.Add(this.labelPassword);
            this.groupBoxRegister.Controls.Add(this.labelEmail);
            this.groupBoxRegister.Controls.Add(this.labelUsername);
            this.groupBoxRegister.Location = new System.Drawing.Point(163, 80);
            this.groupBoxRegister.Name = "groupBoxRegister";
            this.groupBoxRegister.Size = new System.Drawing.Size(247, 124);
            this.groupBoxRegister.TabIndex = 7;
            this.groupBoxRegister.TabStop = false;
            this.groupBoxRegister.Text = "Cadastro";
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
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(563, 307);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.groupBoxRegister);
            this.Controls.Add(this.backgroundForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRegister";
            this.Text = "Gestão Escolar - Cadastro";
            this.Load += new System.EventHandler(this.FormRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.backgroundForm)).EndInit();
            this.groupBoxRegister.ResumeLayout(false);
            this.groupBoxRegister.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox backgroundForm;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.GroupBox groupBoxRegister;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelUsername;
    }
}