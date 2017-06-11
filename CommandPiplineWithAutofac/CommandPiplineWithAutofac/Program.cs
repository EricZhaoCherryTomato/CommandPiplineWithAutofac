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
}