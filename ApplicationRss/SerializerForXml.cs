using BusinessLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ApplicationRss
{
    public class SerializerForXml
    {
        public void SerializeFeed(Feed feed)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Feed));

            using (FileStream fileStream = new FileStream("Feeds.xml", FileMode.Append,
                FileAccess.Write))
            {
                xmlSerializer.Serialize(fileStream, feed);
            }
        }

        public Feed DeserializeFeed()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Feed));
            using(FileStream fileStream = new FileStream("Feeds.xml", 
                FileMode.Open, FileAccess.Read))
            {
                return (Feed)xmlSerializer.Deserialize(fileStream);
            }
        }
    }
}
