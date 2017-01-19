using System;
using System.Net;
using ServiceStack.ServiceModel.Operations;
using ServiceStack.ServiceModel.Types;

using ServiceStack.OrmLite;

namespace ServiceStack.ServiceInterface
{
    public class CustomerDetailsService : Service
    {
        public CustomerDetailsResponse Get(CustomerDetails request)
        {
            var customer = Db.SingleById<Customer>(request.Id);
            if (customer == null)
                throw new HttpError(HttpStatusCode.NotFound,
                    new ArgumentException("Customer does not exist: " + request.Id));

            var ordersService = base.ResolveService<OrdersService>();
            var ordersResponse = (OrdersResponse) ordersService.Get(new Orders {CustomerId = customer.Id});

            return new CustomerDetailsResponse
            {
                Customer = customer,
                CustomerOrders = ordersResponse.Results,
            };
        }
    }
}
