using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CampaignPricingOption:IEntity
    {
        public int Id { get; set; }

        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }

        public string? Title { get; set; }
        public int ContractMonths { get; set; }
        public decimal PriceMonthly { get; set; }
        public decimal? PriceMonthlyAfter { get; set; }

    }
}
