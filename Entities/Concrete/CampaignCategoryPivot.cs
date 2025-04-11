using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CampaignCategoryPivot:IEntity
    {
        public int Id { get; set; }

        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }

        public int CategoryId { get; set; }
        public CampaignCategory Category { get; set; }
    }
}
