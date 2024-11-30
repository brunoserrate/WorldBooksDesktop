using WorldBooksDesktop.Repository;
using WorldBooksDesktop.Utils;
using WorldBooksDesktop.Models;
using System.Collections.Generic;

namespace WorldBooksDesktop.Service
{
    public class SaleService
    {
        private readonly SaleRepository _saleRepository;
        private readonly ProductRepository _productRepository;
        private readonly SalesItemService _salesItemService;

        public SaleService()
        {
            _saleRepository = new SaleRepository();
            _productRepository = new ProductRepository();

            _salesItemService = new SalesItemService();
        }

        public Response CreateSale(Sale sale, List<SalesItem> items)
        {
            Response response = new Response(true, "Venda realizada com sucesso", null);

            Response createSaleResponse = _saleRepository.Create(sale);

            if (!createSaleResponse.Success)
            {
                response.Success = false;
                response.Message = createSaleResponse.Message;
                return response;
            }

            Response salesItemResponse = _salesItemService.CreateSalesItems(items, sale.Id);

            if (!salesItemResponse.Success)
            {
                response.Success = false;
                response.Message = salesItemResponse.Message;
                return response;
            }

            return response;
        }
    }
}
