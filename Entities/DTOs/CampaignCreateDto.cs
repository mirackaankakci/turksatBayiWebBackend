using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CampaignCreateDto
    {
        public string Name { get; set; }
        public List<PricingOptionCreateDto> PricingOptions { get; set; }
        public List<string> Features { get; set; }
    }

    public class PricingOptionCreateDto
    {
        public int ContractMonths { get; set; }
        public decimal PriceMonthly { get; set; }
        public decimal? PriceMonthlyAfter { get; set; }
    }
}
