namespace CommandPiplineWithAutofac
{
    public interface ICommandDispatcher
    {
        void Dispatch<T>(T command) where T : IPersonCommand;
    }
}