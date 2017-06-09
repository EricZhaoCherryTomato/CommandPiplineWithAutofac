using System;
using Autofac;

namespace CommandPiplineWithAutofac
{
    internal class Program
    {
        private static IContainer Container { get; set; }

        private static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                   .AsClosedTypesOf(typeof(IHandler<>))
                   .InstancePerLifetimeScope();
            Container = builder.Build();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    var handler = scope.Resolve<IHandler<FirePersonHandler>>();
                    handler.Handle(new FirePersonHandler());
                }

                Console.WriteLine(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public interface IHandler
    {
        void Handle<TCommand>(TCommand command) where TCommand : ICommand;
    }

    public class FirePersonHandler : IHandler<FirePersonCommand>
    {
        public void Handle(FirePersonCommand command)
        {
            Console.WriteLine("{0} was fired!", command.Name);
        }
    }

    public class FirePersonCommand : ICommand
    {
        public string Name;
    }

    public interface ICommand
    {
    }

    public class Manager
    {
        private readonly IHandler<FirePersonHandler> _handler;

        public Manager(IHandler<FirePersonHandler> handler)
        {
            _handler = handler;
        }

        public void Fire()
        {
            _handler.Handle(new FirePersonCommand{Name = "Joe"});
        }
    }
}