using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace monogame.W10.Handlers
{
    public class Input
    {
        public static bool IsMouseClicked(MouseState buttonPressedState, MouseState buttonReleasedState)
        {
            if (buttonPressedState.LeftButton == ButtonState.Pressed && buttonReleasedState.LeftButton == ButtonState.Released)
            {
                return true;
            }
                return false;
        }
    }
}
