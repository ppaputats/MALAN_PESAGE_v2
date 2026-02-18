namespace UI_MALAN_PESAGE
{
    partial class Page_palette
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
            this.Label_BL = new System.Windows.Forms.Label();
            this.Txt_BL = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Check_BL = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Label_affiche_poids = new System.Windows.Forms.Label();
            this.Btn_prise_mesure = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_BL
            // 
            this.Label_BL.AutoSize = true;
            this.Label_BL.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_BL.Location = new System.Drawing.Point(74, 42);
            this.Label_BL.Name = "Label_BL";
            this.Label_BL.Size = new System.Drawing.Size(227, 38);
            this.Label_BL.TabIndex = 12;
            this.Label_BL.Text = "Numéro de BL";
            // 
            // Txt_BL
            // 
            this.Txt_BL.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_BL.Location = new System.Drawing.Point(307, 38);
            this.Txt_BL.Name = "Txt_BL";
            this.Txt_BL.Size = new System.Drawing.Size(109, 45);
            this.Txt_BL.TabIndex = 13;
            this.Txt_BL.TextChanged += new System.EventHandler(this.Txt_BL_TextChanged_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(422, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(518, 45);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // Check_BL
            // 
            this.Check_BL.AutoSize = true;
            this.Check_BL.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Check_BL.Location = new System.Drawing.Point(31, 41);
            this.Check_BL.Name = "Check_BL";
            this.Check_BL.Size = new System.Drawing.Size(48, 42);
            this.Check_BL.TabIndex = 15;
            this.Check_BL.Text = " ";
            this.Check_BL.UseVisualStyleBackColor = true;
            this.Check_BL.CheckedChanged += new System.EventHandler(this.Check_BL_CheckedChanged_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(31, 225);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(420, 312);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(501, 225);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(420, 312);
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Label_affiche_poids
            // 
            this.Label_affiche_poids.AutoSize = true;
            this.Label_affiche_poids.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_affiche_poids.Location = new System.Drawing.Point(512, 139);
            this.Label_affiche_poids.Name = "Label_affiche_poids";
            this.Label_affiche_poids.Size = new System.Drawing.Size(315, 38);
            this.Label_affiche_poids.TabIndex = 18;
            this.Label_affiche_poids.Text = "Aucun poids mesuré";
            this.Label_affiche_poids.Click += new System.EventHandler(this.Label_affiche_poids_Click_1);
            // 
            // Btn_prise_mesure
            // 
            this.Btn_prise_mesure.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_prise_mesure.Location = new System.Drawing.Point(81, 111);
            this.Btn_prise_mesure.Name = "Btn_prise_mesure";
            this.Btn_prise_mesure.Size = new System.Drawing.Size(298, 95);
            this.Btn_prise_mesure.TabIndex = 19;
            this.Btn_prise_mesure.Text = "Prise de mesure";
            this.Btn_prise_mesure.UseVisualStyleBackColor = true;
            this.Btn_prise_mesure.Click += new System.EventHandler(this.Btn_prise_mesure_Click_1);
            // 
            // Page_palette
            // 
            this.ClientSize = new System.Drawing.Size(952, 549);
            this.Controls.Add(this.Btn_prise_mesure);
            this.Controls.Add(this.Label_affiche_poids);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Check_BL);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Txt_BL);
            this.Controls.Add(this.Label_BL);
            this.Name = "Page_palette";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label Label_BL;
        private System.Windows.Forms.TextBox Txt_BL;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox Check_BL;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label Label_affiche_poids;
        private System.Windows.Forms.Button Btn_prise_mesure;
    }

        #endregion


    }
