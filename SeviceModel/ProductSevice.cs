using App.Models;

namespace App.Sevice
{
    public class ProductSevice : List<ProductModel>
    {
        public ProductSevice()
        {
            this.AddRange(new ProductModel[]{
                new ProductModel(){id=1, name="iphone", price=2000},
                new ProductModel(){id=2, name="samsung", price=1500},
                new ProductModel(){id=3, name="nokia", price=1000},
            });
        }
    }

}