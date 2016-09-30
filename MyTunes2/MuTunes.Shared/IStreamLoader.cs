using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuTunes.Shared
{
    public interface IStreamLoader
    {
        System.IO.Stream GetStreamForFilename(string filename);
    }
}
