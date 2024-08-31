namespace Shop.Models
{
    public class ProductsBL
    {
        #region Static List
        List<Products> Product;
        public ProductsBL()
        {
            Product = new List<Products>();
            Product.Add(
                new Products()
                {
                    Id = 1,
                    Name = "GoldProduct001",
                    ImagegUrl = "1.JPG",
                    price = 15000

                }
                );
            Product.Add(
                new Products()
                {
                    Id = 2,
                    Name = "GoldProduct002",
                    ImagegUrl = "2.JPG",
                    price = 25000
                }
                );
            Product.Add(
            new Products()
            {
                Id = 3,
                Name = "GoldProduct003",
                ImagegUrl = "3.JPG",
                price = 20000
            }
            );
            Product.Add(
new Products()
{
    Id = 4,
    Name = "GoldProduct004",
    ImagegUrl = "4.JPG",
    price = 30000
}
);

            Product.Add(
new Products()
{
    Id = 5,
    Name = "GoldProduct005",
    ImagegUrl = "5.JPG",
    price = 35000
}
);

        } 
        #endregion

        public List<Products> GetAll()
        {
            return Product;
        }
        public Products GetById(int id)
        {
            return Product.FirstOrDefault(p => p.Id == id);
        }
    }
}
