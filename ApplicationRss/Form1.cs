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

namespace ApplicationRss
{
    [Serializable]
    [XmlInclude(typeof(Form1))]
    public partial class Form1 : Form
    {
        List<Feed> ListOfFeeds = new List<Feed>();
        List<Category> ListOfCategories = new List<Category>(); //{ new Category("News"), new Category("Fashion") };
        SerializerForXml serializerForXml = new SerializerForXml();
        string NameOfChosenFeed;

        public Form1()
        {
            InitializeComponent();

            //// For testing
            //Feed feed = new Feed("IMY", "https://www.imy.se/nyheter/rss/", "News");
            //feed.ListOfEpisodes = CreateListOfEpisodes("https://www.imy.se/nyheter/rss/", feed);
            //ListOfFeeds.Add(feed);
            //serializerForXml.SerializeFeed(ListOfFeeds);
            //ShowEpisodesInListView(GetListOfEpisodesForChosenFeed("IMY"));

            ListOfFeeds = serializerForXml.DeserializeFeed();
            ListOfCategories = serializerForXml.DeserializeCategory();

            UpdateEpisodesForAllFeeds(ListOfFeeds);
            ShowFeedsInListView(ListOfFeeds);
            ShowCategoriesInListView(ListOfCategories);
            ShowCategoriesInComboboxes(ListOfCategories, cbCategory, cbSortByCategory);
        }

        private void btnSaveFeed_Click(object sender, EventArgs e)
        {
            // TODO: Look for duplicates in first URL and then name
            // TODO: add validation / exceptions on input

            string url = tbUrl.Text;
            string name = tbFeedName.Text;
            string category = cbCategory.SelectedItem.ToString();
            NameOfChosenFeed = name; 

            if (btnSaveFeed.Text.Equals("Save feed"))
            {
                Feed feed = new Feed(name, url, category);
                feed.ListOfEpisodes = CreateListOfEpisodes(url, feed);
                ListOfFeeds.Add(feed);
            }
            else if (btnSaveFeed.Text.Equals("Save changes"))
            {
                string chosenFeed = lvFeeds.SelectedItems[0].Text;

                List<Feed> feedToEdit = ListOfFeeds.Where(x => x.Name.Equals(chosenFeed)).ToList();

                feedToEdit[0].Name = name;
                feedToEdit[0].Url = url;
                feedToEdit[0].Category = category;
       
                btnSaveFeed.Text = "Save feed";
            }
            
            serializerForXml.SerializeFeed(ListOfFeeds);
            ShowEpisodesInListView(GetListOfEpisodesForChosenFeed(name));
            ShowFeedsInListView(ListOfFeeds);
            lvEpisodes.Columns[0].Text = name;

            tbUrl.Clear();
            tbFeedName.Clear();
            
        }

        private void btnEditFeed_Click(object sender, EventArgs e)
        {

            btnSaveFeed.Text = "Save changes";

            string chosenFeed = lvFeeds.SelectedItems[0].Text;

            List<Feed> feedToEdit = ListOfFeeds.Where(x => x.Name.Equals(chosenFeed)).ToList();

            tbFeedName.Text = feedToEdit[0].Name;
            tbUrl.Text = feedToEdit[0].Url;
            cbCategory.SelectedItem = feedToEdit[0].Category;

            // TODO: populate URL and name
            // TODO: populate interval combobox, start with current choise
            // TODO: populate category combobox, start with current choise
            // TODO: Update listview

            // TODO: add validation / exceptions on input  
        }

        private void btnDeleteFeed_Click(object sender, EventArgs e)
        {
            string feedName = lvFeeds.SelectedItems[0].Text;

            ListOfFeeds = ListOfFeeds.Where(x => x.Name != feedName).ToList();

            serializerForXml.SerializeFeed(ListOfFeeds);
            ShowFeedsInListView(ListOfFeeds);
            lvEpisodes.Items.Clear();
            lvEpisodes.Columns[0].Text = "";


        }

        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            // TODO: Look for duplicates

            if (btnSaveCategory.Text.Equals("Save category"))
            {
                string categoryName = tbNewCategoryName.Text;
                Category category = new Category(categoryName);
                ListOfCategories.Add(category);
          
            }
            else if(btnSaveCategory.Text.Equals("Save changes"))
            {
                string newCategoryName = tbNewCategoryName.Text;
                string oldCategoryName = lvCategories.SelectedItems[0].Text;

                List<Category> categoryToChange = ListOfCategories.Where(x => x.Name.Equals(oldCategoryName)).ToList();
                categoryToChange[0].Name = newCategoryName;

                btnSaveCategory.Text = "Save category";
                UpdateCategoryNameForFeeds(oldCategoryName, newCategoryName, ListOfFeeds);
                ShowFeedsInListView(ListOfFeeds);
            }
            serializerForXml.SerializeCategory(ListOfCategories);

            ShowCategoriesInListView(ListOfCategories);

            ShowCategoriesInComboboxes(ListOfCategories, cbCategory, cbSortByCategory);
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
            string categoryName = lvCategories.SelectedItems[0].Text;

            ListOfCategories = ListOfCategories.Where(x => x.Name != categoryName).ToList();    

            ListOfFeeds = ListOfFeeds.Where(x => x.Category != categoryName).ToList();
  
            serializerForXml.SerializeFeed(ListOfFeeds);
            serializerForXml.SerializeCategory(ListOfCategories);
            ShowCategoriesInComboboxes(ListOfCategories, cbCategory, cbSortByCategory);
            ShowCategoriesInListView(ListOfCategories);
            ShowFeedsInListView(ListOfFeeds);
          
            // TODO: Warning to user
        }

        private void ShowFeedsInListView(List<Feed> listOfFeeds)
        {
            lvFeeds.Items.Clear();
            foreach(Feed feed in listOfFeeds)
            {
                ListViewItem row = new ListViewItem(feed.Name);
                row.SubItems.Add(feed.NumberOfEpisodes.ToString());
                row.SubItems.Add(feed.Category);
                row.Font = new Font(row.Font, FontStyle.Regular);

                lvFeeds.Items.Add(row);
            }
        }

        private void ShowEpisodesInListView(List<Episode> listOfEpisodes)
        {
            lvEpisodes.Items.Clear();
            foreach (Episode episode in listOfEpisodes)
            {
                ListViewItem row = new ListViewItem(episode.Name);
                row.Font = new Font(row.Font, FontStyle.Regular);

                lvEpisodes.Items.Add(row);
            }
        }

        private void ShowCategoriesInListView(List<Category> listOfCategories)
        {
            lvCategories.Items.Clear();
            foreach(Category category in listOfCategories)
            {
                ListViewItem row = new ListViewItem(category.Name);
                row.Font = new Font(row.Font, FontStyle.Regular);

                lvCategories.Items.Add(row);
            }
        }

        private void ShowCategoriesInComboboxes(List<Category> listOfCategories, System.Windows.Forms.ComboBox comboBox1, System.Windows.Forms.ComboBox comboBox2)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            foreach(Category category in listOfCategories)
            {
                comboBox1.Items.Add(category.Name);
                comboBox2.Items.Add(category.Name);
            }
            
        }

        private List<Episode> CreateListOfEpisodes(string url, Feed feed)
        {
            List<Episode> listOfEpisodes = new List<Episode>();
            // TODO: XmlException 
            XmlReader xmlReader = XmlReader.Create(url);
            SyndicationFeed syndicationFeed = SyndicationFeed.Load(xmlReader);
            foreach (var item in syndicationFeed.Items)
            {
                Episode episode = new Episode();
                episode.Name = item.Title.Text;
                episode.Description = item.Summary.Text;
                listOfEpisodes.Add(episode);
            }
            return listOfEpisodes;
        }

        private void UpdateEpisodesForAllFeeds(List<Feed> listOfFeeds)
        {
            foreach(Feed feed in listOfFeeds)
            {
                feed.ListOfEpisodes = UpdateEpisodesForOneFeed(feed.Url, feed);
            }
        }

        private List<Episode> UpdateEpisodesForOneFeed(string url, Feed feed)
        { 
            // TODO: XmlException 
            XmlReader xmlReader = XmlReader.Create(url);
            SyndicationFeed syndicationFeed = SyndicationFeed.Load(xmlReader);
            Boolean isNew = true;

            List<Episode> updatedListOfEpisodes = new List<Episode>();

            foreach (var item in syndicationFeed.Items)
            {
                string fetchedEpisode = item.Title.Text;

                List<Episode> listOfEpisodes = feed.ListOfEpisodes.Where(x => x.Name.Equals(fetchedEpisode)).ToList();
                if(listOfEpisodes.Count > 0)
                {
                    isNew = false;
                }

                if (isNew) {
                    Episode episode = new Episode();
                    episode.Name = item.Title.Text;
                    episode.Description = item.Summary.Text;

                    updatedListOfEpisodes.Add(episode);
                }
            }
            // The new episodes will be first in the list
            updatedListOfEpisodes.AddRange(feed.ListOfEpisodes);
            return updatedListOfEpisodes;
        }

        private void UpdateCategoryNameForFeeds(string oldCategoryName, string newCategoryName, List<Feed> listOfFeeds)
        {
            List<Feed> feedsWithCategory = listOfFeeds.Where(x => x.Category.Equals(oldCategoryName)).ToList();

            foreach (Feed feed in feedsWithCategory)
            {
                    feed.Category = newCategoryName;
            }
        }

        private void lvFeeds_OnItemClick(object sender, EventArgs e)
        {
            NameOfChosenFeed = lvFeeds.SelectedItems[0].Text;

            // Change text on Episode listview header, to the name if chosen feed
            lvEpisodes.Columns[0].Text = NameOfChosenFeed;
           
            ShowEpisodesInListView(GetListOfEpisodesForChosenFeed(NameOfChosenFeed)); 
        }

        private List<Episode> GetListOfEpisodesForChosenFeed(String feedName)
        {
            List<Episode> listOfEpisodes = new List<Episode>();

            if (feedName != null)
            {
                List<Feed> chosenFeed = ListOfFeeds.Where(x => x.Name.Equals(feedName)).ToList();
                listOfEpisodes = chosenFeed[0].ListOfEpisodes;
            }
                return listOfEpisodes;
        }

        private void cbSortByCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = cbSortByCategory.SelectedItem.ToString();
           
            ShowFeedsInListView(SortFeedsByCategory(ListOfFeeds, category));
        }

        private List<Feed> SortFeedsByCategory(List<Feed> listOfFeeds, string category)
        {
            listOfFeeds = listOfFeeds.Where(x => x.Category.Equals(category)).ToList();
            return listOfFeeds;
        }

        private void lvEpisodes_OnItemClick(object sender, EventArgs e)
        {
            string nameOfChosenEpisode = lvEpisodes.SelectedItems[0].Text;
            ShowEpisodeDescriptionInTextBox(NameOfChosenFeed, nameOfChosenEpisode);
  
    
        
        }

        private void ShowEpisodeDescriptionInTextBox(string nameOfChosenFeed, string nameOfChosenEpisode)
        {
            List<Feed> chosenFeed = ListOfFeeds.Where(x => x.Name.Equals(nameOfChosenFeed)).ToList();
            List<Episode> chosenEpisode = chosenFeed[0].ListOfEpisodes.Where(x => x.Name.Equals(nameOfChosenEpisode)).ToList();

            tbEpisodeSummary.Text = chosenEpisode[0].Description;
        }

    }
}
