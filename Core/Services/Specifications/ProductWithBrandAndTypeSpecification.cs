using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal class ProductWithBrandAndTypeSpecification : Specifications<Product>
    {
        //use to reteieve product by id
        public ProductWithBrandAndTypeSpecification(int id): base(product=>product.Id==id)
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
        }

        // use all products
        public ProductWithBrandAndTypeSpecification() : base(null)
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
        }
    }
}
