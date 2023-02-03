using Grpc.Core;
using NetGrpc.Protos;

namespace NetGrpc.Services;

public class CustomerService : Customer.CustomerBase
{
    private readonly ILogger<CustomerService> logger;
    public CustomerService(ILogger<CustomerService> logger)
    {
        this.logger = logger;
    }
    public override async Task<CustomerModel> GetCustomerInfo(CustomerLookUpModel request, ServerCallContext context)
    {
        CustomerModel outPut = new CustomerModel();
        if (request.UserId.Equals(1))
        {
            outPut.FirstName = "MSoheil";
            outPut.LastName = "Davoodi";
        }
        else if (request.UserId.Equals(2))
        {
            outPut.FirstName = "Amin";
            outPut.LastName = "Esma";
        }
        else
        {
            outPut.FirstName = "MohammadReza";
            outPut.LastName = "Savad";
        }

        return await Task.FromResult(outPut);
    }
}

