namespace DbcWebApi.Models.Dogs
{
    public class UpdateDogModel
    {
        public int Id { get; set; }
        public bool IsForSale { get; set; }
        public int Price { get; set; }
    }
}