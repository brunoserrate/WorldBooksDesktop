using WorldBooksDesktop.Repository;
using WorldBooksDesktop.Utils;
using WorldBooksDesktop.Models;
using System.Collections.Generic;

namespace WorldBooksDesktop.Service
{
    public class SalesItemService
    {
        private readonly SalesItemRepository _salesItemRepository;
        private readonly ProductService _productService;

        public SalesItemService()
        {
            _salesItemRepository = new SalesItemRepository();
            _productService = new ProductService();
        }

        public Response CreateSalesItems(List<SalesItem> items, int saleId)
        {
            Response response = new Response(true, "Itens da venda criados com sucesso", null);

            if (saleId == 0)
            {
                response.Success = false;
                response.Message = "Id da venda não pode ser 0";
                return response;
            }

            Response productsResponse = CheckProductsAvailability(items);

            if (!productsResponse.Success)
            {
                response.Success = false;
                response.Message = productsResponse.Message;
                return response;
            }

            foreach (SalesItem item in items)
            {
                item.SaleId = saleId;

                Response createSalesItemResponse = _salesItemRepository.Create(item);

                if (!createSalesItemResponse.Success)
                {
                    response.Success = false;
                    response.Message = createSalesItemResponse.Message;
                    return response;
                }

                SalesItem salesItemSaved = (SalesItem)createSalesItemResponse.Data;

                Response getProductResponse = _productService.GetProduct(item.ProductId);

                Product product = (Product)getProductResponse.Data;

                product.QuantityStock -= salesItemSaved.Quantity;

                Response updateProductResponse = _productService.UpdateProduct(product);

                if (!updateProductResponse.Success)
                {
                    response.Success = false;
                    response.Message = updateProductResponse.Message;
                    return response;
                }
            }

            return response;
        }

        private Response CheckProductsAvailability(List<SalesItem> items)
        {
            Response response = new Response(true, "Produtos disponíveis", null);

            foreach (SalesItem item in items)
            {
                Response getProductResponse = _productService.GetProduct(item.ProductId);

                if (!getProductResponse.Success)
                {
                    response.Success = false;
                    response.Message = getProductResponse.Message;
                    return response;
                }

                Product product = (Product)getProductResponse.Data;

                if (product.QuantityStock < item.Quantity)
                {
                    response.Success = false;
                    response.Message = "Quantidade em estoque insuficiente. Produto: " + product.Name;
                    return response;
                }
            }

            return response;
        }
    }
}
