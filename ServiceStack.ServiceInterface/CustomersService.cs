using ServiceStack.ServiceModel.Operations;
using ServiceStack.ServiceModel.Types;
using ServiceStack.OrmLite;

namespace ServiceStack.ServiceInterface
{
    public class CustomersService : ServiceStack.Service
    {
        public CustomersResponse Get(Customers request)
        {
            return new CustomersResponse { Customers = Db.Select<Customer>() };
        }
    }
}
