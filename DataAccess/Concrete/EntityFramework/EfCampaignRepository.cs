using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCampaignRepository : EfEntityRepositoryBase<Campaign, AppDbContext>, ICampaignDal
    {
        public async Task<Campaign> GetCampaignWithDetailsAsync(int id)
        {
            using (var context = new AppDbContext())
            {
                return await context.Campaigns
                    .Include(c => c.CampaignCategories).ThenInclude(cc => cc.Category)
                    .Include(c => c.PricingOptions)
                    .Include(c => c.Features)
                    .Include(c => c.TabContents).ThenInclude(tc => tc.CampaignTab)
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
        }
        public async Task<List<Campaign>> GetAllWithDetailAsync()
        {
            using (var context = new AppDbContext())
            {
                return await context.Campaigns
                    .Include(c => c.CampaignCategories).ThenInclude(cc => cc.Category)
                    .Include(c => c.PricingOptions)
                    .Include(c => c.Features)
                    .Include(c => c.TabContents).ThenInclude(tc => tc.CampaignTab)
                    .ToListAsync();
            }


        }

        public async Task AddCampaignAsync(Campaign campaign)
        {
            using (var context = new AppDbContext())
            {
                await context.Campaigns.AddAsync(campaign);

                // Bağlı collection'ları elle track et (özellikle EF bazen atlar!)
                if (campaign.PricingOptions != null && campaign.PricingOptions.Any())
                    context.CampaignPricingOptions.AddRange(campaign.PricingOptions);

                if (campaign.Features != null && campaign.Features.Any())
                    context.CampaignFeatures.AddRange(campaign.Features);

                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateCampaignAsync(Campaign campaign)
        {
            using var context = new AppDbContext();

            // önce bağlı alt tabloları sil (fiyat + özellik)
            var oldFeatures = context.CampaignFeatures.Where(f => f.CampaignId == campaign.Id);
            var oldPricing = context.CampaignPricingOptions.Where(p => p.CampaignId == campaign.Id);

            context.CampaignFeatures.RemoveRange(oldFeatures);
            context.CampaignPricingOptions.RemoveRange(oldPricing);

            context.Campaigns.Update(campaign);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Campaign campaign)
        {
            using var context = new AppDbContext();

            // İlişkili verileri sil
            var features = context.CampaignFeatures.Where(f => f.CampaignId == campaign.Id);
            var pricing = context.CampaignPricingOptions.Where(p => p.CampaignId == campaign.Id);
            var pivots = context.CampaignCategoryPivots.Where(p => p.CampaignId == campaign.Id);
            var tabContents = context.CampaignTabContents.Where(t => t.CampaignId == campaign.Id);

            context.CampaignFeatures.RemoveRange(features);
            context.CampaignPricingOptions.RemoveRange(pricing);
            context.CampaignCategoryPivots.RemoveRange(pivots);
            context.CampaignTabContents.RemoveRange(tabContents);

            context.Campaigns.Remove(campaign);

            await context.SaveChangesAsync();
        }


    }
}
