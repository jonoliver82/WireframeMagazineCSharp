using JumpPhysicsPyGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpPhysicsPyGame.Interfaces
{
    public interface IPlayerFactory
    {
        Player Create(int x, int y);
    }
}
