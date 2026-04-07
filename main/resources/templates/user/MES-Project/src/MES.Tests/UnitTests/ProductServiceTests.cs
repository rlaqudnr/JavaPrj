using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;
using MES.Core.Services;
using MES.Data.Entities;
using MES.Data.Repositories;

namespace MES.Tests.UnitTests
{
    public class ProductServiceTests
    {
        private readonly ProductService _productService;
        private readonly Mock<IRepository<ProductEntity>> _mockRepository;

        public ProductServiceTests()
        {
            _mockRepository = new Mock<IRepository<ProductEntity>>();
            _productService = new ProductService(_mockRepository.Object);
        }

        [Fact]
        public async Task AddProduct_ShouldAddProduct_WhenProductIsValid()
        {
            var product = new ProductEntity { Name = "Test Product", Price = 10.0m };

            await _productService.AddProductAsync(product);

            _mockRepository.Verify(repo => repo.AddAsync(product), Times.Once);
        }

        [Fact]
        public async Task GetProduct_ShouldReturnProduct_WhenProductExists()
        {
            var productId = Guid.NewGuid();
            var product = new ProductEntity { Id = productId, Name = "Test Product", Price = 10.0m };
            _mockRepository.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync(product);

            var result = await _productService.GetProductAsync(productId);

            Assert.Equal(product, result);
        }

        [Fact]
        public async Task UpdateProduct_ShouldUpdateProduct_WhenProductIsValid()
        {
            var product = new ProductEntity { Id = Guid.NewGuid(), Name = "Updated Product", Price = 15.0m };

            await _productService.UpdateProductAsync(product);

            _mockRepository.Verify(repo => repo.UpdateAsync(product), Times.Once);
        }

        [Fact]
        public async Task DeleteProduct_ShouldDeleteProduct_WhenProductExists()
        {
            var productId = Guid.NewGuid();

            await _productService.DeleteProductAsync(productId);

            _mockRepository.Verify(repo => repo.DeleteAsync(productId), Times.Once);
        }
    }
}