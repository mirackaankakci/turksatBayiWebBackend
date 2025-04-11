using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICampaignService
    {
        Task<List<Campaign>> GetAllAsync();
        Task<Campaign> GetByIdAsync(int id);
        Task AddAsync(Campaign campaign);
        Task UpdateAsync(Campaign campaign);
        Task DeleteAsync(Campaign campaign);

    }
}
