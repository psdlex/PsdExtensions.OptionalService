# PsdExtensions.OptionalService

## How to use?
```csharp
var services = new ServiceCollection();

services.AddOptionalServices();

// practically done
```

## Use-case in a service
```
public sealed class CrazyService
{

	public CrazyService(OptionalService<IMyService> myService)
	{
		var service = myService.Service; // .Service is nullable

		if (myService.HasService)
			...
	}

}
```

## Nuget
https://www.nuget.org/packages/PsdExtensions.OptionalService