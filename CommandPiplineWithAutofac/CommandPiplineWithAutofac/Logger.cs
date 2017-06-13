using System;

namespace CommandPiplineWithAutofac
{
    public class Logger<T> : IHandler<T> where T : IPersonCommand
    {
        private readonly IHandler<T> _decorated;

        public Logger(IHandler<T> decorated)
        {
            _decorated = decorated;
        }

        public void Handle(T command)
        {
            Console.WriteLine("{0} executed.",
                              command.GetType().Name);

            _decorated.Handle(command);
        }
    }
}