using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using monogame.W10;
using Microsoft.Xna.Framework.Graphics;

namespace monogame.Teste.Objects
{
    [TestFixture]
    public class RegionTest
    {
        monogame.W10.Objects.Region region;

        [SetUp]
        public void SetUpRegion()
        {
            SpriteFont font = null;
            region = new monogame.W10.Objects.Region(10, 15, 20, 35,font);
        }

        [Test()]
        public void InitialStateShouldBeZero() {
            Assert.That(region.State, Is.EqualTo(0));
        }

        [Test()]
        public void InitialAreaShouldEqualRectangle()
        {
            Assert.That(region.Area, Is.EqualTo(new Rectangle(10, 15, 20, 35)));
        }

        /*[Test()]
        public void StateDoesNotChangeAfterClick()

        {
            region.State =0;
            MouseState currentStateAux = new MouseState(1000, 40, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            region.InteractWithRegionState();
            Assert.That(region.State, Is.EqualTo(0));
        }
        */

        /*
        [Test()]

        public void StateChangesTo1AfterClick()
        {
            region.InteractWithRegionState();
            Assert.That(region.State, Is.EqualTo(1));
        }
        */
        [Test()]
        public void StateDoesNotCHangeWhenAlreadyClicked()
        {
            region.State =-1;
            region.InteractWithRegionState();
            Assert.That(region.State, Is.EqualTo(-1));
        }

        [Test()]
        public void XIsReturnedFor1()
        {
            region.State = 1;
            Assert.That(region.GetSymbol(), Is.EqualTo("X"));
        }

        [Test()]
        public void OIsReturnedForMinus1()
        {
            region.State =-1;
            Assert.That(region.GetSymbol(), Is.EqualTo("O"));
        }

        [Test()]
        public void EmptyStringFor0()

        {
            region.State =0;
            Assert.That(region.GetSymbol(), Is.EqualTo(""));
        }

        [Test()]
        public void IsStringPositionVectorCentered()
        {
            Assert.That(region.StringPosition, Is.EqualTo(new Vector2(16, 26)));
        }
    }
}
