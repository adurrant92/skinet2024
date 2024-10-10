using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        // return list 

        Task<IReadOnlyList<Product>> GetProductsAsync();

        // single product 

        Task<Product?> GetProductByIdAsync(int id);


        // add
        void AddProduct(Product product);

        //update
        void UpdateProduct(Product product);

        //delete        
        void DeleteProduct(Product product);

        //exsists 
        bool ProductExists(int id);

        Task<bool> SaveChangesAsync();



    }
}