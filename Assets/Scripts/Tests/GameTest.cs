using System;
using Ash.Runtime.Core;
using NSubstitute;
using NUnit.Framework;

namespace Ash.Tests
{
	public class GameTest
	{
		
		[Test]
		public void WhenGameIsStarted_PlayerIsSpawn()
		{
			var player = Substitute.For<IPlayer>();
			var space = Substitute.For<ISpace>();

			var game = new Game(space, player, 3);
			game.StartStage(new Stage(1));
			
			player.Received().Spawn();
		}
		
		[Test]
		public void WhenGameIsStarted_PlayerInputIsEnabled()
		{
			var player = Substitute.For<IPlayer>();
			var space = Substitute.For<ISpace>();

			var game = new Game(space, player, 3);
			game.StartStage(new Stage(1));
			
			player.Received().EnableInput();
		}
		
		[Test]
		public void WhenGameIsOver_PlayerInputIsDisabled()
		{
			var player = Substitute.For<IPlayer>();
			var space = Substitute.For<ISpace>();

			var game = new Game(space, player, 1);
			game.StartStage(new Stage(1));
			
			player.Destroyed += Raise.Event<Action>();
			
			player.Received().DisableInput();
		}
		
		[Test]
		public void WhenGameIsRestarted_SpaceIsCleared()
		{
			var player = Substitute.For<IPlayer>();
			var space = Substitute.For<ISpace>();

			var game = new Game(space, player, 1);
			game.Restart();
			
			space.Received().Clear();
		}
		
		[Test]
		public void WhenPlayerIsDestroyed_InvincibilityEffectIsApplied()
		{
			var player = Substitute.For<IPlayer>();
			var space = Substitute.For<ISpace>();

			var game = new Game(space, player, 3);
			game.StartStage(new Stage(1));
			
			player.Destroyed += Raise.Event<Action>();
			
			player.Received().ApplyInvincibility();
		}
		
		[Test]
		public void WhenGameIsStarted_LargeAsteroidsAreSpawn()
		{
			var player = Substitute.For<IPlayer>();
			var space = Substitute.For<ISpace>();
			var game = new Game(space, player,3);

			var stage = new Stage(3);
			
			game.StartStage(stage);
			
			
			space.Received().SpawnAsteroidsScattered(AsteroidType.Large, stage.AsteroidsCount);
		}
		
		
		[Test]
		public void WhenAnAsteroidIsDestroyed_ScoreIsIncreased()
		{
			var player = Substitute.For<IPlayer>();
			var space = Substitute.For<ISpace>();
			var game = new Game(space, player,3);

			var stage = new Stage(3);
			var destroyable = Substitute.For<IDestroyable>();
			destroyable.DestructionScore.Returns(3);
			
			game.StartStage(stage);

			space.EntityDestroyed += Raise.Event<Action<IDestroyable>>(destroyable);
			
			Assert.AreEqual(3, game.State.Score);
		}
		
		[Test]
		public void WhenPlayerIsDestroyed_LivesIsReduced()
		{
			var player = Substitute.For<IPlayer>();
			var space = Substitute.For<ISpace>();
			var game = new Game(space, player,3);

			var stage = new Stage(3);
			
			game.StartStage(stage);

			player.Destroyed += Raise.Event<Action>();
			
			Assert.AreEqual(2, game.State.Lives);
		}
		
		[Test]
		public void WhenLivesReachZero_MustGameOverEventBeInvoked()
		{
			var player = Substitute.For<IPlayer>();
			var space = Substitute.For<ISpace>();
			var game = new Game(space, player,1);

			var stage = new Stage(3);
			bool invoked = false;
			game.GameOver += () => invoked = true;
			
			game.StartStage(stage);

			player.Destroyed += Raise.Event<Action>();
			
			Assert.AreEqual(true, invoked);
		}
	}
}