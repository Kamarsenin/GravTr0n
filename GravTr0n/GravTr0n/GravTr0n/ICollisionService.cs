﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GravTr0n
{
    interface ICollisionService
    {
        bool IsCollision();
        void ResolveCollision();
    }
}
