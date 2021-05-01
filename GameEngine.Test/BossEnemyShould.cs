using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Test
{
   public class BossEnemyShould
    {
        private readonly ITestOutputHelper outputHelper;

        public BossEnemyShould(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
        }

        [Fact]
        [Trait("Category","Boss")]
        public void HaveCorrectPower()
        {
            outputHelper.WriteLine("Creating Boss Enemy");
           BossEnemy sut = new BossEnemy();
            Assert.Equal(166.667, sut.TotalSpecialAttackPower,3);
        }
    }
}
