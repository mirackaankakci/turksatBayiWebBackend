using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            Console.WriteLine("🚀 Seed başladı");

            // CampaignTabs
            if (!context.CampaignTabs.Any())
            {
                var pricingTab = new CampaignTab { Key = "pricing", Name = "Ücretlendirme", OrderIndex = 1 };
                var detailsTab = new CampaignTab { Key = "details", Name = "Detaylar", OrderIndex = 2 };
                var contactTab = new CampaignTab { Key = "contact", Name = "İletişim", OrderIndex = 3 };

                context.CampaignTabs.AddRange(pricingTab, detailsTab, contactTab);
                await context.SaveChangesAsync();

                // CampaignCategories
                if (!context.CampaignCategories.Any())
                {
                    var categoryTv = new CampaignCategory { Name = "TV", Slug = "tv" };
                    var categoryNet = new CampaignCategory { Name = "İnternet", Slug = "internet" };

                    context.CampaignCategories.AddRange(categoryTv, categoryNet);
                    await context.SaveChangesAsync();

                    // Campaign
                    if (!context.Campaigns.Any())
                    {
                        var campaign = new Campaign
                        {
                            Name = "Her eve kablonet",
                            CampaignCategories = new List<CampaignCategoryPivot>
                            {
                                new() { CategoryId = categoryTv.Id },
                                new() { CategoryId = categoryNet.Id }
                            },
                            PricingOptions = new List<CampaignPricingOption>
                            {
                                new() { ContractMonths = 2, PriceMonthly = 3, PriceMonthlyAfter = 1 },
                                new() { ContractMonths = 24, PriceMonthly = 179, PriceMonthlyAfter = 200 }
                            },
                            Features = new List<CampaignFeature>
                            {
                                new() { FeatureText = "Ücretsiz kurulum", OrderIndex = 1 },
                                new() { FeatureText = "Docsis modem" }
                            },
                            TabContents = new List<CampaignTabContent>
                            {
                                new() { CampaignTabId = pricingTab.Id, Content = "Aylık ücret detayları" },
                                new() { CampaignTabId = detailsTab.Id, Content = "Detay içerik burada" },
                                new() { CampaignTabId = contactTab.Id, Content = "İletişim için 444 0 123" }
                            },
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow,
                            IsActive = true
                        };

                        context.Campaigns.Add(campaign);
                        await context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
