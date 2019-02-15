using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRandom
    {
        double NextDouble();

        int Next(int maxValue);

        int Next(int minValue, int maxValue);

    }
}
