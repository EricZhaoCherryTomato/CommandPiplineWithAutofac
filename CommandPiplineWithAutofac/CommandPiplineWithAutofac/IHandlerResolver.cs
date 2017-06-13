namespace CommandPiplineWithAutofac
{
    public interface IHandlerResolver
    {
        IHandler<T> Resolve<T>() where T : IPersonCommand;
    }
}