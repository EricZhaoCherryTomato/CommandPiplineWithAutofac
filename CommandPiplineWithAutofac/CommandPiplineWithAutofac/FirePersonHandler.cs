using System;

namespace CommandPiplineWithAutofac
{
    public class FirePersonHandler : IHandler<FirePersonCommand>
    {
        public void Handle(FirePersonCommand command)
        {
            Console.WriteLine("{0} was fired!", command.Name);
        }
    }
}