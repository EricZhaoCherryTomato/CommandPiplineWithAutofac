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
                   .AsClosedTypesOf(typeof(IHandler<>));
            Container = builder.Build();

            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    var handlerFire = scope.Resolve<IHandler<FirePersonCommand>>();
                    handlerFire.Handle(new FirePersonCommand { Name = "Frank" });

                    var handlerHire = scope.Resolve<IHandler<HirePersonCommand>>();
                    handlerHire.Handle(new HirePersonCommand { Name = "Joe" });
                }

                Console.ReadKey(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

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

    public interface IHandler<T>
    {
        void Handle(T command);
    }

    public class FirePersonHandler : IHandler<FirePersonCommand>
    {
        public void Handle(FirePersonCommand command)
        {
            Console.WriteLine("{0} was fired!", command.Name);
        }
    }

    public class HirePersonHandler : IHandler<HirePersonCommand>
    {
        public void Handle(HirePersonCommand command)
        {
            Console.WriteLine("{0} was hired!", command.Name);
        }
    }

    public class FirePersonCommand 
    {
        public string Name;
    }

    public class HirePersonCommand
    {
        public string Name;
    }




}