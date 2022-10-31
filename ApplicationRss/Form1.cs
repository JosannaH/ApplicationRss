using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Models;
using BusinessLogic.Controllers;

namespace ApplicationRss
{
    public partial class Form1 : Form
    {
        FeedController FeedController;
        CategoryController CategoryController;

        List<Feed> ListOfFeeds;
        List<Category> ListOfCategories;
        List<Episode> ListOfEpisodes;
        string NameOfChosenFeed = "";

        public Form1()
        {
            InitializeComponent();

            FeedController = new FeedController();
            CategoryController = new CategoryController();
            ListOfFeeds = new List<Feed>();
            ListOfCategories = new List<Category>();
            ListOfEpisodes = new List<Episode>();

            if(FeedController.FileExists())
            {
                ListOfFeeds = FeedController.ReadListFromFile();
                // Read xml data from url
                FeedController.UpdateEpisodesForAllFeeds(ListOfFeeds);
                UpdateListOfFeeds();
                ShowFeedsInListView();
            }
            if (CategoryController.FileExists())
            {
                ListOfCategories = CategoryController.ReadListFromFile();
                ShowCategoriesInListView();
                ShowCategoriesInComboboxes();
            }
        }

        private void btnSaveFeed_Click(object sender, EventArgs e)
        {
            string url = tbUrl.Text;
            string name = tbFeedName.Text;
            string category = cbCategory.SelectedItem.ToString();
            bool success = false;
            

            if (btnSaveFeed.Text.Equals("Save feed"))
            {
                NameOfChosenFeed = name;
                success = FeedController.Create(name, url, category);   
            }
            else if (btnSaveFeed.Text.Equals("Save changes"))
            {
                success = FeedController.Update(NameOfChosenFeed, name, url, category);
                btnSaveFeed.Text = "Save feed";

                NameOfChosenFeed = name;
            }

            if (success)
            {
                UpdateListOfFeeds();
                ShowFeedsInListView();

                UpdateListOfEpisodes(name);
                ShowEpisodesInListView();

                // Set name of feed as column header in Episodes listview
                lvEpisodes.Columns[0].Text = name;

                tbUrl.Clear();
                tbFeedName.Clear();
                // TODO: clear combobox
            }

        }

        private void btnEditFeed_Click(object sender, EventArgs e)
        {
            btnSaveFeed.Text = "Save changes";

            NameOfChosenFeed = lvFeeds.SelectedItems[0].Text;

            List<Feed> feedToEdit = ListOfFeeds.Where(x => x.Name.Equals(NameOfChosenFeed)).ToList();

            // Fill boxes with current feed information
            tbFeedName.Text = feedToEdit[0].Name;
            tbUrl.Text = feedToEdit[0].Url;
            cbCategory.SelectedItem = feedToEdit[0].Category;
        }

        private void btnDeleteFeed_Click(object sender, EventArgs e)
        {
            string feedName = lvFeeds.SelectedItems[0].Text;
            FeedController.Delete(feedName);

            UpdateListOfFeeds();
            ShowFeedsInListView();
           
            lvEpisodes.Items.Clear();
            lvEpisodes.Columns[0].Text = "";
            tbEpisodeSummary.Clear();
        }

        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            bool success = false;
            
            if (btnSaveCategory.Text.Equals("Save category"))
            {
                string categoryName = tbNewCategoryName.Text;
                success = CategoryController.Create(categoryName);
                if (success)
                {
                    UpdateListOfCategories();
                }
            }
            else if(btnSaveCategory.Text.Equals("Save changes"))
            {
                string newCategoryName = tbNewCategoryName.Text;
                string oldCategoryName = lvCategories.SelectedItems[0].Text;

                success = CategoryController.Update(oldCategoryName, newCategoryName);
                UpdateListOfCategories();
                FeedController.UpdateCategoryForFeeds(oldCategoryName, newCategoryName);
                UpdateListOfFeeds();
                ShowFeedsInListView();
                btnSaveCategory.Text = "Save category";
            }
            if (success)
            {
                ShowCategoriesInListView();
                ShowCategoriesInComboboxes();
            }
            tbNewCategoryName.Clear();
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            string categoryName = lvCategories.SelectedItems[0].Text;
            tbNewCategoryName.Text = categoryName;
            btnSaveCategory.Text = "Save changes";
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            string category = lvCategories.SelectedItems[0].Text;

            CategoryController.Delete(category);
            UpdateListOfCategories();
            ShowCategoriesInComboboxes();
            ShowCategoriesInListView();
            FeedController.DeleteFeedsWithCategory(category);
            ListOfFeeds = FeedController.GetListOfAllFeeds();   
            ShowFeedsInListView();
          
            // TODO: Warning to user
        }

        private void lvFeeds_OnItemClick(object sender, EventArgs e)
        {
            NameOfChosenFeed = lvFeeds.SelectedItems[0].Text;
            ListOfEpisodes = FeedController.GetListOfEpisodesForFeed(NameOfChosenFeed);
            ShowEpisodesInListView();

            // Change text on Episode listview header, to the name if chosen feed
            lvEpisodes.Columns[0].Text = NameOfChosenFeed;
        }

        private void cbSortByCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = cbSortByCategory.SelectedItem.ToString();
            ShowFeedsInListViewByCategory(category);
        }

        private void lvEpisodes_OnItemClick(object sender, EventArgs e)
        {
            string nameOfChosenEpisode = lvEpisodes.SelectedItems[0].Text;
            ShowEpisodeDescriptionInTextBox(nameOfChosenEpisode);
        }

        private void ShowFeedsInListView()
        {
            lvFeeds.Items.Clear();

            foreach (Feed feed in ListOfFeeds)
            {
                ListViewItem row = new ListViewItem(feed.Name);
                row.SubItems.Add(feed.NumberOfEpisodes.ToString());
                row.SubItems.Add(feed.Category);
                row.Font = new Font(row.Font, FontStyle.Regular);
                lvFeeds.Items.Add(row);
            }
        }

        private void ShowEpisodesInListView()
        {
            lvEpisodes.Items.Clear();

            foreach (Episode episode in ListOfEpisodes)
            {
                ListViewItem row = new ListViewItem(episode.Name);
                row.Font = new Font(row.Font, FontStyle.Regular);
                lvEpisodes.Items.Add(row);
            }
        }

        private void ShowCategoriesInListView()
        {
            lvCategories.Items.Clear();
            foreach (Category category in ListOfCategories)
            {
                ListViewItem row = new ListViewItem(category.Name);
                row.Font = new Font(row.Font, FontStyle.Regular);

                lvCategories.Items.Add(row);
            }
        }

        private void ShowCategoriesInComboboxes()
        {
            cbCategory.Items.Clear();
            cbSortByCategory.Items.Clear();

            foreach (Category category in ListOfCategories)
            {
                cbCategory.Items.Add(category.Name);
                cbSortByCategory.Items.Add(category.Name);
            }
        }

        private void ShowEpisodeDescriptionInTextBox(string nameOfChosenEpisode)
        {
            string description = FeedController.GetDescriptionForEpisode(NameOfChosenFeed, nameOfChosenEpisode);
            tbEpisodeSummary.Text = description;
        }

        private void ShowFeedsInListViewByCategory(string category)
        {
            lvFeeds.Items.Clear();

            List<Feed> listOfSortedFeeds = FeedController.SortFeedsByCategory(category);

            foreach (Feed feed in listOfSortedFeeds)
            {
                ListViewItem row = new ListViewItem(feed.Name);
                row.SubItems.Add(feed.NumberOfEpisodes.ToString());
                row.SubItems.Add(feed.Category);
                row.Font = new Font(row.Font, FontStyle.Regular);
                lvFeeds.Items.Add(row);
            }
        }

        private void UpdateListOfFeeds()
        {
            ListOfFeeds = FeedController.GetListOfAllFeeds();
        }

        private void UpdateListOfCategories()
        {
            ListOfCategories = CategoryController.GetListOfCategories();
        }

        private void UpdateListOfEpisodes(string feedName)
        {
            ListOfEpisodes = FeedController.GetListOfEpisodesForFeed(feedName);
        }
    }
}
