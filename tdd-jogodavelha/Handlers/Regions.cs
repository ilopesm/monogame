using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace monogame.W10.Handlers
{
    public class Regions
    {
        public static bool IsInRegion(MouseState mouse, Rectangle rect)
        {
            if
            (rect.Contains(mouse.X, mouse.Y))
            { 
                return true;
            }
            return false;
        }

        public static bool HasMouseClickedRegion(MouseState currentState,MouseState prevState, Rectangle rect)
        {
            return Input.IsMouseClicked(currentState, prevState) && IsInRegion(currentState, rect); ;
        }
    }
}
