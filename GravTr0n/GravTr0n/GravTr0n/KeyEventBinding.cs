using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace GravTr0n
{
    struct KeyEventBinding
    {
        public Keys key;
        public Events eventName;

        public KeyEventBinding(Keys keys, Events keyEvent) 
        { 
            key = keys; 
            eventName = keyEvent; 
        }
    }
}
