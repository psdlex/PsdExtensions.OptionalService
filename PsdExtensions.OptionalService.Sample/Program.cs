using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PsdExtensions.OptionalService;
using PsdExtensions.OptionalService.Sample;

Console.OutputEncoding = Encoding.UTF8;

var services = new ServiceCollection();

services.AddOptionalServices();

services.AddTransient<MyTransientOptionalService>();
services.AddSingleton<MySingletonOptionalService>();
services.AddScoped<MyScopedOptionalService>();

services.AddScoped<MyRequiredScopedService>();
services.AddTransient<MyRequiredTransientService>();

var provider = services.BuildServiceProvider();

/* 
    🔃 IDS should be different every time including the same scope (TRANSIENT)
    1   IDS should be same every time (SINGLETON)
    ⭕  IDS should be same ONLY within the same scope (SCOPED)
*/

for (int i = 0; i < 3; i++)
{
    using var scope = provider.CreateScope();

    var workingService = scope.ServiceProvider.GetRequiredService<MyRequiredTransientService>();
    Console.WriteLine("===== [SCOPE]");
    workingService.Execute();
    Console.WriteLine();
}

