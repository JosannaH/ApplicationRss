using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Episode : Entity
    {
        public string Description { get; set; }
       // public TextSyndicationContent Content { get; set; }

        public Episode()
        {

        }
    }
}
