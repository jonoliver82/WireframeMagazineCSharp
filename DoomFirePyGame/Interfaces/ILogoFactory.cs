using DoomFirePyGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomFirePyGame.Interfaces
{
    public interface ILogoFactory
    {
        Logo Create(int x, int y);
    }
}
