using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Services.Facade
{
    public class ShopFacade
    {
        //Facade Pattern
        //Just concerned with the Menu not interested in the complicated implementation
        //example is a library or a restuarant
        //expose only things for the consumer to interact with
        //interface segregation
        public interface IShopContext
        {
            public List<Product> AddtoCart(Product product);
            public List<Product> RemoveFromCart(Product product);
            public List<Product> GetProducts();
            public string Checkout();
        }


        //Mediator
        //Stands between 2 or more complex objects and handles interaction between them
        //Single responsibility each class is only aware of wat it does 
        //interaction between classes is exposed through the mediator
        public class ShopContext : IShopContext
        {
            private Cart _cart;
            private Catalog _catalog;

            public ShopContext(Cart cart, Catalog catalog)
            {
                _cart = cart;
                _catalog = catalog;
            }
            public List<Product> AddtoCart(Product product)
            {
                _cart.addToCart(product);
                return _cart.products;
            }


            public List<Product> RemoveFromCart(Product product)
            {
                _cart.removeFromCart(product.id);
                return _cart.products;
            }

            public List<Product> GetProducts()
            {
                return _catalog.getProducts();
            }

            public string Checkout()
            {
                return _cart.Checkout();
            }
        }

        public class Product
        {
            public string id { get; set; }
            public string name { get; set; }
            public int quantity { get; set; }
        }

        public class Cart
        {
            public List<Product> products;
            public Cart()
            {
                products = new List<Product>();
            }
            public void addToCart(Product product)
            {
                var orderProduct = products.Where(p => p.id == product.id).FirstOrDefault();
                if(orderProduct != null)
                {
                    orderProduct.quantity += 1;
                }
                else
                {
                    product.quantity = 1;
                    products.Add(product);
                }
            }

            public void removeFromCart(string id)
            {
                var orderProduct = products.Where(p => p.id == id).FirstOrDefault();
                if (orderProduct != null)
                {
                    if(orderProduct.quantity > 1)
                        orderProduct.quantity += 1;
                    if (orderProduct.quantity == 1)
                        products.Remove(orderProduct);
                }
            }

            public string Checkout()
            {
                return products.ToString();
            }
        }

        public class Catalog
        {
            List<Product> _products;

            public Catalog()
            {
                _products = new List<Product>();
                _products.Add(new Product { name = "Product 1", id = "213219" });
                _products.Add(new Product { name = "Product 2", id = "432534" });
                _products.Add(new Product { name = "Product 3", id = "322345" });
            }
            public List<Product> getProducts()
            {
                return _products;
            }
        }


    }
}