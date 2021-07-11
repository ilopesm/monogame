using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using monogame.W10.Handlers;

namespace monogame.W10.Objects
{
    public class BoardStateManager
    {   
        public static int currentPlayer { get; set; }

        public BoardStateManager()
        {
            currentPlayer = 1;
        }
        public static int ClickedRegion(Region[] regions, MouseState current, MouseState prev)
        {
            for (int i=0; i < regions.Length; i++)
            {
                if (Regions.HasMouseClickedRegion(current, prev, regions[i].Area))
                {
                    return i;
                }
            }
            return -1;
        }
        public static void UpdateClickedRegionState(Region[] regions, int clickedRegion)
        {
            if (clickedRegion != -1)
            {
                regions[clickedRegion].InteractWithRegionState();
            }
        }
        public static void UpdatePlayerState()
        {
            currentPlayer = -currentPlayer;
        }
    }
}
