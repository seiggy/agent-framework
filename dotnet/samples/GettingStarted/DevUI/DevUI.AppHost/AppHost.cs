using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);

var aiFoundryName = builder.AddParameter("existingFoundryName");
var aiFoundryResourceGroup = builder.AddParameter("existingFoundryResourceGroup");

var aiFoundry = builder.AddAzureAIFoundry("ai-foundry")
    .AsExisting(aiFoundryName, aiFoundryResourceGroup);

builder.AddProject<Projects.DevUI_BasicDemo>("DevUIDemo")
    .WithReference(aiFoundry)
    .WithUrlForEndpoint("https", url =>
    {
        url.DisplayText = "DevUI (https)";
        url.Url = "/devui";
    });

builder.Build().Run();
