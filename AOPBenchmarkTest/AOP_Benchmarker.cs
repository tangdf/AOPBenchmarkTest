using AOPBenchmarkTest.AspectCore;
using AOPBenchmarkTest.Castle_Core;
using BenchmarkDotNet.Attributes;

namespace AOPBenchmarkTest
{
    public class AOP_Benchmarker
    {

        private MyService myService_By_Castle_Core_DoAsync = Create_Instance_By_Castle_Core.CreateInstance_DoAsync<MyService>();
        private MyService myService_By_AspectCore_DoAsync = Create_Instance_By_AspectCore.CreateInstance_DoAsync<MyService>();


        private MyService myService_By_Castle_Core_Do = Create_Instance_By_Castle_Core.CreateInstance_Do<MyService>();
        private MyService myService_By_AspectCore_Do = Create_Instance_By_AspectCore.CreateInstance_Do<MyService>();



        [Benchmark]
        public  int Create_By_Castle_Core_Async()
        {
            return myService_By_Castle_Core_DoAsync.DoAsync().Result;
        }

        [Benchmark]
        public  int Create_By_AspectCore_Async()
        {
            return myService_By_AspectCore_DoAsync.DoAsync().Result;
        }


        [Benchmark]
        public int Create_By_Castle_Core()
        {
            return myService_By_Castle_Core_Do.Do();
        }

        [Benchmark]
        public int Create_By_AspectCore()
        {

            return myService_By_AspectCore_Do.Do();
        }

    }
}
