using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraGroupUI
{
    public interface IProcessorLocator
    {
        T GetProcessor<T>();

        T GetProcessor<T>(string Name);

    }
}
