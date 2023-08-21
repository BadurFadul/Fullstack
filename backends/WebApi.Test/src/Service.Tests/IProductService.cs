using AutoMapper;
using Moq;
using WebApi.Business.Src.Abstractions;
using WebApi.Business.Src.Dtos;
using WebApi.Business.Src.Implementations;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;
using WebApi.Domain.Src.Shared;
using Xunit;

namespace WebApi.Test.src.Service.Tests
{
    public class IProductService
    {
        private readonly Mock<IProductRepo> _productRepo;
        private readonly Mock<IBaseRepo<Category>> _categoryRepo; // Mock for IBaseRepo<Category>
        private readonly ProductService _productService;  // Change this line
        private readonly Mock<IMapper> _mockMapper;
        public IProductService()
        {
            _productRepo = new Mock<IProductRepo>();
            _categoryRepo = new Mock<IBaseRepo<Category>>(); // Initialize the mock
            _mockMapper = new Mock<IMapper>();
            _productService = new ProductService(_productRepo.Object, _categoryRepo.Object, _mockMapper.Object);
        }
        [Fact]
        public async Task GetAll_ReturnsAllProducts ()
        {
            // Arrange
            var products = new List<Product> { new Product (), new Product ()};
            var productReadDto = new List<ProductReadDto> { new ProductReadDto(), new ProductReadDto()};
            var queryOptions = new Options();

            _productRepo.Setup(repo => repo.GetAll(queryOptions)).ReturnsAsync(products);
            _mockMapper.Setup(m => m.Map<IEnumerable<ProductReadDto>>(products)).Returns(productReadDto);

            // Act
            var result = await _productService.GetAll(queryOptions);

            // Assert
            Assert.Equal(productReadDto, result);
        }

        [Fact]
        public async Task GetById_ReturnsById ()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var product = new Product();
            var productReadDto = new ProductReadDto();

            _productRepo.Setup(repo => repo.GetById(id)).ReturnsAsync(product);
            _mockMapper.Setup(m => m.Map<ProductReadDto>(product)).Returns(productReadDto);

            // Act 
            var result = await _productService.GetById(id);

            // Assert
            Assert.Equal(productReadDto, result);
        }

        [Fact]
        public async Task PostProduct_ReturnsNewProduct()
        {
            // Arrange
            var category = new Category { Id = Guid.NewGuid(), name = "space" };
            Guid id = Guid.NewGuid();
            var productCreateDto = new ProductCreateDto { Name = "join", Price = 12, CategoryId = id };
            var product = new Product();
            var productReadDto = new ProductReadDto();

            _productRepo.Setup(repo => repo.postItem(product)).ReturnsAsync(product);
            _mockMapper.Setup(m => m.Map<ProductReadDto>(product)).Returns(productReadDto);

            // Act
            var result = await _productService.postItem(productCreateDto); // Need to await the async method

            // Assert
            Assert.Equal(productReadDto, result);
        }

        [Fact]
        public async Task UpdateProduct_UpdatesAndReturnsProduct()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var Product = new Product { Id = productId, Name = "Space"};
            var updatedProduct = new Product { Id = productId, Name = "Space Toon"};
            var productUpdateDto = new ProductUpdateDto {Name = "Space Toon"};
            var productRead = new ProductReadDto {Id = productId, Name = "Space Toon"};

            //_productRepo.Setup(repo => repo.GetById(productId)).ReturnsAsync(updatedProduct);
            _productRepo.Setup(repo => repo.UpdateItem(productId,Product)).ReturnsAsync(Product);

            //
            var result = await _productService.UpdateItem(productId, productUpdateDto);

            //Assert
            Assert.Equal(productRead, result);
        }

        [Fact]
        public async Task DeleteProduct_ReturnedDeleteProduct()
        {
            var productId = Guid.NewGuid();
            var product = new Product { Id = productId, Name = "Space"};

            _productRepo.Setup(repo => repo.GetById(productId)).ReturnsAsync(product);
            _productRepo.Setup(repo => repo.DeleteItem(It.IsAny<Product>())).ReturnsAsync(true);

            // Act
            var result = await _productService.DeleteItem(productId);

            // Assert
            Assert.True(result);
        }
    }
}