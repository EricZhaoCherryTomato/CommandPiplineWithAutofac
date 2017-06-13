namespace CommandPiplineWithAutofac
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IHandlerResolver _resolver;

        public CommandDispatcher(IHandlerResolver resolver)
        {
            _resolver = resolver;
        }

        public void Dispatch<T>(T command) where T : IPersonCommand
        {
            var handler = _resolver.Resolve<T>();
            if (handler != null)
            {
                handler.Handle(command);
            }
        }
    }
}