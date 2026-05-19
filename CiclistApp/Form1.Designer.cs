namespace CiclistApp
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
            this.grpAdaugaBiciclist = new System.Windows.Forms.GroupBox();
            this.btnAdaugaBiciclist = new System.Windows.Forms.Button();
            this.txtCnp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbDificultate = new System.Windows.Forms.ComboBox();
            this.txtDurata = new System.Windows.Forms.TextBox();
            this.txtDistanta = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Dificultate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDenumire = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCautaDupaCnp = new System.Windows.Forms.Button();
            this.txtCautareCnp = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lstBiciclist = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblStartLung = new System.Windows.Forms.Label();
            this.lblStartDistanta = new System.Windows.Forms.Label();
            this.lblStartTrasee = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnStergeTraseu = new System.Windows.Forms.Button();
            this.dvgTrasee = new System.Windows.Forms.DataGridView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblStartTraseeBiciclisti = new System.Windows.Forms.Label();
            this.lblStartBicclisti = new System.Windows.Forms.Label();
            this.grpDetaliiTraseu = new System.Windows.Forms.GroupBox();
            this.pgDetalisTraseu = new System.Windows.Forms.PropertyGrid();
            this.grpAdaugaBiciclist.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgTrasee)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.grpDetaliiTraseu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAdaugaBiciclist
            // 
            this.grpAdaugaBiciclist.Controls.Add(this.btnAdaugaBiciclist);
            this.grpAdaugaBiciclist.Controls.Add(this.txtCnp);
            this.grpAdaugaBiciclist.Controls.Add(this.label2);
            this.grpAdaugaBiciclist.Controls.Add(this.label1);
            this.grpAdaugaBiciclist.Controls.Add(this.txtNume);
            this.grpAdaugaBiciclist.Location = new System.Drawing.Point(29, 12);
            this.grpAdaugaBiciclist.Name = "grpAdaugaBiciclist";
            this.grpAdaugaBiciclist.Size = new System.Drawing.Size(333, 244);
            this.grpAdaugaBiciclist.TabIndex = 0;
            this.grpAdaugaBiciclist.TabStop = false;
            this.grpAdaugaBiciclist.Text = "Adauga Biciclist";
            // 
            // btnAdaugaBiciclist
            // 
            this.btnAdaugaBiciclist.Location = new System.Drawing.Point(15, 181);
            this.btnAdaugaBiciclist.Name = "btnAdaugaBiciclist";
            this.btnAdaugaBiciclist.Size = new System.Drawing.Size(295, 43);
            this.btnAdaugaBiciclist.TabIndex = 4;
            this.btnAdaugaBiciclist.Text = "Adauga";
            this.btnAdaugaBiciclist.UseVisualStyleBackColor = true;
            // 
            // txtCnp
            // 
            this.txtCnp.Location = new System.Drawing.Point(15, 136);
            this.txtCnp.Name = "txtCnp";
            this.txtCnp.Size = new System.Drawing.Size(283, 25);
            this.txtCnp.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "CNP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nume:";
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(15, 68);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(283, 25);
            this.txtNume.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbDificultate);
            this.groupBox2.Controls.Add(this.txtDurata);
            this.groupBox2.Controls.Add(this.txtDistanta);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.Dificultate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtDenumire);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(401, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(439, 244);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adauga Traseu pentru Biciclistul Selectat";
            // 
            // cmbDificultate
            // 
            this.cmbDificultate.FormattingEnabled = true;
            this.cmbDificultate.Location = new System.Drawing.Point(149, 120);
            this.cmbDificultate.Name = "cmbDificultate";
            this.cmbDificultate.Size = new System.Drawing.Size(121, 26);
            this.cmbDificultate.TabIndex = 11;
            // 
            // txtDurata
            // 
            this.txtDurata.Location = new System.Drawing.Point(288, 120);
            this.txtDurata.Name = "txtDurata";
            this.txtDurata.Size = new System.Drawing.Size(126, 25);
            this.txtDurata.TabIndex = 10;
            // 
            // txtDistanta
            // 
            this.txtDistanta.Location = new System.Drawing.Point(6, 120);
            this.txtDistanta.Name = "txtDistanta";
            this.txtDistanta.Size = new System.Drawing.Size(126, 25);
            this.txtDistanta.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(295, 43);
            this.button1.TabIndex = 5;
            this.button1.Text = "Adauga";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Durata(min):";
            // 
            // Dificultate
            // 
            this.Dificultate.AutoSize = true;
            this.Dificultate.Location = new System.Drawing.Point(172, 99);
            this.Dificultate.Name = "Dificultate";
            this.Dificultate.Size = new System.Drawing.Size(75, 18);
            this.Dificultate.TabIndex = 7;
            this.Dificultate.Text = "Dificultate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Distanta:";
            // 
            // txtDenumire
            // 
            this.txtDenumire.Location = new System.Drawing.Point(6, 58);
            this.txtDenumire.Name = "txtDenumire";
            this.txtDenumire.Size = new System.Drawing.Size(424, 25);
            this.txtDenumire.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Denumire:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCautaDupaCnp);
            this.groupBox3.Controls.Add(this.txtCautareCnp);
            this.groupBox3.Location = new System.Drawing.Point(29, 272);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(333, 66);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cauta dupa CNP";
            // 
            // btnCautaDupaCnp
            // 
            this.btnCautaDupaCnp.Location = new System.Drawing.Point(180, 24);
            this.btnCautaDupaCnp.Name = "btnCautaDupaCnp";
            this.btnCautaDupaCnp.Size = new System.Drawing.Size(130, 32);
            this.btnCautaDupaCnp.TabIndex = 5;
            this.btnCautaDupaCnp.Text = "Cauta";
            this.btnCautaDupaCnp.UseVisualStyleBackColor = true;
            // 
            // txtCautareCnp
            // 
            this.txtCautareCnp.Location = new System.Drawing.Point(6, 24);
            this.txtCautareCnp.Name = "txtCautareCnp";
            this.txtCautareCnp.Size = new System.Drawing.Size(144, 25);
            this.txtCautareCnp.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstBiciclist);
            this.groupBox4.Location = new System.Drawing.Point(29, 362);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(333, 173);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Biciclisti";
            // 
            // lstBiciclist
            // 
            this.lstBiciclist.FormattingEnabled = true;
            this.lstBiciclist.ItemHeight = 18;
            this.lstBiciclist.Location = new System.Drawing.Point(15, 20);
            this.lstBiciclist.Name = "lstBiciclist";
            this.lstBiciclist.Size = new System.Drawing.Size(295, 130);
            this.lstBiciclist.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblStartLung);
            this.groupBox5.Controls.Add(this.lblStartDistanta);
            this.groupBox5.Controls.Add(this.lblStartTrasee);
            this.groupBox5.Location = new System.Drawing.Point(868, 400);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(333, 143);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Statistici Biciclist Selectat";
            // 
            // lblStartLung
            // 
            this.lblStartLung.AutoSize = true;
            this.lblStartLung.Location = new System.Drawing.Point(15, 104);
            this.lblStartLung.Name = "lblStartLung";
            this.lblStartLung.Size = new System.Drawing.Size(70, 18);
            this.lblStartLung.TabIndex = 2;
            this.lblStartLung.Text = "Lungimea";
            // 
            // lblStartDistanta
            // 
            this.lblStartDistanta.AutoSize = true;
            this.lblStartDistanta.Location = new System.Drawing.Point(15, 63);
            this.lblStartDistanta.Name = "lblStartDistanta";
            this.lblStartDistanta.Size = new System.Drawing.Size(59, 18);
            this.lblStartDistanta.TabIndex = 1;
            this.lblStartDistanta.Text = "Distanta";
            // 
            // lblStartTrasee
            // 
            this.lblStartTrasee.AutoSize = true;
            this.lblStartTrasee.Location = new System.Drawing.Point(15, 25);
            this.lblStartTrasee.Name = "lblStartTrasee";
            this.lblStartTrasee.Size = new System.Drawing.Size(50, 18);
            this.lblStartTrasee.TabIndex = 0;
            this.lblStartTrasee.Text = "Traseu";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnStergeTraseu);
            this.groupBox6.Controls.Add(this.dvgTrasee);
            this.groupBox6.Location = new System.Drawing.Point(401, 262);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(439, 281);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Trasee";
            // 
            // btnStergeTraseu
            // 
            this.btnStergeTraseu.BackColor = System.Drawing.Color.MistyRose;
            this.btnStergeTraseu.Location = new System.Drawing.Point(29, 245);
            this.btnStergeTraseu.Name = "btnStergeTraseu";
            this.btnStergeTraseu.Size = new System.Drawing.Size(385, 28);
            this.btnStergeTraseu.TabIndex = 1;
            this.btnStergeTraseu.Text = "Șterge Traseu Selectat";
            this.btnStergeTraseu.UseVisualStyleBackColor = false;
            // 
            // dvgTrasee
            // 
            this.dvgTrasee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgTrasee.Location = new System.Drawing.Point(29, 25);
            this.dvgTrasee.Name = "dvgTrasee";
            this.dvgTrasee.RowHeadersWidth = 51;
            this.dvgTrasee.RowTemplate.Height = 24;
            this.dvgTrasee.Size = new System.Drawing.Size(385, 210);
            this.dvgTrasee.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblStartTraseeBiciclisti);
            this.groupBox7.Controls.Add(this.lblStartBicclisti);
            this.groupBox7.Location = new System.Drawing.Point(868, 272);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(325, 112);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Statistici Generale";
            // 
            // lblStartTraseeBiciclisti
            // 
            this.lblStartTraseeBiciclisti.AutoSize = true;
            this.lblStartTraseeBiciclisti.Location = new System.Drawing.Point(21, 73);
            this.lblStartTraseeBiciclisti.Name = "lblStartTraseeBiciclisti";
            this.lblStartTraseeBiciclisti.Size = new System.Drawing.Size(79, 18);
            this.lblStartTraseeBiciclisti.TabIndex = 4;
            this.lblStartTraseeBiciclisti.Text = "Total trasee";
            // 
            // lblStartBicclisti
            // 
            this.lblStartBicclisti.AutoSize = true;
            this.lblStartBicclisti.Location = new System.Drawing.Point(21, 32);
            this.lblStartBicclisti.Name = "lblStartBicclisti";
            this.lblStartBicclisti.Size = new System.Drawing.Size(94, 18);
            this.lblStartBicclisti.TabIndex = 3;
            this.lblStartBicclisti.Text = "Total Biciclisti";
            // 
            // grpDetaliiTraseu
            // 
            this.grpDetaliiTraseu.Controls.Add(this.pgDetalisTraseu);
            this.grpDetaliiTraseu.Location = new System.Drawing.Point(870, 25);
            this.grpDetaliiTraseu.Name = "grpDetaliiTraseu";
            this.grpDetaliiTraseu.Size = new System.Drawing.Size(323, 231);
            this.grpDetaliiTraseu.TabIndex = 5;
            this.grpDetaliiTraseu.TabStop = false;
            this.grpDetaliiTraseu.Text = "Detalii Traseu";
            // 
            // pgDetalisTraseu
            // 
            this.pgDetalisTraseu.Location = new System.Drawing.Point(10, 33);
            this.pgDetalisTraseu.Name = "pgDetalisTraseu";
            this.pgDetalisTraseu.Size = new System.Drawing.Size(212, 192);
            this.pgDetalisTraseu.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1229, 637);
            this.Controls.Add(this.grpDetaliiTraseu);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpAdaugaBiciclist);
            this.Font = new System.Drawing.Font("Palatino Linotype", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.grpAdaugaBiciclist.ResumeLayout(false);
            this.grpAdaugaBiciclist.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgTrasee)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.grpDetaliiTraseu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAdaugaBiciclist;
        private System.Windows.Forms.Button btnAdaugaBiciclist;
        private System.Windows.Forms.TextBox txtCnp;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbDificultate;
        private System.Windows.Forms.TextBox txtDurata;
        private System.Windows.Forms.TextBox txtDistanta;
        private System.Windows.Forms.TextBox txtDenumire;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCautaDupaCnp;
        private System.Windows.Forms.TextBox txtCautareCnp;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Dificultate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstBiciclist;
        private System.Windows.Forms.Label lblStartDistanta;
        private System.Windows.Forms.Label lblStartTrasee;
        private System.Windows.Forms.Label lblStartLung;
        private System.Windows.Forms.DataGridView dvgTrasee;
        private System.Windows.Forms.Button btnStergeTraseu;
        private System.Windows.Forms.Label lblStartBicclisti;
        private System.Windows.Forms.Label lblStartTraseeBiciclisti;
        private System.Windows.Forms.GroupBox grpDetaliiTraseu;
        private System.Windows.Forms.PropertyGrid pgDetalisTraseu;

    }
}
