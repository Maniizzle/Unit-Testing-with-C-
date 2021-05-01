using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameEngine.Test
{
    //[Trait("Category", "Enemy")]
    public class EnemyFactoryShould
    {
        [Fact]
        [Trait("Category", "Enemy")]

        public void CreateNormalEnemyByDefault()
        {
            EnemyFactory sut = new EnemyFactory();
            Enemy enemy = sut.Create("Zombie");
            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact(Skip ="Dont need to run this")]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {
            EnemyFactory sut = new EnemyFactory();
            Enemy enemy = sut.Create("Zombie");
            Assert.IsNotType<DateTime>(enemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            EnemyFactory sut = new EnemyFactory();
            Enemy enemy = sut.Create("Zombie King",true);
            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            EnemyFactory sut = new EnemyFactory();
            Enemy enemy = sut.Create("Zombie King",true);
          BossEnemy boss=  Assert.IsType<BossEnemy>(enemy);

            Assert.Equal("Zombie King", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            EnemyFactory sut = new EnemyFactory();
            Enemy enemy = sut.Create("Zombie King",true);
            //Assert.IsType<Enemy>(enemy);
            Assert.IsAssignableFrom<Enemy>(enemy);
        }

        [Fact]
        public void CreateSeperateInstances()
        {
            EnemyFactory sut = new EnemyFactory();
            Enemy enemy = sut.Create("Zombie King");
            Enemy enemy2 = sut.Create("Zombie King");
            Assert.NotSame(enemy,enemy2);
        }

        [Fact]
        public void NotAllowNullName()
        {
            EnemyFactory sut = new EnemyFactory();
           //Assert.Throws<ArgumentNullException>(()=>sut.Create(null));
           Assert.Throws<ArgumentNullException>("name",()=>sut.Create(null));
        }

        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            EnemyFactory sut = new EnemyFactory();
            //Assert.Throws<ArgumentNullException>(()=>sut.Create(null));
           EnemyCreationException ex= Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie",true));
            Assert.StartsWith("Zombie",ex.Message);
        }


    }
}
