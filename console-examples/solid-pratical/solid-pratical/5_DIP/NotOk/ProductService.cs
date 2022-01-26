using solid_pratical._5_DIP.NotOk;
using System;

namespace solid_pratical._4_DIP.NotOk
{
    public class ProductService
    {
        private ProductRespository _productRespository;

        public ProductService()
        { 
            _productRespository = new ProductRespository();
        }

        public string Add(Product product)
        {
            try
            {
                if (!product.isValid) return "Produto Inválido!";

                _productRespository.Add(product);
            }
            catch (Exception error)
            {
                FileLogger.Handle(error.Message.ToString());
                return error.Message;
            }

            return "Sucesso!";
        }
    }
}
