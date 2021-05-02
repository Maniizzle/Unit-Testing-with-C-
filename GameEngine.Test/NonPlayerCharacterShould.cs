using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameEngine.Test
{
   public class NonPlayerCharacterShould
    {
        [Theory]
        [MemberData(nameof(InternalHealthDamageTestData.TestData),MemberType =typeof(InternalHealthDamageTestData))]
        public void TakeDamage(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new NonPlayerCharacter();
            sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, sut.Health);
        }

        [Theory]
        [MemberData(nameof(ExternalHealthDamageTestData.TestData), MemberType = typeof(ExternalHealthDamageTestData))]
        public void TakeDamage2(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new NonPlayerCharacter();
            sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, sut.Health);
        }

        [Theory]
        [HealthDamageData]
        public void TakeDamageCustom(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new NonPlayerCharacter();
            sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, sut.Health);
        }

    }
}
