using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Microsoft.Xna.Framework.Input;

namespace monogame.Teste.Handlers
{   
    [TestFixture]
    public class InputUtils
    {
        MouseState buttonPressedState;
        MouseState buttonReleasedState;

        [SetUp]

        public void TestSetup()
        {
            buttonPressedState = new MouseState(0, 0, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            buttonReleasedState = new MouseState(0, 0, 0, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
        }
        [Test()]

        public void IsClickedShouldRetunrTrueForClickedState()
        {
            Assert.That(monogame.W10.Handlers.Input.IsMouseClicked(buttonPressedState, buttonReleasedState),Is.True);
        }

        [Test()]
        public void IsClickedShouldReturnFalseForPressedState()
        {
            Assert.That(monogame.W10.Handlers.Input.IsMouseClicked(buttonPressedState, buttonPressedState), Is.False);
        }
        [Test()]
        public void IsClickedShouldReturnFalseForReleasedState()

        {
            Assert.That(monogame.W10.Handlers.Input.IsMouseClicked(buttonReleasedState, buttonReleasedState), Is.False);
        }

        [Test()]
        public void IsClickedShouldReturnFalseForUnclickedState()

        {
            Assert.That(monogame.W10.Handlers.Input.IsMouseClicked(buttonReleasedState, buttonPressedState), Is.False);
        }
    }
}
