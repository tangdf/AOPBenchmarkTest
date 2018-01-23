using System.Threading.Tasks;
using AspectCore.DynamicProxy;

namespace AOPBenchmarkTest.AspectCore
{
    public class CustomInterceptorAttribute : AbstractInterceptorAttribute
    {
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            await next(context);
            context.ReturnValue = 1; 
        }
    }

    public class CustomAsyncInterceptorAttribute : AbstractInterceptorAttribute
    {
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            await next(context);
            context.ReturnValue = Task.FromResult(1);
        }
    }
}