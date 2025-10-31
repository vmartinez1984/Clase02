using CoreWCF.Configuration;
using HolaMundo_CoreWcf.Services;
using System.ComponentModel.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();

var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<GreatService>();
    serviceBuilder.AddServiceEndpoint<GreatService, IGreatService>(
        new CoreWCF.BasicHttpBinding(),
        "/GreatService.svc"
    );
});

// Publicar metadatos (WSDL) para cliente SOAP
var serviceMetadataBehavior = app.Services.GetRequiredService<CoreWCF.Description.ServiceMetadataBehavior>();
serviceMetadataBehavior.HttpGetEnabled = true;

app.Run();
