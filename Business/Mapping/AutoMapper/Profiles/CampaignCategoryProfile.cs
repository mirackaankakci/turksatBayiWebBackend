using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper.Profiles
{
    public class CampaignCategoryProfile : Profile
    {
        public CampaignCategoryProfile()
        {
            CreateMap<CampaignCategory, CampaignCategoryDto>().ReverseMap();
            CreateMap<CampaignCategoryCreateDto, CampaignCategory>();
            CreateMap<CampaignCategoryUpdateDto, CampaignCategory>();
        }
    }
}
