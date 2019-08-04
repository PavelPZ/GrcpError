using System;

namespace GrcpClient {
  class Program {
    static void Main(string[] args) {
      var client = new GrpcServer.Greeter.GreeterClient(getInvoker());
      try {
        var res = client.SayHello(new GrpcServer.HelloRequest { Name = "Hello name" });
        Console.WriteLine(res.Message);
      } catch (Exception exp) {
        if (exp == null) return;
      }
    }

    public static Grpc.Core.CallInvoker getInvoker() {
      var channel = new Grpc.Core.Channel("localhost", 5001, Grpc.Core.ChannelCredentials.Insecure);
      return new Grpc.Core.DefaultCallInvoker(channel);
    }

  }
}
