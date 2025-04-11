using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CampaignTab
    {
        public int Id { get; set; }
        public string Key { get; set; }     // pricing, details, etc.
        public string Name { get; set; }
        public int OrderIndex { get; set; }

        public ICollection<CampaignTabContent> TabContents { get; set; }
    }
}

