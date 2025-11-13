namespace PsdExtensions.OptionalService.Sample;

public abstract class OptionalService
{
    public Guid Id { get; } = Guid.NewGuid();
}

public class MyTransientOptionalService : OptionalService;
public class MySingletonOptionalService : OptionalService;
public class MyScopedOptionalService : OptionalService;