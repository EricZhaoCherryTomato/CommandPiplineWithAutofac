using System;
using System.Windows.Input;
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

            builder.RegisterType<AutofacHandlerResolver>()
                   .As<IHandlerResolver>();

            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();

            Container = builder.Build();

            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    //var handlerFire = scope.Resolve<IHandler<FirePersonCommand>>();
                    //handlerFire.Handle(new FirePersonCommand { Name = "Frank" });

                    //var handlerHire = scope.Resolve<IHandler<HirePersonCommand>>();
                    //handlerHire.Handle(new HirePersonCommand { Name = "Joe" });

                    var commandDispatcher = scope.Resolve<ICommandDispatcher>();

                    commandDispatcher.Dispatch(new HirePersonCommand { Name = "Joe" });
                    commandDispatcher.Dispatch(new FirePersonCommand { Name = "Frank" });

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
}