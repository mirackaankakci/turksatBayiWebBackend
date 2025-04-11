using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CampaignManager : ICampaignService
    {
        private readonly ICampaignDal _campaignDal;
        public CampaignManager(ICampaignDal campaignDal)
        {
            _campaignDal = campaignDal;
        }
        public Task AddAsync(Campaign campaign)
        {
            return _campaignDal.AddCampaignAsync(campaign);
        }

        public Task DeleteAsync(Campaign campaign)
        {
             
            return _campaignDal.DeleteAsync(campaign);
        }

        public Task<List<Campaign>> GetAllAsync()
        {
            return _campaignDal.GetAllWithDetailAsync();
        }

        public Task<Campaign> GetByIdAsync(int id)
        {
            return _campaignDal.GetCampaignWithDetailsAsync(id);
        }

        public Task UpdateAsync(Campaign campaign)
        {
            return _campaignDal.UpdateCampaignAsync(campaign);
        }
    }
}
