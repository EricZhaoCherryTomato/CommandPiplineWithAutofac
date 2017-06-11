namespace CommandPiplineWithAutofac
{
    public interface IHandler<T>
    {
        void Handle(T command);
    }
}