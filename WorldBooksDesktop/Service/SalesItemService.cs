using WorldBooksDesktop.Repository;
using WorldBooksDesktop.Utils;
using WorldBooksDesktop.Models;
using System.Collections.Generic;

namespace WorldBooksDesktop.Service
{
    public class SalesItemService
    {
        private readonly SalesItemRepository _salesItemRepository;

        public SalesItemService()
        {
            _salesItemRepository = new SalesItemRepository();
        }

        public Response CreateSalesItems(List<SalesItem> items, int saleId)
        {
            Response response = new Response(true, "Itens da venda criados com sucesso", null);

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
            }

            return response;
        }
    }
}
