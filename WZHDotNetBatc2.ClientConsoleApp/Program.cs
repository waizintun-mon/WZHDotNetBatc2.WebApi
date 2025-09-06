// See https://aka.ms/new-console-template for more information

using WZHDotNetBatc2.ClientConsoleApp;

Console.WriteLine("Show Movie");

HttpClientService service = new HttpClientService();
await service.RunAsync();