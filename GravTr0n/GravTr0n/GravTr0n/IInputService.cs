using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GravTr0n
{
    public interface IInputService
    {
        bool CheckMoveLeft();
        bool CheckMoveRight();
        bool CheckJump();
        bool CheckRestart();
        bool CheckQuit();
        bool CheckPause();

        bool CheckMouseLeft();
        Point CheckMousePosition();
    }
}
