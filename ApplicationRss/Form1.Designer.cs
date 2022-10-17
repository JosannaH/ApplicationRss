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
            this.lvFeeds = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvEpisodes = new System.Windows.Forms.ListView();
            this.lvCategories = new System.Windows.Forms.ListView();
            this.btnSaveFeed = new System.Windows.Forms.Button();
            this.btnDeleteFeed = new System.Windows.Forms.Button();
            this.btnSaveCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.lblCategories = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUpdateInterval = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.tbNewCategoryName = new System.Windows.Forms.TextBox();
            this.cbInterval = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.tbEpisodeSummary = new System.Windows.Forms.RichTextBox();
            this.lblEpisodes = new System.Windows.Forms.Label();
            this.lblFeeds = new System.Windows.Forms.Label();
            this.lblEpisodeDescription = new System.Windows.Forms.Label();
            this.lblNewEditFeed = new System.Windows.Forms.Label();
            this.btnEditFeed = new System.Windows.Forms.Button();
            this.lblNewCategory = new System.Windows.Forms.Label();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.lblPodcastName = new System.Windows.Forms.Label();
            this.tbFeedName = new System.Windows.Forms.TextBox();
            this.lblSortByCategory = new System.Windows.Forms.Label();
            this.cbSortByCategory = new System.Windows.Forms.ComboBox();
            this.btnEditCategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvFeeds
            // 
            this.lvFeeds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvFeeds.HideSelection = false;
            this.lvFeeds.Location = new System.Drawing.Point(23, 56);
            this.lvFeeds.Name = "lvFeeds";
            this.lvFeeds.Size = new System.Drawing.Size(431, 197);
            this.lvFeeds.TabIndex = 0;
            this.lvFeeds.UseCompatibleStateImageBehavior = false;
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
            // lvEpisodes
            // 
            this.lvEpisodes.HideSelection = false;
            this.lvEpisodes.Location = new System.Drawing.Point(535, 58);
            this.lvEpisodes.Name = "lvEpisodes";
            this.lvEpisodes.Size = new System.Drawing.Size(442, 197);
            this.lvEpisodes.TabIndex = 1;
            this.lvEpisodes.UseCompatibleStateImageBehavior = false;
            // 
            // lvCategories
            // 
            this.lvCategories.HideSelection = false;
            this.lvCategories.Location = new System.Drawing.Point(23, 567);
            this.lvCategories.Name = "lvCategories";
            this.lvCategories.Size = new System.Drawing.Size(237, 87);
            this.lvCategories.TabIndex = 2;
            this.lvCategories.UseCompatibleStateImageBehavior = false;
            // 
            // btnSaveFeed
            // 
            this.btnSaveFeed.Location = new System.Drawing.Point(334, 475);
            this.btnSaveFeed.Name = "btnSaveFeed";
            this.btnSaveFeed.Size = new System.Drawing.Size(121, 23);
            this.btnSaveFeed.TabIndex = 3;
            this.btnSaveFeed.Text = "Save feed";
            this.btnSaveFeed.UseVisualStyleBackColor = true;
            this.btnSaveFeed.Click += new System.EventHandler(this.btnSaveFeed_Click);
            // 
            // btnDeleteFeed
            // 
            this.btnDeleteFeed.Location = new System.Drawing.Point(333, 288);
            this.btnDeleteFeed.Name = "btnDeleteFeed";
            this.btnDeleteFeed.Size = new System.Drawing.Size(121, 23);
            this.btnDeleteFeed.TabIndex = 4;
            this.btnDeleteFeed.Text = "Delete feed";
            this.btnDeleteFeed.UseVisualStyleBackColor = true;
            this.btnDeleteFeed.Click += new System.EventHandler(this.btnDeleteFeed_Click);
            // 
            // btnSaveCategory
            // 
            this.btnSaveCategory.Location = new System.Drawing.Point(344, 620);
            this.btnSaveCategory.Name = "btnSaveCategory";
            this.btnSaveCategory.Size = new System.Drawing.Size(110, 23);
            this.btnSaveCategory.TabIndex = 7;
            this.btnSaveCategory.Text = "Save category";
            this.btnSaveCategory.UseVisualStyleBackColor = true;
            this.btnSaveCategory.Click += new System.EventHandler(this.btnSaveCategory_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Location = new System.Drawing.Point(143, 660);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(117, 23);
            this.btnDeleteCategory.TabIndex = 8;
            this.btnDeleteCategory.Text = "Delete category";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // lblCategories
            // 
            this.lblCategories.AutoSize = true;
            this.lblCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCategories.Location = new System.Drawing.Point(21, 538);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(107, 25);
            this.lblCategories.TabIndex = 9;
            this.lblCategories.Text = "Categories";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "URL:";
            // 
            // lblUpdateInterval
            // 
            this.lblUpdateInterval.AutoSize = true;
            this.lblUpdateInterval.Location = new System.Drawing.Point(224, 426);
            this.lblUpdateInterval.Name = "lblUpdateInterval";
            this.lblUpdateInterval.Size = new System.Drawing.Size(101, 16);
            this.lblUpdateInterval.TabIndex = 11;
            this.lblUpdateInterval.Text = "Update interval:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(331, 426);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(65, 16);
            this.lblCategory.TabIndex = 12;
            this.lblCategory.Text = "Category:";
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(23, 391);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(431, 22);
            this.tbUrl.TabIndex = 13;
            // 
            // tbNewCategoryName
            // 
            this.tbNewCategoryName.Location = new System.Drawing.Point(269, 592);
            this.tbNewCategoryName.Name = "tbNewCategoryName";
            this.tbNewCategoryName.Size = new System.Drawing.Size(185, 22);
            this.tbNewCategoryName.TabIndex = 14;
            // 
            // cbInterval
            // 
            this.cbInterval.FormattingEnabled = true;
            this.cbInterval.Location = new System.Drawing.Point(227, 445);
            this.cbInterval.Name = "cbInterval";
            this.cbInterval.Size = new System.Drawing.Size(98, 24);
            this.cbInterval.TabIndex = 15;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(333, 445);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(121, 24);
            this.cbCategory.TabIndex = 16;
            // 
            // tbEpisodeSummary
            // 
            this.tbEpisodeSummary.Location = new System.Drawing.Point(535, 306);
            this.tbEpisodeSummary.Name = "tbEpisodeSummary";
            this.tbEpisodeSummary.Size = new System.Drawing.Size(442, 377);
            this.tbEpisodeSummary.TabIndex = 17;
            this.tbEpisodeSummary.Text = "";
            // 
            // lblEpisodes
            // 
            this.lblEpisodes.AutoSize = true;
            this.lblEpisodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblEpisodes.Location = new System.Drawing.Point(533, 30);
            this.lblEpisodes.Name = "lblEpisodes";
            this.lblEpisodes.Size = new System.Drawing.Size(93, 25);
            this.lblEpisodes.TabIndex = 18;
            this.lblEpisodes.Text = "Episodes";
            // 
            // lblFeeds
            // 
            this.lblFeeds.AutoSize = true;
            this.lblFeeds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblFeeds.Location = new System.Drawing.Point(18, 30);
            this.lblFeeds.Name = "lblFeeds";
            this.lblFeeds.Size = new System.Drawing.Size(67, 25);
            this.lblFeeds.TabIndex = 19;
            this.lblFeeds.Text = "Feeds";
            // 
            // lblEpisodeDescription
            // 
            this.lblEpisodeDescription.AutoSize = true;
            this.lblEpisodeDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblEpisodeDescription.Location = new System.Drawing.Point(530, 278);
            this.lblEpisodeDescription.Name = "lblEpisodeDescription";
            this.lblEpisodeDescription.Size = new System.Drawing.Size(185, 25);
            this.lblEpisodeDescription.TabIndex = 20;
            this.lblEpisodeDescription.Text = "Episode Description";
            // 
            // lblNewEditFeed
            // 
            this.lblNewEditFeed.AutoSize = true;
            this.lblNewEditFeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNewEditFeed.Location = new System.Drawing.Point(18, 335);
            this.lblNewEditFeed.Name = "lblNewEditFeed";
            this.lblNewEditFeed.Size = new System.Drawing.Size(140, 25);
            this.lblNewEditFeed.TabIndex = 21;
            this.lblNewEditFeed.Text = "New/Edit Feed";
            // 
            // btnEditFeed
            // 
            this.btnEditFeed.Location = new System.Drawing.Point(333, 259);
            this.btnEditFeed.Name = "btnEditFeed";
            this.btnEditFeed.Size = new System.Drawing.Size(121, 23);
            this.btnEditFeed.TabIndex = 22;
            this.btnEditFeed.Text = "Edit feed";
            this.btnEditFeed.UseVisualStyleBackColor = true;
            this.btnEditFeed.Click += new System.EventHandler(this.btnEditFeed_Click);
            // 
            // lblNewCategory
            // 
            this.lblNewCategory.AutoSize = true;
            this.lblNewCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNewCategory.Location = new System.Drawing.Point(264, 538);
            this.lblNewCategory.Name = "lblNewCategory";
            this.lblNewCategory.Size = new System.Drawing.Size(175, 25);
            this.lblNewCategory.TabIndex = 23;
            this.lblNewCategory.Text = "New/Edit Category";
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Location = new System.Drawing.Point(266, 567);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(47, 16);
            this.lblCategoryName.TabIndex = 24;
            this.lblCategoryName.Text = "Name:";
            // 
            // lblPodcastName
            // 
            this.lblPodcastName.AutoSize = true;
            this.lblPodcastName.Location = new System.Drawing.Point(23, 426);
            this.lblPodcastName.Name = "lblPodcastName";
            this.lblPodcastName.Size = new System.Drawing.Size(47, 16);
            this.lblPodcastName.TabIndex = 25;
            this.lblPodcastName.Text = "Name:";
            // 
            // tbFeedName
            // 
            this.tbFeedName.Location = new System.Drawing.Point(23, 445);
            this.tbFeedName.Name = "tbFeedName";
            this.tbFeedName.Size = new System.Drawing.Size(195, 22);
            this.tbFeedName.TabIndex = 26;
            // 
            // lblSortByCategory
            // 
            this.lblSortByCategory.AutoSize = true;
            this.lblSortByCategory.Location = new System.Drawing.Point(20, 262);
            this.lblSortByCategory.Name = "lblSortByCategory";
            this.lblSortByCategory.Size = new System.Drawing.Size(108, 16);
            this.lblSortByCategory.TabIndex = 27;
            this.lblSortByCategory.Text = "Sort by category:";
            // 
            // cbSortByCategory
            // 
            this.cbSortByCategory.FormattingEnabled = true;
            this.cbSortByCategory.Location = new System.Drawing.Point(134, 258);
            this.cbSortByCategory.Name = "cbSortByCategory";
            this.cbSortByCategory.Size = new System.Drawing.Size(137, 24);
            this.cbSortByCategory.TabIndex = 28;
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.Location = new System.Drawing.Point(23, 660);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(114, 23);
            this.btnEditCategory.TabIndex = 29;
            this.btnEditCategory.Text = "Edit category";
            this.btnEditCategory.UseVisualStyleBackColor = true;
            this.btnEditCategory.Click += new System.EventHandler(this.btnEditCategory_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 703);
            this.Controls.Add(this.btnEditCategory);
            this.Controls.Add(this.cbSortByCategory);
            this.Controls.Add(this.lblSortByCategory);
            this.Controls.Add(this.tbFeedName);
            this.Controls.Add(this.lblPodcastName);
            this.Controls.Add(this.lblCategoryName);
            this.Controls.Add(this.lblNewCategory);
            this.Controls.Add(this.btnEditFeed);
            this.Controls.Add(this.lblNewEditFeed);
            this.Controls.Add(this.lblEpisodeDescription);
            this.Controls.Add(this.lblFeeds);
            this.Controls.Add(this.lblEpisodes);
            this.Controls.Add(this.tbEpisodeSummary);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.cbInterval);
            this.Controls.Add(this.tbNewCategoryName);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblUpdateInterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCategories);
            this.Controls.Add(this.btnDeleteCategory);
            this.Controls.Add(this.btnSaveCategory);
            this.Controls.Add(this.btnDeleteFeed);
            this.Controls.Add(this.btnSaveFeed);
            this.Controls.Add(this.lvCategories);
            this.Controls.Add(this.lvEpisodes);
            this.Controls.Add(this.lvFeeds);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvFeeds;
        private System.Windows.Forms.ListView lvEpisodes;
        private System.Windows.Forms.ListView lvCategories;
        private System.Windows.Forms.Button btnSaveFeed;
        private System.Windows.Forms.Button btnDeleteFeed;
        private System.Windows.Forms.Button btnSaveCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUpdateInterval;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.TextBox tbNewCategoryName;
        private System.Windows.Forms.ComboBox cbInterval;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.RichTextBox tbEpisodeSummary;
        private System.Windows.Forms.Label lblEpisodes;
        private System.Windows.Forms.Label lblFeeds;
        private System.Windows.Forms.Label lblEpisodeDescription;
        private System.Windows.Forms.Label lblNewEditFeed;
        private System.Windows.Forms.Button btnEditFeed;
        private System.Windows.Forms.Label lblNewCategory;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.Label lblPodcastName;
        private System.Windows.Forms.TextBox tbFeedName;
        private System.Windows.Forms.Label lblSortByCategory;
        private System.Windows.Forms.ComboBox cbSortByCategory;
        private System.Windows.Forms.Button btnEditCategory;
    }
}

