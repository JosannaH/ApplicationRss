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

namespace ApplicationRss
{
    [Serializable]
    [XmlInclude(typeof(Form1))]
    public partial class Form1 : Form
    {
        List<Feed> listOfFeeds = new List<Feed>();

        public Form1()
        {
            InitializeComponent();

            SerializerForXml serializerForXml = new SerializerForXml();
            listOfFeeds = serializerForXml.DeserializeFeed();

            UpdateEpisodesForAllFeeds(listOfFeeds);
            ShowFeedsInListView(listOfFeeds);

            cbCategory.Items.Add("Nyheter");

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
            listOfFeeds.Add(feed);

            SerializerForXml serializerForXml = new SerializerForXml();
            serializerForXml.SerializeFeed(listOfFeeds);

            ShowFeedsInListView(listOfFeeds);
            ShowEpisodesInListView(feed.ListOfEpisodes);
            lvEpisodes.Columns[0].Text = feed.Name;

            tbUrl.Clear();
            tbFeedName.Clear();
        }

        private void btnEditFeed_Click(object sender, EventArgs e)
        {
            // Temporarily used as test button
            SerializerForXml serializerForXml = new SerializerForXml();
            listOfFeeds = serializerForXml.DeserializeFeed();


            ShowFeedsInListView(listOfFeeds);


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
            // TODO: Save in ListOfCategories
            string categoryName = tbNewCategoryName.Text;
            Category category = new Category(categoryName);

            //category.Id = method to generate Id
            category.ListOfCategories.Add(category);

            

            // TODO: Update listview
            // TODO: add validation / exceptions on input
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            // TODO: Find object by id in ListOfCategories, update name
            // TODO: Update listview
            // TODO: Update cbSortByCategory

            // TODO: add validation / exceptions on input
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

        // Get all episodes for one Feed
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

        // Get new episodes for all feeds
        private void UpdateEpisodesForAllFeeds(List<Feed> listOfFeeds)
        {
            foreach(Feed feed in listOfFeeds)
            {
                UpdateListOfEpisodes(feed.Url, feed);
            }
        }

        // Get new episodes for one Feed
        private void UpdateListOfEpisodes(String url, Feed feed)
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

        private void lvFeeds_OnItemClick(object sender, EventArgs e)
        {
            
            String feedName = ListViewHelper.GetSelectedItem(lvFeeds);

            // Change text on Episode listview header, to the name if chosen feed
            lvEpisodes.Columns[0].Text = feedName;
           
          
            ShowEpisodesInListView(GetListOfEpisodesForChosenFeed(feedName)); 

        }

        //
        private List<Episode> GetListOfEpisodesForChosenFeed(String feedName)
        {
            List<Episode> listOfEpisodes = new List<Episode>();

            if (feedName != null)
            {
                foreach (Feed feed in listOfFeeds)
                {
                    if (feed.Name.Equals(feedName))
                    {
                        listOfEpisodes = feed.ListOfEpisodes;
                    }
                }
            }

            return listOfEpisodes;
        }
    }
}
