namespace UI_MALAN_PESAGE
{
    partial class Page_main
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
            this.Btn_close = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Btn_login = new System.Windows.Forms.Button();
            this.Btn_palette = new System.Windows.Forms.Button();
            this.Btn_colis = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Btn_periph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_close
            // 
            this.Btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_close.Location = new System.Drawing.Point(866, 542);
            this.Btn_close.Name = "Btn_close";
            this.Btn_close.Size = new System.Drawing.Size(298, 95);
            this.Btn_close.TabIndex = 8;
            this.Btn_close.Text = "Fermeture programme";
            this.Btn_close.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(316, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(848, 524);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Btn_login
            // 
            this.Btn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_login.Location = new System.Drawing.Point(562, 542);
            this.Btn_login.Name = "Btn_login";
            this.Btn_login.Size = new System.Drawing.Size(298, 95);
            this.Btn_login.TabIndex = 10;
            this.Btn_login.Text = "Déconnexion";
            this.Btn_login.UseVisualStyleBackColor = true;
            // 
            // Btn_palette
            // 
            this.Btn_palette.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_palette.Location = new System.Drawing.Point(12, 542);
            this.Btn_palette.Name = "Btn_palette";
            this.Btn_palette.Size = new System.Drawing.Size(298, 95);
            this.Btn_palette.TabIndex = 11;
            this.Btn_palette.Text = "Ajouter palette";
            this.Btn_palette.UseVisualStyleBackColor = true;
            this.Btn_palette.Click += new System.EventHandler(this.Btn_palette_Click);
            // 
            // Btn_colis
            // 
            this.Btn_colis.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_colis.Location = new System.Drawing.Point(12, 441);
            this.Btn_colis.Name = "Btn_colis";
            this.Btn_colis.Size = new System.Drawing.Size(298, 95);
            this.Btn_colis.TabIndex = 12;
            this.Btn_colis.Text = "Ajouter colis";
            this.Btn_colis.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(92, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 65);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Btn_periph
            // 
            this.Btn_periph.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_periph.Location = new System.Drawing.Point(12, 340);
            this.Btn_periph.Name = "Btn_periph";
            this.Btn_periph.Size = new System.Drawing.Size(298, 95);
            this.Btn_periph.TabIndex = 14;
            this.Btn_periph.Text = "Scan périphériques";
            this.Btn_periph.UseVisualStyleBackColor = true;
            this.Btn_periph.Click += new System.EventHandler(this.Btn_periph_Click);
            // 
            // Page_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 649);
            this.Controls.Add(this.Btn_periph);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Btn_colis);
            this.Controls.Add(this.Btn_palette);
            this.Controls.Add(this.Btn_login);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Btn_close);
            this.Name = "Page_main";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Page_main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_close;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Btn_login;
        private System.Windows.Forms.Button Btn_palette;
        private System.Windows.Forms.Button Btn_colis;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Btn_periph;
    }
}