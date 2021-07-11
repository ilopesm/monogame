using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using monogame.W10.Handlers;
namespace monogame.Teste.Handlers
{
    [TestFixture]
    public class GeometryTest
    {
        MouseState correctMouseState;
        MouseState unclickedMouseState;
        MouseState smallerThanRegionState;
        MouseState greaterThanRegionState;
        Rectangle rect;

        [SetUp]
        public void GeometryTestSetup() {
            correctMouseState =new MouseState(50, 80, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            unclickedMouseState =new MouseState(50, 80, 0, ButtonState.Released, ButtonState.Released,ButtonState.Released, ButtonState.Released, ButtonState.Released);
            smallerThanRegionState = new MouseState(10, 10, 0, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            greaterThanRegionState =new MouseState(1000, 1000, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            rect =new Rectangle(30, 60, 40, 40);
        }

        [Test()]
        public void MouseStatePositionIsInRegion()
        {
            Assert.That(monogame.W10.Handlers.Regions.IsInRegion(correctMouseState, rect),Is.True);
        }

        [Test()]
        public void MouseStatePositionSmallerThanRegion()
        {
            Assert.That(monogame.W10.Handlers.Regions.IsInRegion(smallerThanRegionState, rect),Is.False);
        }

        [Test()]
        public void MouseStatePositionGreaterThanRegion()
        {
            Assert.That(monogame.W10.Handlers.Regions.IsInRegion(greaterThanRegionState, rect),Is.False);
        }

        [Test()]
        public void MouseHasClickedRegion()
        {
            Assert.That(monogame.W10.Handlers.Regions.HasMouseClickedRegion(correctMouseState,smallerThanRegionState, rect), Is.True);
        }
        [Test()]
        public void MouseInRegionNotClicked()
        {
            Assert.That(monogame.W10.Handlers.Regions.HasMouseClickedRegion(unclickedMouseState,smallerThanRegionState, rect), Is.False);
        }

        [Test()]
        public void MouseClickedNotInRegion()

        {
            Assert.That(monogame.W10.Handlers.Regions.HasMouseClickedRegion(greaterThanRegionState, unclickedMouseState, rect), Is.False);
        }
    }
}
