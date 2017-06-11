namespace CommandPiplineWithAutofac
{
    public class Manager
    {
        private readonly IHandler<FirePersonCommand> _handler;
        public Manager(IHandler<FirePersonCommand> handler)
        {
            _handler = handler;
        }

        public void Fire()
        {
            _handler.Handle(new FirePersonCommand { Name = "Frank" });
        }
    }
}