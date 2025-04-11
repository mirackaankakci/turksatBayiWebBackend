using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CampaignUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PricingOptionCreateDto> PricingOptions { get; set; }
        public List<string> Features { get; set; }
    }
}
