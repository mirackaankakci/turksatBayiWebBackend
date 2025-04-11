using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQL Server connection (LocalDB instance)  
            optionsBuilder.UseSqlServer(@"Server=MIRAÇ;Database=CampaignDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignCategory> CampaignCategories { get; set; }
        public DbSet<CampaignCategoryPivot> CampaignCategoryPivots { get; set; }
        public DbSet<CampaignTab> CampaignTabs { get; set; }
        public DbSet<CampaignTabContent> CampaignTabContents { get; set; }
        public DbSet<CampaignPricingOption> CampaignPricingOptions { get; set; }
        public DbSet<CampaignFeature> CampaignFeatures { get; set; }
    }
            
}
