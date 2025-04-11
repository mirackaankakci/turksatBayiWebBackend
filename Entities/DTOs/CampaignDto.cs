using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CampaignDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<string> Categories { get; set; } // Sadece isimleri gösteriyoruz

        public List<string> Features { get; set; }   // Avantajlar

        public List<PricingOptionDto> PricingOptions { get; set; }
    }

    public class PricingOptionDto
    {
        public int ContractMonths { get; set; }
        public decimal PriceMonthly { get; set; }
        public decimal? PriceMonthlyAfter { get; set; }
    }
}
