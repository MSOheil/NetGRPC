// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using NetGrpc;
using NetGrpc.Protos;

Console.WriteLine("Hello, World!");

//var input = new HelloRequest
//{
//    Name = "MSoheil",
//};

//var channel = GrpcChannel.ForAddress("https://localhost:7037");
//var client = new Greeter.GreeterClient(channel);

//var reply = await client.SayHelloAsync(input);

var channel = GrpcChannel.ForAddress("https://localhost:7037");
var customerClient = new Customer.CustomerClient(channel);

var clientReuqest = new CustomerLookUpModel
{
    UserId = 1,
};

var reply = await customerClient.GetCustomerInfoAsync(clientReuqest);


Console.WriteLine("Response from server is " + reply.FirstName + "last name is " + reply.LastName);

Console.WriteLine();
Console.WriteLine("New Customer list");
Console.WriteLine();


using (var call = customerClient.GetNewCustomers(new NewCustomerRequest()))
{
    while (await call.ResponseStream.MoveNext(cancellationToken: default))
    {
        var currentCustomer = call.ResponseStream.Current;
        Console.WriteLine(currentCustomer.FirstName + "last naem is " + currentCustomer.LastName + "Email is "
            + currentCustomer.EmailAddress + " Age is " + currentCustomer.Age);
    }
}



Console.ReadLine();