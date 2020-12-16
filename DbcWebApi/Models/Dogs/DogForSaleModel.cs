using DbcWebApi.Entities;

namespace DbcWebApi.Models.Dogs
{
    public class DogForSaleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Years { get; set; }
        public int Months { get; set; }
        public Sex Sex { get; set; }
        public bool IsForSale { get; set; }
        public int Price { get; set; }
        public string PhotoUrl { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhone { get; set; }
        public string OwnerEmail { get; set; }
    }
}