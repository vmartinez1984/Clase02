using Grpc.Net.Client;
using HolaMundo_Grpc;

Console.WriteLine("Consumir el gPRC");

using var channel = GrpcChannel.ForAddress("http://localhost:5000");

var client = new Greeter.GreeterClient(channel);

Console.WriteLine("Ingrese su nombre:");
var nombre = Console.ReadLine();

var reply = await client.SayHelloAsync(new HelloRequest { Name = nombre });

Console.WriteLine("Saludo recibido: " + reply.Message);
