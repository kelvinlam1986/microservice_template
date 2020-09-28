namespace ProductService.Api.Queries.Dtos
{
    public class CoverDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Desctiption { get; set; }
        public bool Optional { get; set; }
        public decimal? SumInsured { get; set; }
    }
}
