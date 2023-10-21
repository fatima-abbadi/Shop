using System.ComponentModel.DataAnnotations;

namespace ReactAspCrud.Models
{
    public class Shop
    {
        [Key]
        public int ShopID { get; set; }

        public string ShopName { get; set; }
        public string Description { get; set; }
        public float shop_location_latitude { get; set; }
        public float shop_location_longitude { get; set; }
        public int OwnerUserId { get; set; }
        public string  Address { get; set; }
        public string phoneNumber { get; set; }



    }
}
