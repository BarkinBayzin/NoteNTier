namespace NoteNTier
{
    partial class frmMain
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
            this.btnNewNote = new System.Windows.Forms.Button();
            this.lstNotes = new System.Windows.Forms.ListBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.linkLblSifre = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnNewNote
            // 
            this.btnNewNote.Location = new System.Drawing.Point(454, 5);
            this.btnNewNote.Name = "btnNewNote";
            this.btnNewNote.Size = new System.Drawing.Size(175, 34);
            this.btnNewNote.TabIndex = 44;
            this.btnNewNote.Text = "YENİ NOT";
            this.btnNewNote.UseVisualStyleBackColor = true;
            this.btnNewNote.Click += new System.EventHandler(this.btnNewNote_Click);
            // 
            // lstNotes
            // 
            this.lstNotes.FormattingEnabled = true;
            this.lstNotes.ItemHeight = 16;
            this.lstNotes.Location = new System.Drawing.Point(20, 5);
            this.lstNotes.Name = "lstNotes";
            this.lstNotes.Size = new System.Drawing.Size(227, 404);
            this.lstNotes.TabIndex = 43;
            this.lstNotes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstNotes_MouseClick);
            // 
            // btnEkle
            // 
            this.btnEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEkle.Location = new System.Drawing.Point(470, 428);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(159, 39);
            this.btnEkle.TabIndex = 42;
            this.btnEkle.Text = "KAYDET";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(253, 5);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(179, 34);
            this.btnSil.TabIndex = 41;
            this.btnSil.Text = "NOT SİL";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(253, 76);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(376, 333);
            this.txtContent.TabIndex = 40;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(253, 46);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(376, 22);
            this.txtTitle.TabIndex = 39;
            // 
            // linkLblSifre
            // 
            this.linkLblSifre.AutoSize = true;
            this.linkLblSifre.Location = new System.Drawing.Point(17, 439);
            this.linkLblSifre.Name = "linkLblSifre";
            this.linkLblSifre.Size = new System.Drawing.Size(83, 16);
            this.linkLblSifre.TabIndex = 38;
            this.linkLblSifre.TabStop = true;
            this.linkLblSifre.Text = "Şifre Değiştir";
            this.linkLblSifre.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblSifre_LinkClicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 487);
            this.Controls.Add(this.btnNewNote);
            this.Controls.Add(this.lstNotes);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.linkLblSifre);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewNote;
        private System.Windows.Forms.ListBox lstNotes;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.LinkLabel linkLblSifre;
    }
}