using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace AOPBenchmarkTest.Castle_Core
{
   public  static class Create_Instance_By_Castle_Core
   {
       private static readonly ProxyGenerationOptions s_proxyGenerationOptions = new ProxyGenerationOptions();

       private static readonly ProxyGenerator s_proxyGenerator = new ProxyGenerator();

       private static readonly IInterceptor[] s_interceptors = new[] { new TestInterceptor() };

       private static readonly IInterceptor[] s_interceptorsAsync = new[] { new TestAsyncInterceptor() };

        public static T CreateInstance_DoAsync<T>() where T:class
        {
            return s_proxyGenerator.CreateClassProxy<T>(s_proxyGenerationOptions, s_interceptorsAsync);
        }


       public static T CreateInstance_Do<T>() where T : class
       {
           return s_proxyGenerator.CreateClassProxy<T>(s_proxyGenerationOptions, s_interceptors);
       }

    }
}
