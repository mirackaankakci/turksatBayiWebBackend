using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CampaignTabContent:IEntity
    {
        public int Id { get; set; }

        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }

        public int CampaignTabId { get; set; }
        public CampaignTab CampaignTab { get; set; }

        public string Content { get; set; } // HTML or text
    }
}
