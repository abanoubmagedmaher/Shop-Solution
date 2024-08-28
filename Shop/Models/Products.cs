using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shop.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImagegUrl { get; set; }
        public string? DescreptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        #region Product Count
        public decimal? TotalCount { get; set; }
        public decimal? MinCount { get; set; }
        public decimal? CountInStock { get; set; } //i mean websiteStock
        public decimal? MinCountInStock { get; set; }//i mean websiteStock
        public bool? OutOfStock { get; set; }

        #endregion

        #region Product Price
        public decimal? price { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Vat { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Services { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? ConventionalRate { get; set; }

        public string? DeliveryWay { get; set; }
        public string? DeliveryFees { get; set; }
        public int? DeliveryDays { get; set; }
        public string? Address{ get; set; }

        public decimal? discounted { get; set; }

        public string ProductCompany { get; set; }


        #endregion
    }
}
