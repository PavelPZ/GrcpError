using System;

namespace GrcpClient { 
  class Program {
    static void Main(string[] args) {
      var channel = new Grpc.Core.Channel("localhost", 5001, Grpc.Core.ChannelCredentials.Insecure);
      var invoker = new Grpc.Core.DefaultCallInvoker(channel);
      var client = new GrpcServer.Greeter.GreeterClient(invoker);
      try {
        var res = client.SayHello(new GrpcServer.HelloRequest { Name = "Hello name" });
        Console.WriteLine(res.Message);
      } catch (Exception exp) {
        if (exp == null) return;
      }
    }

  }
}
