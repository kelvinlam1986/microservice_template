using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Api.Queries.Dtos
{
    public class ProductDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public IList<CoverDTO> Covers { get; set; }
        public IList<QuestionDTO> Questions { get; set; }
        public int MaxNumberOfInsured { get; set; }
        public string Icon { get; set; }
    }
}
