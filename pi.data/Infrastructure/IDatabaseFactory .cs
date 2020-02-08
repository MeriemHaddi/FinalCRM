
using pi.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm_pi.pi.data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        Context DataContext { get; }
    }

}
