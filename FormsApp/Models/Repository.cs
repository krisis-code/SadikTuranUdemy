namespace FormsApp.Models;

public class Repository
{
   private static readonly List<Product> _products = new();
   private static readonly List<Category> _categories = new();

    static Repository()
    {
         _categories.Add(new Category{CategoryId = 0 , Name = "Hepsi"});
        _categories.Add(new Category{CategoryId = 1 , Name = "Telefon"});
        _categories.Add(new Category{CategoryId = 2 , Name = "Bilgisayar"});

         _products.Add(new Product{ProductId = 1 , Name = "iPhone 13  satın alın",Price= 40000, IsActive = true ,Image = "1.jpg" , CategoryId =1});

         _products.Add(new Product{ProductId = 2 , Name = "iPhone 13  satın alın",Price= 40000, IsActive = true ,Image = "2.jpg",CategoryId =1});

         _products.Add(new Product{ProductId = 3 , Name = "iPhone 15 Pro satın alın",Price= 60000, IsActive = true ,Image = "3.jpg",CategoryId=1});

         _products.Add(new Product{ProductId = 4 , Name = "iPhone 15 Pro satın alın",Price= 60000, IsActive = false ,Image = "4.jpg",CategoryId=1});

         _products.Add(new Product{ProductId = 5 , Name = "iPhone 15 Pro satın alın",Price= 60000, IsActive = true ,Image = "5.jpg",CategoryId=1});

         _products.Add(new Product{ProductId = 6 , Name = "iPhone 15 Pro Max satın alın",Price= 80000, IsActive = false ,Image = "6.jpg",CategoryId =1});

         _products.Add(new Product{ProductId = 7 , Name = "iPhone 15 Pro Max satın alın",Price= 80000, IsActive = true ,Image = "7.jpg",CategoryId=1});

         _products.Add(new Product{ProductId = 8 , Name = "14 inç MacBook Pro’nuzu",Price= 80000, IsActive = true ,Image = "8.jpg",CategoryId=2});

        _products.Add(new Product{ProductId = 9 , Name = "14 inç MacBook Air",Price= 50000, IsActive = true ,Image = "9.jpg",CategoryId=2});
        
    }
   public static  List<Product> Products 
   {
    get{
        return _products;
    }

   }

   public static void CreateProduct(Product entity)
   {
    _products.Add(entity);
   }

   public static void EditProduct(Product updatedProduct)
   {
    var entity = _products.FirstOrDefault(p => p.ProductId == updatedProduct.ProductId);
    if(entity != null)
    {
        entity.Name = updatedProduct.Name;
        entity.Price = updatedProduct.Price;
        entity.Image = updatedProduct.Image;
        entity.CategoryId = updatedProduct.CategoryId;
    }
   }

   public static List<Category> Categories
   {
    get{
        return _categories;
    }
   }


}
