using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Test
{
   public class GameStateShould:IClassFixture<GameStateFixture>
    {
        private readonly GameStateFixture _gameStateFixture;
        private readonly ITestOutputHelper _output;

        public GameStateShould(GameStateFixture gameStateFixture,ITestOutputHelper output)
        {
            _gameStateFixture = gameStateFixture;
            _output = output;
        }


        [Fact]
        public void DamageAllPlayersWhenEarthQuake()
        {
            _output.WriteLine($"Gamestate ID={_gameStateFixture.State.Id}");

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            _gameStateFixture.State.Players.Add(player1);
            _gameStateFixture.State.Players.Add(player2);

            var expectedHealthAfterEarthQuake = player1.Health - GameState.EarthquakeDamage;
            _gameStateFixture.State.Earthquake();

            Assert.Equal(expectedHealthAfterEarthQuake, player1.Health);
            Assert.Equal(expectedHealthAfterEarthQuake, player2.Health);
        }

    } 
}
