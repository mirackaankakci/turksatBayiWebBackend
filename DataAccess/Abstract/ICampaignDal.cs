using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{

    public interface ICampaignDal: IEntityRepository<Campaign>
    {
        Task<Campaign> GetCampaignWithDetailsAsync(int id);
        Task<List<Campaign>> GetAllWithDetailAsync();
        Task AddCampaignAsync(Campaign campaign);
        Task UpdateCampaignAsync(Campaign campaign);
        Task DeleteAsync(Campaign campaign);
    }
}
