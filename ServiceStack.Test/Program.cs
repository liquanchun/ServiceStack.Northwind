using ServiceStack;
using ServiceStack.ServiceModel.Operations;
using ServiceStack.ServiceModel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStack.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var BaseUri = "http://localhost:51340/";
            var client = new JsonServiceClient(BaseUri);
            CustomersResponse allCustomer =  client.Get<CustomersResponse>(new Customers());
            var customer = allCustomer.Customers;
            foreach (var item in customer)
            {
                Console.WriteLine(item.ContactName);
            }
            Console.ReadKey();
        }
    }
}
