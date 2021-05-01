using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameEngine.Test
{
    [CollectionDefinition("GameState collection")]
   public class GameStateCollection : ICollectionFixture<GameStateFixture> 
    {

    }
}
