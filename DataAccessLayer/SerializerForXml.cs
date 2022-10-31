using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Models;


namespace DataAccess
{
    public class SerializerForXml
    {
       public SerializerForXml()
        {

        }
        public void SerializeFeed(List<Feed> listOfFeeds)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Feed>));
                using (FileStream fileStream = new FileStream("Feeds.xml", FileMode.Create,
                    FileAccess.Write))
                {
                    xmlSerializer.Serialize(fileStream, listOfFeeds);
                }
            }
            catch(Exception)
            {
                throw new Exception("Feeds.xml could not be serialized");
            }
        }

        public List<Feed> DeserializeFeed()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Feed>));
                using (FileStream fileStream = new FileStream("Feeds.xml",
                    FileMode.Open, FileAccess.Read))
                {
                    return (List<Feed>)xmlSerializer.Deserialize(fileStream);
                }
            }
            catch(Exception)
            {
                throw new Exception("Feeds.xml could not be deserialized");
            }
        }

        public void SerializeCategory(List<Category> listOfCategories)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Category>));
                using (FileStream fileStream = new FileStream("Categories.xml", FileMode.Create,
                    FileAccess.Write))
                {
                    xmlSerializer.Serialize(fileStream, listOfCategories);
                }
            }
            catch(Exception)
            {
                throw new Exception("Categories.xml could not be serialized");
            }  
        }

        public List<Category> DeserializeCategory()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Category>));
                using (FileStream fileStream = new FileStream("Categories.xml",
                    FileMode.Open, FileAccess.Read))
                {
                    return (List<Category>)xmlSerializer.Deserialize(fileStream);
                }
            }
            catch(Exception)
            {
                throw new Exception("Categories.xml could not be deserialized");
            }
        }
    } 
}
