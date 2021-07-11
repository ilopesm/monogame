using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using monogame;
using NUnit.Framework;

namespace monogame.Teste.GameScene
{
    [TestFixture]
    public class GameConfig
    {
        [Test()]

        public void isBackgroundWhite()
        {
            Assert.That(Color.White, Is.EqualTo(monogame.W10.GeneralAttributes.BackgroungColor()));
        }

    }
}
