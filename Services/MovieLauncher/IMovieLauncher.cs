using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShabbatMovieLauncher.Services
{
    public interface IMovieLauncher
    {
        void Launch(string url);
    }
}
