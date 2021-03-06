namespace DbcWebApi.Entities
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Years { get; set; }
        public int Months { get; set; }
        public Sex Sex { get; set; }
        public bool IsForSale { get; set; }
        public int Price { get; set; }
        public string PhotoUrl { get; set; }
        public User Owner { get; set; }
    }

    public enum Sex
    {
        Male,
        Female
    }
}