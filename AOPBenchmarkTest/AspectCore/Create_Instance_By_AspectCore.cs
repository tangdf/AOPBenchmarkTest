using System;
using System.Collections.Generic;
using System.Text;
using AspectCore.Configuration;
using AspectCore.DynamicProxy;

namespace AOPBenchmarkTest.AspectCore
{
    public static class Create_Instance_By_AspectCore
    {
        private static readonly IProxyGenerator s_proxyGeneratorAsync;

        private static readonly IProxyGenerator s_proxyGenerator;

        static Create_Instance_By_AspectCore()
        {
            var builder = new ProxyGeneratorBuilder();
            builder.Configure(config => { config.Interceptors.Add(new TestAsyncInterceptorFactory()); });
            s_proxyGeneratorAsync = builder.Build();

            builder = new ProxyGeneratorBuilder();
            builder.Configure(config => { config.Interceptors.Add(new TestInterceptorFactory()); });
            s_proxyGenerator = builder.Build();
        }
        public static T CreateInstance_DoAsync<T>() where T : class
        {
            return s_proxyGeneratorAsync.CreateClassProxy<T>();
        }

        public static T CreateInstance_Do<T>() where T : class
        {
            return s_proxyGenerator.CreateClassProxy<T>();
        }

        private class TestInterceptorFactory: InterceptorFactory
        {
            public override IInterceptor CreateInstance(IServiceProvider serviceProvider)
            {
                return new CustomInterceptorAttribute();
            }
        }

        private class TestAsyncInterceptorFactory : InterceptorFactory
        {
            public override IInterceptor CreateInstance(IServiceProvider serviceProvider)
            {
                return new CustomAsyncInterceptorAttribute();
            }
        }

    }
}
