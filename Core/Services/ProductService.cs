using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Services.Abstraction;
using Services.Specifications;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {
        public async Task<IEnumerable<BrandResultDTO>> GetAllBrandsAsync()
        {
            //1-retrive all brands => unitofwork
            var brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            //2- maap to brand resultDto=> IMapaer
          var  barndResult= mapper.Map<IEnumerable<BrandResultDTO>>(brands);
            // return

         return barndResult;
        }

        public async Task<IEnumerable<ProductResultDTO>> GetAllProductsAsync()
        {
          var products= await unitOfWork.GetRepository<Product, int>()
                .GetAllAsync(new ProductWithBrandAndTypeSpecification());
            var productsResult=mapper.Map<IEnumerable<ProductResultDTO>>(products); 
            return productsResult;
        }

        public async Task<IEnumerable<TypeResultDTO>> GetAllTypesAsync()
        {
           var types= await unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var typesResult= mapper.Map<IEnumerable<TypeResultDTO>>(types);
            return typesResult;
        }

        public async Task<ProductResultDTO> GetProductByIdAsync(int id)
        {
            var product=await unitOfWork.GetRepository<Product,int>()
                .GetAsync(new ProductWithBrandAndTypeSpecification(id));
            var productResult= mapper.Map<ProductResultDTO>(product);
            return productResult;
        }
    }
}
