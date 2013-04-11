using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GravTr0n
{
    interface IDrawSprites
    {
        void AddDrawable(DrawData drawable);
        void RemoveDrawable(DrawData drawable);
        void ClearDrawable();
    }
}
