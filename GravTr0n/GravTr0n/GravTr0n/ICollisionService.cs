using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GravTr0n
{
    interface ICollisionService
    {
        bool IsCollision(Player player, DrawData item);
        void ResolveCollision(Player player, DrawData item);
    }
}
