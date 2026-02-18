namespace UI_MALAN_PESAGE
{
    partial class Page_login
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_connection = new System.Windows.Forms.Button();
            this.Label_password = new System.Windows.Forms.Label();
            this.Label_username = new System.Windows.Forms.Label();
            this.Txt_password = new System.Windows.Forms.TextBox();
            this.Txt_username = new System.Windows.Forms.TextBox();
            this.CheckBx_Admin = new System.Windows.Forms.CheckBox();
            this.Btn_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_connection
            // 
            this.Btn_connection.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_connection.Location = new System.Drawing.Point(434, 380);
            this.Btn_connection.Name = "Btn_connection";
            this.Btn_connection.Size = new System.Drawing.Size(298, 95);
            this.Btn_connection.TabIndex = 13;
            this.Btn_connection.Text = "Connexion";
            this.Btn_connection.UseVisualStyleBackColor = true;
            this.Btn_connection.Click += new System.EventHandler(this.Btn_connection_Click);
            // 
            // Label_password
            // 
            this.Label_password.AutoSize = true;
            this.Label_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_password.Location = new System.Drawing.Point(131, 255);
            this.Label_password.Name = "Label_password";
            this.Label_password.Size = new System.Drawing.Size(258, 38);
            this.Label_password.TabIndex = 12;
            this.Label_password.Text = "Nom d\'utilisateur";
            this.Label_password.Click += new System.EventHandler(this.Label_password_Click);
            // 
            // Label_username
            // 
            this.Label_username.AutoSize = true;
            this.Label_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_username.Location = new System.Drawing.Point(131, 181);
            this.Label_username.Name = "Label_username";
            this.Label_username.Size = new System.Drawing.Size(258, 38);
            this.Label_username.TabIndex = 11;
            this.Label_username.Text = "Nom d\'utilisateur";
            // 
            // Txt_password
            // 
            this.Txt_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_password.Location = new System.Drawing.Point(434, 252);
            this.Txt_password.Name = "Txt_password";
            this.Txt_password.Size = new System.Drawing.Size(513, 45);
            this.Txt_password.TabIndex = 10;
            this.Txt_password.TextChanged += new System.EventHandler(this.Txt_password_TextChanged);
            // 
            // Txt_username
            // 
            this.Txt_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_username.Location = new System.Drawing.Point(434, 178);
            this.Txt_username.Name = "Txt_username";
            this.Txt_username.Size = new System.Drawing.Size(513, 45);
            this.Txt_username.TabIndex = 9;
            this.Txt_username.TextChanged += new System.EventHandler(this.Txt_username_TextChanged);
            // 
            // CheckBx_Admin
            // 
            this.CheckBx_Admin.AutoSize = true;
            this.CheckBx_Admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBx_Admin.Location = new System.Drawing.Point(111, 332);
            this.CheckBx_Admin.Name = "CheckBx_Admin";
            this.CheckBx_Admin.Size = new System.Drawing.Size(335, 42);
            this.CheckBx_Admin.TabIndex = 8;
            this.CheckBx_Admin.Text = "Mode administrateur";
            this.CheckBx_Admin.UseVisualStyleBackColor = true;
            this.CheckBx_Admin.CheckedChanged += new System.EventHandler(this.CheckBx_Admin_CheckedChanged);
            // 
            // Btn_close
            // 
            this.Btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_close.Location = new System.Drawing.Point(842, 508);
            this.Btn_close.Name = "Btn_close";
            this.Btn_close.Size = new System.Drawing.Size(298, 95);
            this.Btn_close.TabIndex = 7;
            this.Btn_close.Text = "Fermeture programme";
            this.Btn_close.UseVisualStyleBackColor = true;
            this.Btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // Page_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 640);
            this.Controls.Add(this.Btn_connection);
            this.Controls.Add(this.Label_password);
            this.Controls.Add(this.Label_username);
            this.Controls.Add(this.Txt_password);
            this.Controls.Add(this.Txt_username);
            this.Controls.Add(this.CheckBx_Admin);
            this.Controls.Add(this.Btn_close);
            this.Name = "Page_login";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button Btn_connection;
        private System.Windows.Forms.Label Label_password;
        private System.Windows.Forms.Label Label_username;
        private System.Windows.Forms.TextBox Txt_password;
        private System.Windows.Forms.TextBox Txt_username;
        private System.Windows.Forms.CheckBox CheckBx_Admin;
        private System.Windows.Forms.Button Btn_close;
    }
}

