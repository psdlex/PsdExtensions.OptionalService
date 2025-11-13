namespace PsdExtensions.OptionalService.Sample;

// required services
public abstract class RequiredService(
    OptionalService<MyTransientOptionalService> transientService,
    OptionalService<MySingletonOptionalService> singletonService,
    OptionalService<MyScopedOptionalService> scopedService
)
{
    public virtual void Execute()
    {
        Console.WriteLine($"[{GetType().Name}] Optional Transient Service ID : " + transientService.Service?.Id + " 🔃");
        Console.WriteLine($"[{GetType().Name}] Optional Singleton Service ID : " + singletonService.Service?.Id + " 1");
        Console.WriteLine($"[{GetType().Name}] Optional Scoped Service ID    : " + scopedService.Service?.Id + "⭕");
    }
}

public class MyRequiredScopedService(
    OptionalService<MyTransientOptionalService> transientService,
    OptionalService<MySingletonOptionalService> singletonService,
    OptionalService<MyScopedOptionalService> scopedService
) : RequiredService(
    transientService,
    singletonService,
    scopedService
);

public class MyRequiredTransientService(
    OptionalService<MyTransientOptionalService> transientService,
    OptionalService<MySingletonOptionalService> singletonService,
    OptionalService<MyScopedOptionalService> scopedService,
    MyRequiredScopedService requiredScopedService
) : RequiredService(
    transientService,
    singletonService,
    scopedService
)
{
    public override void Execute()
    {
        base.Execute();
        requiredScopedService.Execute();
    }
}