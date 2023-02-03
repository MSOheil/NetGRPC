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
    public override async Task GetNewCustomers(NewCustomerRequest request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
    {
        List<CustomerModel> newCustomers = new List<CustomerModel>()
        {
            new CustomerModel
            {
                Age=22,
                EmailAddress="Moh99soheil@gmail.com",
                LastName="Davoody",
                FirstName="MSoheil",
                IsAlive=true,
            },
            new CustomerModel
            {
                Age=23,
                EmailAddress="ofking609@gmail.com",
                LastName="Davoody",
                FirstName="MSoheil",
                IsAlive=true,
            },new CustomerModel
            {
                Age=25,
                EmailAddress="ofking608@gmail.com",
                LastName="Davoody",
                FirstName="MSoheil",
                IsAlive=true,
            }
        };
        foreach (var cust in newCustomers)
        {
            await Task.Delay(1000);
            await responseStream.WriteAsync(cust);
        }
    }
}

