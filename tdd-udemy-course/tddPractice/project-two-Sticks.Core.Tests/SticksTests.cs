﻿namespace project_two_Sticks.Core.Tests;

[TestFixture]
public class SticksTests
{
   [Test]
   public void Constructor_LessThan10Sticks_ThrowsArgumentException()
   {
      Assert.Throws<ArgumentException>(() => new Game(9, Player.Machine));
   }

   [Test]
   public void Constructor_ValidParams_GameReturnCorrectState()
   {
      int sticks = 10;
      var player = Player.Machine;

      var game = new Game(sticks, player);

      Assert.That(game.NumberOfSticks, Is.EqualTo(sticks));
      Assert.That(game.Turn, Is.EqualTo(player));
   }

}

