using System;

namespace CommandPiplineWithAutofac
{
    public class HirePersonHandler : IHandler<HirePersonCommand>
    {
        public void Handle(HirePersonCommand command)
        {
            Console.WriteLine("{0} was hired!", command.Name);
        }
    }
}