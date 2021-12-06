
namespace Login_Forma
{
    partial class Registracija
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.registracijaBtn = new System.Windows.Forms.Button();
            this.imeBox = new System.Windows.Forms.TextBox();
            this.lozinkaBox = new System.Windows.Forms.TextBox();
            this.prezimeBox = new System.Windows.Forms.Label();
            this.prezimBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.brojIndeksaBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimeBox = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.korisnickoImeBox = new System.Windows.Forms.TextBox();
            this.errorP = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Lozinka";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ime";
            // 
            // registracijaBtn
            // 
            this.registracijaBtn.Location = new System.Drawing.Point(247, 258);
            this.registracijaBtn.Name = "registracijaBtn";
            this.registracijaBtn.Size = new System.Drawing.Size(274, 32);
            this.registracijaBtn.TabIndex = 8;
            this.registracijaBtn.Text = "Registruj se";
            this.registracijaBtn.UseVisualStyleBackColor = true;
            this.registracijaBtn.Click += new System.EventHandler(this.registracijaBtn_Click);
            // 
            // imeBox
            // 
            this.imeBox.Location = new System.Drawing.Point(336, 27);
            this.imeBox.Name = "imeBox";
            this.imeBox.Size = new System.Drawing.Size(185, 20);
            this.imeBox.TabIndex = 0;
            this.imeBox.TextChanged += new System.EventHandler(this.imeBox_TextChanged);
            // 
            // lozinkaBox
            // 
            this.lozinkaBox.Location = new System.Drawing.Point(337, 156);
            this.lozinkaBox.Name = "lozinkaBox";
            this.lozinkaBox.Size = new System.Drawing.Size(184, 20);
            this.lozinkaBox.TabIndex = 4;
            // 
            // prezimeBox
            // 
            this.prezimeBox.Location = new System.Drawing.Point(0, 0);
            this.prezimeBox.Name = "prezimeBox";
            this.prezimeBox.Size = new System.Drawing.Size(100, 23);
            this.prezimeBox.TabIndex = 25;
            // 
            // prezimBox
            // 
            this.prezimBox.Location = new System.Drawing.Point(336, 53);
            this.prezimBox.Name = "prezimBox";
            this.prezimBox.Size = new System.Drawing.Size(185, 20);
            this.prezimBox.TabIndex = 1;
            this.prezimBox.TextChanged += new System.EventHandler(this.prezimBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Broj indeksa";
            // 
            // brojIndeksaBox
            // 
            this.brojIndeksaBox.Location = new System.Drawing.Point(336, 183);
            this.brojIndeksaBox.Name = "brojIndeksaBox";
            this.brojIndeksaBox.Size = new System.Drawing.Size(185, 20);
            this.brojIndeksaBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Datum rodjenja";
            // 
            // dateTimeBox
            // 
            this.dateTimeBox.Location = new System.Drawing.Point(336, 79);
            this.dateTimeBox.Name = "dateTimeBox";
            this.dateTimeBox.Size = new System.Drawing.Size(185, 20);
            this.dateTimeBox.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Godina studija";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Korisnicko ime";
            // 
            // korisnickoImeBox
            // 
            this.korisnickoImeBox.Location = new System.Drawing.Point(337, 130);
            this.korisnickoImeBox.Name = "korisnickoImeBox";
            this.korisnickoImeBox.Size = new System.Drawing.Size(184, 20);
            this.korisnickoImeBox.TabIndex = 3;
            this.korisnickoImeBox.TextChanged += new System.EventHandler(this.korisnickoImeBox_TextChanged);
            // 
            // errorP
            // 
            this.errorP.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 212);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Ucitaj sliku";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox1.Location = new System.Drawing.Point(336, 211);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(185, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(244, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Prezime";
            // 
            // Registracija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 302);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.korisnickoImeBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimeBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.brojIndeksaBox);
            this.Controls.Add(this.prezimeBox);
            this.Controls.Add(this.prezimBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.registracijaBtn);
            this.Controls.Add(this.imeBox);
            this.Controls.Add(this.lozinkaBox);
            this.Name = "Registracija";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registracija";
            this.Load += new System.EventHandler(this.Registracija_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button registracijaBtn;
        private System.Windows.Forms.TextBox imeBox;
        private System.Windows.Forms.TextBox lozinkaBox;
        private System.Windows.Forms.Label prezimeBox;
        private System.Windows.Forms.TextBox prezimBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox brojIndeksaBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimeBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox korisnickoImeBox;
        private System.Windows.Forms.ErrorProvider errorP;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
    }
}