using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using monogame.W10.Objects;

namespace monogame.Teste.Handlers
{
    [TestFixture]
    public class WinSateManagerTest
    {
        Region[] regions;
        [SetUp]
        public void TestSetup()
        {
            regions = new Region[9]
            {
                new Region(100, 100, 94, 94, null),
                new Region(206, 100, 88, 94, null),
                new Region(306, 100, 94, 94, null),
                new Region(100, 206, 94, 88, null),
                new Region(206, 206, 88, 88, null),
                new Region(306, 206, 94, 88, null),
                new Region(100, 306, 94, 94, null),
                new Region(206, 306, 88, 94, null ),
                new Region(306, 306, 94, 94, null)
            };
            WinStateManager.CanKeepPlaying =true;
            WinStateManager.PlayerWhoWon ="";
        }
        [Test()]
        public void AllRegionsWith0NoVictoryPlayer(){
            Assert.That(WinStateManager.WhichPlayerWon(regions),Is.EqualTo(0));
        }

        [Test()]
        public void Row1HasWonP1()
        {
            regions[0].State = 1;
            regions[1].State = 1;
            regions[2].State = 1;
            Assert.That(WinStateManager.WhichPlayerWon(regions), Is.EqualTo(1));
        }
        [Test()]
        public void Row2HasWonP2()

        {
            TestSetup();
            regions[3].State = -1;
            regions[4].State = -1;
            regions[5].State = -1;
            Assert.That(WinStateManager.WhichPlayerWon(regions), Is.EqualTo(-1));
        }
        [Test()]
        public void Col1HasWonP1()
        {
            TestSetup();
            regions[0].State = 1;
            regions[3].State = 1;
            regions[6].State = 1;
            Assert.That(WinStateManager.WhichPlayerWon(regions), Is.EqualTo(1));
        }
        [Test()]
        public void Col2HasWonP2()
        {
            TestSetup();
            regions[1].State = -1;
            regions[4].State = -1;
            regions[7].State = -1;
            Assert.That(WinStateManager.WhichPlayerWon(regions), Is.EqualTo(-1));
        }
        [Test()]
        public void Diag1HasWonP1()
        {
            TestSetup();
            regions[0].State = 1;
            regions[4].State = 1;
            regions[8].State = 1;
            Assert.That(WinStateManager.WhichPlayerWon(regions), Is.EqualTo(1));
        }

        [Test()]
        public void Diag2HasWonP2()
        {
            TestSetup();
            regions[2].State = -1;
            regions[4].State = -1;
            regions[6].State = -1;
            Assert.That(WinStateManager.WhichPlayerWon(regions), Is.EqualTo(-1));
        }
        [Test]
        public void NoPlayerHasWon()
        {
            TestSetup();
            Assert.That(WinStateManager.PlayerWhoWon, Is.EqualTo(""));
        }

        [Test]
        public void Player1HasWonMessage()
        {
            TestSetup();
            regions[0].State = 1;
            regions[4].State = 1;
            regions[8].State = 1;
            WinStateManager.Update(regions);
            Assert.That(WinStateManager.PlayerWhoWon, Is.EqualTo("P1 Wins"));
        }
        /*
        [Test]
        public void Player2HasWonMessage()
        {
            TestSetup();
            regions[4].State = -1;
            regions[5].State = -1;
            regions[6].State = -1;
            WinStateManager.Update(regions);
            Assert.That(WinStateManager.PlayerWhoWon, Is.EqualTo("P2 Wins"));
        }*/
        [Test]
        public void KeepPlayingWhenNoPlayerWon()
        {
            TestSetup();
            WinStateManager.Update(regions);
            Assert.That(WinStateManager.CanKeepPlaying, Is.EqualTo(true));
        }

        [TestCase(1)]
        [TestCase(-1)]
        public void CantKeepPlayingWhenNoPlayerWon(int x)
        {
            TestSetup();
            regions[0].State = x;
            regions[4].State = x;
            regions[8].State = x;
            WinStateManager.Update(regions);
            Assert.That(WinStateManager.CanKeepPlaying, Is.EqualTo(false));
        }
    }
}
