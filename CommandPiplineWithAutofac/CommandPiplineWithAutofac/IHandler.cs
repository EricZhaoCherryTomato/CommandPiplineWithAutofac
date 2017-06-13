namespace CommandPiplineWithAutofac
{
    public interface IHandler<T> where T : IPersonCommand
    {
        void Handle(T command);
    }

    public interface IPersonCommand
    {
    }
}