namespace Shop.Models
{
    public class ProductsBL
    {
        #region Static List
        List<Products> product;
        public ProductsBL()
        {
            product = new List<Products>();
            product.Add(
                new Products()
                {
                    Id = 1,
                    Name = "GoldProduct001",
                    ImagegUrl = "1.png",
                    price = 15000

                }
                );
            product.Add(
                new Products()
                {
                    Id = 2,
                    Name = "GoldProduct002",
                    ImagegUrl = "2.png",
                    price = 25000
                }
                );
            product.Add(
            new Products()
            {
                Id = 3,
                Name = "GoldProduct003",
                ImagegUrl = "3.png",
                price = 20000
            }
            );
            product.Add(
new Products()
{
    Id = 4,
    Name = "GoldProduct004",
    ImagegUrl = "4.png",
    price = 30000
}
);

            product.Add(
new Products()
{
    Id = 5,
    Name = "GoldProduct005",
    ImagegUrl = "5.png",
    price = 35000
}
);

        } 
        #endregion

        public List<Products> GetAll()
        {
            return product;
        }
        public Products GetById(int id)
        {
            return product.FirstOrDefault(p => p.Id == id);
        }
    }
}
