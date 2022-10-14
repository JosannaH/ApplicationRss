namespace ApplicationRss
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
            this.lvPodcasts = new System.Windows.Forms.ListView();
            this.lvEpisodes = new System.Windows.Forms.ListView();
            this.lvCategories = new System.Windows.Forms.ListView();
            this.btnSavePodcast = new System.Windows.Forms.Button();
            this.btnDeletePodcast = new System.Windows.Forms.Button();
            this.btnSaveCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.tbNewCategory = new System.Windows.Forms.TextBox();
            this.cbInterval = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblShowEpisodes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvPodcasts
            // 
            this.lvPodcasts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvPodcasts.HideSelection = false;
            this.lvPodcasts.Location = new System.Drawing.Point(12, 27);
            this.lvPodcasts.Name = "lvPodcasts";
            this.lvPodcasts.Size = new System.Drawing.Size(442, 197);
            this.lvPodcasts.TabIndex = 0;
            this.lvPodcasts.UseCompatibleStateImageBehavior = false;
            // 
            // lvEpisodes
            // 
            this.lvEpisodes.HideSelection = false;
            this.lvEpisodes.Location = new System.Drawing.Point(12, 347);
            this.lvEpisodes.Name = "lvEpisodes";
            this.lvEpisodes.Size = new System.Drawing.Size(442, 91);
            this.lvEpisodes.TabIndex = 1;
            this.lvEpisodes.UseCompatibleStateImageBehavior = false;
            // 
            // lvCategories
            // 
            this.lvCategories.HideSelection = false;
            this.lvCategories.Location = new System.Drawing.Point(491, 59);
            this.lvCategories.Name = "lvCategories";
            this.lvCategories.Size = new System.Drawing.Size(297, 87);
            this.lvCategories.TabIndex = 2;
            this.lvCategories.UseCompatibleStateImageBehavior = false;
            // 
            // btnSavePodcast
            // 
            this.btnSavePodcast.Location = new System.Drawing.Point(333, 286);
            this.btnSavePodcast.Name = "btnSavePodcast";
            this.btnSavePodcast.Size = new System.Drawing.Size(121, 23);
            this.btnSavePodcast.TabIndex = 3;
            this.btnSavePodcast.Text = "Spara podcast";
            this.btnSavePodcast.UseVisualStyleBackColor = true;
            // 
            // btnDeletePodcast
            // 
            this.btnDeletePodcast.Location = new System.Drawing.Point(206, 286);
            this.btnDeletePodcast.Name = "btnDeletePodcast";
            this.btnDeletePodcast.Size = new System.Drawing.Size(121, 23);
            this.btnDeletePodcast.TabIndex = 4;
            this.btnDeletePodcast.Text = "Ta bort markerad";
            this.btnDeletePodcast.UseVisualStyleBackColor = true;
            // 
            // btnSaveCategory
            // 
            this.btnSaveCategory.Location = new System.Drawing.Point(653, 151);
            this.btnSaveCategory.Name = "btnSaveCategory";
            this.btnSaveCategory.Size = new System.Drawing.Size(135, 23);
            this.btnSaveCategory.TabIndex = 7;
            this.btnSaveCategory.Text = "Spara kategori";
            this.btnSaveCategory.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Location = new System.Drawing.Point(653, 180);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(135, 23);
            this.btnDeleteCategory.TabIndex = 8;
            this.btnDeleteCategory.Text = "Ta bort markerad";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(491, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Kategorier";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "URL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Intervall:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Kategori:";
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(12, 251);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(188, 22);
            this.tbUrl.TabIndex = 13;
            // 
            // tbNewCategory
            // 
            this.tbNewCategory.Location = new System.Drawing.Point(491, 152);
            this.tbNewCategory.Name = "tbNewCategory";
            this.tbNewCategory.Size = new System.Drawing.Size(156, 22);
            this.tbNewCategory.TabIndex = 14;
            this.tbNewCategory.Text = "Ny kategori...";
            // 
            // cbInterval
            // 
            this.cbInterval.FormattingEnabled = true;
            this.cbInterval.Location = new System.Drawing.Point(206, 251);
            this.cbInterval.Name = "cbInterval";
            this.cbInterval.Size = new System.Drawing.Size(121, 24);
            this.cbInterval.TabIndex = 15;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(333, 251);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(121, 24);
            this.cbCategory.TabIndex = 16;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(494, 231);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(294, 207);
            this.richTextBox1.TabIndex = 17;
            this.richTextBox1.Text = "";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Avsnitt";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Namn";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Intervall";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Kategori";
            // 
            // lblShowEpisodes
            // 
            this.lblShowEpisodes.AutoSize = true;
            this.lblShowEpisodes.Location = new System.Drawing.Point(12, 325);
            this.lblShowEpisodes.Name = "lblShowEpisodes";
            this.lblShowEpisodes.Size = new System.Drawing.Size(44, 16);
            this.lblShowEpisodes.TabIndex = 18;
            this.lblShowEpisodes.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblShowEpisodes);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.cbInterval);
            this.Controls.Add(this.tbNewCategory);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteCategory);
            this.Controls.Add(this.btnSaveCategory);
            this.Controls.Add(this.btnDeletePodcast);
            this.Controls.Add(this.btnSavePodcast);
            this.Controls.Add(this.lvCategories);
            this.Controls.Add(this.lvEpisodes);
            this.Controls.Add(this.lvPodcasts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvPodcasts;
        private System.Windows.Forms.ListView lvEpisodes;
        private System.Windows.Forms.ListView lvCategories;
        private System.Windows.Forms.Button btnSavePodcast;
        private System.Windows.Forms.Button btnDeletePodcast;
        private System.Windows.Forms.Button btnSaveCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.TextBox tbNewCategory;
        private System.Windows.Forms.ComboBox cbInterval;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lblShowEpisodes;
    }
}

