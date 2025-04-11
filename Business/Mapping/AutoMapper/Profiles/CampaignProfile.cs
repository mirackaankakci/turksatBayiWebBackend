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
    public class CampaignProfile : Profile
    {
        public CampaignProfile()
        {
            CreateMap<Campaign, CampaignDto>()
                .ForMember(dest => dest.Categories,
                           opt => opt.MapFrom(src => src.CampaignCategories.Select(cc => cc.Category.Name)))
                .ForMember(dest => dest.Features,
                           opt => opt.MapFrom(src => src.Features.Select(f => f.FeatureText)))
                .ForMember(dest => dest.PricingOptions,
                           opt => opt.MapFrom(src => src.PricingOptions));

            CreateMap<CampaignPricingOption, PricingOptionDto>();


            CreateMap<CampaignCreateDto, Campaign>()
    .ForMember(dest => dest.PricingOptions,
               opt => opt.MapFrom(src => src.PricingOptions))
    .ForMember(dest => dest.Features,
               opt => opt.MapFrom(src =>
                   src.Features.Select(f => new CampaignFeature { FeatureText = f })));

            CreateMap<PricingOptionCreateDto, CampaignPricingOption>();


            CreateMap<CampaignUpdateDto, Campaign>()
    .ForMember(dest => dest.PricingOptions,
               opt => opt.MapFrom(src => src.PricingOptions))
    .ForMember(dest => dest.Features,
               opt => opt.MapFrom(src =>
                   src.Features.Select(f => new CampaignFeature { FeatureText = f })));


        }

    }
}
