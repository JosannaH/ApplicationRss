using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using BusinessLogic;
using System.IO;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
using System.ServiceModel.Syndication;
using System.Runtime.Remoting.Messaging;
using System.Collections;
using System.Web;
using System.Security.Policy;
using System.Xml.Linq;
using Models;
using BusinessLogic.Controllers;

namespace ApplicationRss
{
    [Serializable]
    [XmlInclude(typeof(Form1))]
    public partial class Form1 : Form
    {
        FeedController FeedController;
        EpisodeController EpisodeController;
        CategoryController CategoryController;

        List<Feed> ListOfFeeds;
        List<Category> ListOfCategories;
        List<Episode> ListOfEpisodes;
        string NameOfChosenFeed = "";

        // List<Feed> ListOfFeeds = new List<Feed>();
        // List<Category> ListOfCategories = new List<Category>(); //{ new Category("News"), new Category("Fashion") };

        public Form1()
        {
            InitializeComponent();

            FeedController = new FeedController();
            EpisodeController = new EpisodeController();
            CategoryController = new CategoryController();

            //if(FeedController.FileOfFeedsExists())
            //{
                ListOfFeeds = FeedController.ReadListOfFeedsFromFile();
                // Read xml data from url
                FeedController.UpdateEpisodesForAllFeeds(ListOfFeeds);
                UpdateListOfFeeds();
                ShowFeedsInListView();
            //}
            //if (CategoryController.FileOfFeedsExists())
            //{
                ListOfCategories = CategoryController.ReadListOfCategoriesFromFile();
                ShowCategoriesInListView();
                ShowCategoriesInComboboxes();
            //}

            
            

            
            


            //// For testing
            //Feed feed = new Feed("IMY", "https://www.imy.se/nyheter/rss/", "News");
            //feed.ListOfEpisodes = CreateListOfEpisodes("https://www.imy.se/nyheter/rss/", feed);
            //ListOfFeeds.Add(feed);
            //serializerForXml.SerializeFeed(ListOfFeeds);
            //ShowEpisodesInListView(GetListOfEpisodesForChosenFeed("IMY"));
        }

        private void btnSaveFeed_Click(object sender, EventArgs e)
        {
            // TODO: Look for duplicates in first URL and then name
            // TODO: add validation / exceptions on input

            string url = tbUrl.Text;
            string name = tbFeedName.Text;
            string category = cbCategory.SelectedItem.ToString();

            if (btnSaveFeed.Text.Equals("Save feed"))
            {
                FeedController.CreateFeed(name, url, category);   
            }
            else if (btnSaveFeed.Text.Equals("Save changes"))
            {
                string chosenFeed = lvFeeds.SelectedItems[0].Text;
                FeedController.UpdateFeed(chosenFeed, name, url, category);
                btnSaveFeed.Text = "Save feed";
            }

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

        private void btnEditFeed_Click(object sender, EventArgs e)
        {
            btnSaveFeed.Text = "Save changes";

            string chosenFeed = lvFeeds.SelectedItems[0].Text;

            List<Feed> feedToEdit = ListOfFeeds.Where(x => x.Name.Equals(chosenFeed)).ToList();

            // Fill boxes with current feed information
            tbFeedName.Text = feedToEdit[0].Name;
            tbUrl.Text = feedToEdit[0].Url;
            cbCategory.SelectedItem = feedToEdit[0].Category;
        }

        private void btnDeleteFeed_Click(object sender, EventArgs e)
        {
            string feedName = lvFeeds.SelectedItems[0].Text;
            FeedController.DeleteFeed(feedName);

            ShowFeedsInListView();
           
            lvEpisodes.Items.Clear();
            lvEpisodes.Columns[0].Text = "";
        }

        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            // TODO: Look for duplicates

            if (btnSaveCategory.Text.Equals("Save category"))
            {
                string categoryName = tbNewCategoryName.Text;
                CategoryController.CreateCategory(categoryName);
                UpdateListOfCategories();          
            }
            else if(btnSaveCategory.Text.Equals("Save changes"))
            {
                string newCategoryName = tbNewCategoryName.Text;
                string oldCategoryName = lvCategories.SelectedItems[0].Text;

                CategoryController.UpdateCategory(oldCategoryName, newCategoryName);
                UpdateListOfCategories();
                UpdateListOfFeeds();
                ShowFeedsInListView();
                btnSaveCategory.Text = "Save category";
            }

            ShowCategoriesInListView();
            ShowCategoriesInComboboxes();
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

            CategoryController.DeleteCategory(category);
            UpdateListOfCategories();
            ShowCategoriesInComboboxes();
            ShowCategoriesInListView();
            ShowFeedsInListView();
          
            // TODO: Warning to user
        }

        private void lvFeeds_OnItemClick(object sender, EventArgs e)
        {
            NameOfChosenFeed = lvFeeds.SelectedItems[0].Text;

            // Change text on Episode listview header, to the name if chosen feed
            lvEpisodes.Columns[0].Text = NameOfChosenFeed;
           
            ShowEpisodesInListView(); 
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
