// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using NetGrpc;

Console.WriteLine("Hello, World!");

var input = new HelloRequest
{
    Name = "MSoheil",
};

var channel = GrpcChannel.ForAddress("https://localhost:7037");
var client = new Greeter.GreeterClient(channel);

var reply = await client.SayHelloAsync(input);



Console.WriteLine(reply.Message);

Console.ReadLine();