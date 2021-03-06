using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame.W10.Objects
{
    public class Board
    {
        const int BASE_INVERT_AXIS = 100; 
        const int FIRST_POSITION = 195; 
        const int SECOND_POSITION = 295;

        public Rectangle[] lines { get; set; }
        public Region[] regions{get; set;}
        public int Thickness { get; set; }
        public MouseState Current { get; set; }
        public MouseState Previous { get; set; }
        public SpriteFont font { get; set;}
        public int Length { get; set; }

        public Board(SpriteFont font) {
            this.font = font;
            Thickness = 10;
            Length = 300;
            lines = new Rectangle[4] {new Rectangle(FIRST_POSITION, BASE_INVERT_AXIS, Thickness, Length),new Rectangle(SECOND_POSITION, BASE_INVERT_AXIS, Thickness, Length), 
                new Rectangle(BASE_INVERT_AXIS, FIRST_POSITION, Length, Thickness),
                new Rectangle(BASE_INVERT_AXIS, SECOND_POSITION, Length, Thickness),};
            regions = new Region[9] {
                    new Region(100, 100, 94, 94,font),
                    new Region(206, 100, 88, 94,font),
                    new Region(306, 100, 94, 94,font),
                    new Region(100, 206, 94, 88,font),
                    new Region(206, 206, 88, 88,font),
                    new Region(306, 206, 94, 88,font),
                    new Region(100, 306, 94, 94,font),
                    new Region(206, 306, 88, 94,font),
                    new Region(306, 306, 94, 94,font)
            };
        }
        public void Update(GameTime gameTime)
        {
            if (WinStateManager.CanKeepPlaying)
            {
                UpdateMouse(Mouse.GetState());
                UpdateCLicks(BoardStateManager.ClickedRegion(regions, Current, Previous));
                WinStateManager.Update(regions);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach(Rectangle line in lines)
            {
                sb.Draw(GeneralAttributes.LineTexture, destinationRectangle: line, color: Color.White);
            }
            DrawRegions(sb);
            DrawWinner(sb);
        }
        public void DrawRegions(SpriteBatch sb)
        {
            foreach (Region region in
            regions)
            {
                region.Draw(sb);
            }
        }
        public void DrawWinner(SpriteBatch sb)
        {
            sb.DrawString(font, WinStateManager.PlayerWhoWon, new Vector2(410, 100), Color.DarkBlue);
        }
        public void UpdateMouse(MouseState newState)
        {
            Previous = Current;
            Current = newState;
        }
        public void UpdateCLicks(int idx)
        {
            BoardStateManager.UpdateClickedRegionState(regions, idx);
        }
    }
}
