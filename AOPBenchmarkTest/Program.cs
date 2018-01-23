using System;
using BenchmarkDotNet.Running;

namespace AOPBenchmarkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<AOP_Benchmarker>();
            Console.WriteLine(summary);

        }
    }
}
