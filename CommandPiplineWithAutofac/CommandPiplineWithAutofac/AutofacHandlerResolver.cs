using Autofac;

namespace CommandPiplineWithAutofac
{
    public class AutofacHandlerResolver : IHandlerResolver
    {
        private readonly IComponentContext _context;

        public AutofacHandlerResolver(IComponentContext context)
        {
            _context = context;
        }

        public IHandler<T> Resolve<T>() where T : IPersonCommand
        {
            return _context.ResolveOptionalKeyed<IHandler<T>>("DecoratedHandler");
        }
    }
}