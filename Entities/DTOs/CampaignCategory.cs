using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    
        public class CampaignCategoryDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Slug { get; set; }
        }

        public class CampaignCategoryCreateDto
        {
            public string Name { get; set; }
            public string Slug { get; set; }
        }

        public class CampaignCategoryUpdateDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Slug { get; set; }
        }
    
}
