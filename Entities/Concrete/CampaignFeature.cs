using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CampaignFeature:IEntity
    {
        public int Id { get; set; }

        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }

        public string? IconType { get; set; }     // optional: 'tv', 'modem'
        public string FeatureText { get; set; }
        public int OrderIndex { get; set; }
    }
}
