using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AOPBenchmarkTest
{
    public class MyService
    {
        public virtual  int Do()
        {
            return 0;
        }

        public virtual async Task<int> DoAsync()
        {
            return await Task.FromResult(0);
        }
    }
}
