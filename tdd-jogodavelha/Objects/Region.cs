using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame.W10.Objects
{
    public class Region
    {   
        public int State { get; set; }
        public Rectangle Area { get; set; }
        public Vector2 StringPosition { get; set ; }
        
        SpriteFont font;

        public Region(int x, int y, int width , int height,SpriteFont font)
        {
            State = 0;
            Area = new Rectangle(x, y, width, height);
            this.font = font;
            StringPosition =new Vector2(Area.X + Area.Width / 3, Area.Y + Area.Height / 3);
        }
        public void InteractWithRegionState()
        {
            if(!IsActive())
            {
                State = BoardStateManager.currentPlayer;
                BoardStateManager.UpdatePlayerState();
            }
        }

        public bool IsActive()
        {
            if(State == 1 || State == -1)
            {
                return true;
            }
            return false;
        }
        public string GetSymbol()
        {
            if (State == 1)
            {
                return "X";
            }

            else if (State == -1)
            {
                return "O";
            }
            return "";
        }
        public void Draw(SpriteBatch sb)

        {
            sb.DrawString(font, GetSymbol(), StringPosition, Color.Black);
        }

    }
}
