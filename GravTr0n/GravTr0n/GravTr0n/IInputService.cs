using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GravTr0n
{
    public interface IInputService
    {
        bool CheckMoveLeft();
        bool CheckMoveRight();
        bool CheckJump();
        bool CheckRestart();
        bool CheckQuit();
    }
}
