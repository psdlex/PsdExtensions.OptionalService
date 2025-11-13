namespace PsdExtensions.OptionalService;

public sealed class OptionalService<TService> where TService : class
{
    public OptionalService(TService? service = null)
    {
        Service = service;
    }

    public TService? Service { get; }
    public bool HasService => Service is not null;
}