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

            // TODO: Deserialize
            cbCategory.Items.Add("Nyheter");

            // TODO: populate feeds listview
            // TODO: populate category combobox
        }

        private void btnSaveFeed_Click(object sender, EventArgs e)
        {
            // TODO: add validation / exceptions on input

            string url = tbUrl.Text;
            string name = tbFeedName.Text;
            string category =  cbCategory.SelectedItem.ToString();
    
            Feed feed = new Feed(name, url,category);
            listOfFeeds.Add(feed);

            SerializerForXml serializerForXml = new SerializerForXml();
            serializerForXml.SerializeFeed(listOfFeeds);

            tbUrl.Clear();
            tbFeedName.Clear();
        }

        private void btnEditFeed_Click(object sender, EventArgs e)
        {
            SerializerForXml serializerForXml = new SerializerForXml();
            listOfFeeds = serializerForXml.DeserializeFeed();
            Console.WriteLine("Feeds i lista: " + listOfFeeds.Count);


            // TODO: Find object by id
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

            SerializerForXml serializerForXml=new SerializerForXml();
            List<Feed> testList = new List<Feed>();
            Feed feed = new Feed();
            testList = serializerForXml.DeserializeFeed();
            ShowFeedsInListView(testList);
        }

        private void ShowFeedsInListView(List<Feed> listOfFeeds)
        {
            foreach(Feed feed in listOfFeeds)
            {
                string[] row = { feed.Name, "0" };
                var listViewItem = new ListViewItem(row);
                lvFeeds.Items.Add(listViewItem);
            }
        }
    }
}
