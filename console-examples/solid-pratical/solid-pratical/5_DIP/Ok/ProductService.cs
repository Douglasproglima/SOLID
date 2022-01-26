using System;
using solid_pratical._5_DIP.Ok.Interfaces;

namespace solid_pratical._5_DIP.Ok
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileLogger _fileLogger;
        public ProductService(IProductRepository productRepository, IFileLogger fileLogger)
        {
            _productRepository = productRepository;
            _fileLogger = fileLogger;
        }

        public string Add(Product product)
        {
            try
            {
                if (!product.isValid) return "Produto Inválido!";

                _productRepository.Add(product);
            }
            catch (Exception error)
            {
                _fileLogger.Handle(error.Message.ToString());
                return error.Message;
            }

            return "Sucesso!";
        }
    }
}
