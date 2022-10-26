﻿using System;
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

namespace ApplicationRss
{
    [Serializable]
    [XmlInclude(typeof(Form1))]
    public partial class Form1 : Form
    {
        List<Feed> ListOfFeeds = new List<Feed>();
        List<Category> ListOfCategories = new List<Category> { new Category("News"), new Category("Fashion") };

        public Form1()
        {
            InitializeComponent();

            SerializerForXml serializerForXml = new SerializerForXml();
            ListOfFeeds = serializerForXml.DeserializeFeed();
            ListOfCategories = serializerForXml.DeserializeCategory();

            UpdateEpisodesForAllFeeds(ListOfFeeds);
            ShowFeedsInListView(ListOfFeeds);
            ShowCategoriesInListView(ListOfCategories);
            ShowCategoriesInComboboxes(ListOfCategories, cbCategory, cbSortByCategory);


            // TODO: deserialize category file
            // TODO: populate category combobox
        }

        private void btnSaveFeed_Click(object sender, EventArgs e)
        {
            // TODO: add validation / exceptions on input

            string url = tbUrl.Text;
            string name = tbFeedName.Text;
            string category =  cbCategory.SelectedItem.ToString();
    
            Feed feed = new Feed(name, url,category);
            feed.ListOfEpisodes = CreateListOfEpisodes(url, feed);
            ListOfFeeds.Add(feed);

            SerializerForXml serializerForXml = new SerializerForXml();
            serializerForXml.SerializeFeed(ListOfFeeds);

            ShowFeedsInListView(ListOfFeeds);
            ShowEpisodesInListView(feed.ListOfEpisodes);
            lvEpisodes.Columns[0].Text = feed.Name;

            tbUrl.Clear();
            tbFeedName.Clear();
        }

        private void btnEditFeed_Click(object sender, EventArgs e)
        {
   


            // TODO: populate URL and name
            // TODO: populate interval combobox, start with current choise
            // TODO: populate category combobox, start with current choise
            // TODO: Update listview

            // TODO: add validation / exceptions on input  
        }

        private void btnDeleteFeed_Click(object sender, EventArgs e)
        {
            // TODO: Find objecy by id, delete all data
            // TODO: Update listview
        }

        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            if(btnSaveCategory.Text.Equals("Save category"))
            {
                string categoryName = tbNewCategoryName.Text;
                Category category = new Category(categoryName);
                ListOfCategories.Add(category);
          
            }
            else if(btnSaveCategory.Text.Equals("Save changes"))
            {
                string newCategoryName = tbNewCategoryName.Text;
                string oldCategoryName = lvCategories.SelectedItems[0].Text;

                foreach (Category category in ListOfCategories)
                {
                    if (category.Name.Equals(oldCategoryName))
                    {
                        category.Name = newCategoryName;
                    }
                }
                btnSaveCategory.Text = "Save category";
                UpdateCategoryNameForFeeds(oldCategoryName, newCategoryName, ListOfFeeds);
                ShowFeedsInListView(ListOfFeeds);
            }
            SerializerForXml serializerForXml = new SerializerForXml();
            serializerForXml.SerializeCategory(ListOfCategories);

            ShowCategoriesInListView(ListOfCategories);

            ShowCategoriesInComboboxes(ListOfCategories, cbCategory, cbSortByCategory);
            tbNewCategoryName.Clear();
            // TODO: Update listview
            // TODO: add validation / exceptions on input
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            string categoryName = lvCategories.SelectedItems[0].Text;
            tbNewCategoryName.Text = categoryName;
            btnSaveCategory.Text = "Save changes";
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            // TODO: Delete category and all feeds in that category
            // TODO: Warning to user
            // TODO: Update listview

            //SerializerForXml serializerForXml=new SerializerForXml();
            //List<Feed> testList = new List<Feed>();
            //Feed feed = new Feed();
            //testList = serializerForXml.DeserializeFeed();
            ////ShowFeedsInListView(testList);
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
                UpdateEpisodesForOneFeed(feed.Url, feed);
            }
        }

        private void UpdateEpisodesForOneFeed(String url, Feed feed)
        { 
            // TODO: XmlException 
            XmlReader xmlReader = XmlReader.Create(url);
            SyndicationFeed syndicationFeed = SyndicationFeed.Load(xmlReader);
            Boolean isNew = true;

            foreach (var item in syndicationFeed.Items)
            {
                String newEpisode = item.Title.Text;

                    foreach (var episodeItem in feed.ListOfEpisodes)
                    {
                        String oldEpisode = episodeItem.Name;

                        if (newEpisode.Equals(oldEpisode))
                        {
                        isNew = false;
                        }
                    }

                if (isNew) {
                    Episode episode = new Episode();
                    episode.Name = item.Title.Text;
                    episode.Description = item.Summary.Text;
                    // TODO: Fix so that new episodes show on top of listview!
                    feed.ListOfEpisodes.Add(episode);
                }
            }
        }

        private void UpdateCategoryNameForFeeds(string oldCategoryName, string newCategoryName, List<Feed> listOfFeeds)
        {
            foreach (Feed feed in listOfFeeds)
            {
                if (feed.Category.Equals(oldCategoryName))
                {
                    feed.Category = newCategoryName;
                }
            }
        }

        private void lvFeeds_OnItemClick(object sender, EventArgs e)
        {
            
            String feedName = ListViewHelper.GetSelectedItem(lvFeeds);

            // Change text on Episode listview header, to the name if chosen feed
            lvEpisodes.Columns[0].Text = feedName;
           
          
            ShowEpisodesInListView(GetListOfEpisodesForChosenFeed(feedName)); 

        }

        private List<Episode> GetListOfEpisodesForChosenFeed(String feedName)
        {
            List<Episode> listOfEpisodes = new List<Episode>();

            if (feedName != null)
            {
                foreach (Feed feed in ListOfFeeds)
                {
                    if (feed.Name.Equals(feedName))
                    {
                        listOfEpisodes = feed.ListOfEpisodes;
                    }
                }
            }

            return listOfEpisodes;
        }



        private void cbSortByCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = cbSortByCategory.SelectedItem.ToString();
            List<Feed> listOfFeedsByCategory = new List<Feed>();
            foreach (Feed feed in ListOfFeeds)
            {
                if (feed.Category.Equals(category))
                {
                    listOfFeedsByCategory.Add(feed);
                }
            }
            ShowFeedsInListView(listOfFeedsByCategory);
        }
    }
}
