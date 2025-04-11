using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Campaign:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<CampaignCategoryPivot> CampaignCategories { get; set; }
        public ICollection<CampaignTabContent> TabContents { get; set; }
        public ICollection<CampaignPricingOption> PricingOptions { get; set; }
        public ICollection<CampaignFeature> Features { get; set; }
    }
}
