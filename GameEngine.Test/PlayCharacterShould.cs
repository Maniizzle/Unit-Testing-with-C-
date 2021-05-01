using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Test
{
    public class PlayCharacterShould
    {
        private readonly ITestOutputHelper output;
        private readonly PlayerCharacter sut;

        public PlayCharacterShould(ITestOutputHelper output)
        {//constructor is executed for every test run
            this.output = output;
            output.WriteLine("Creating new PlayerCharacter");
            sut = new PlayerCharacter();
        }
        [Fact]
        public void BeInexperiencedWhenNew()
        {

            Assert.True(sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";
            Assert.Equal("Sarah Smith",sut.FullName);
            Assert.StartsWith("Sarah",sut.FullName);
        }

        [Fact]
        public void HavingFUllNameStartWithFirstName()
        {
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";
            Assert.StartsWith("Sarah", sut.FullName);
        }

        [Fact]
        public void HavingFullNameEndsWithLastName()
        {
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";
            Assert.StartsWith("Sarah", sut.FullName);
        }

        [Fact]
        public void CalculateFirstName_IgnoreCaseAssertExample()
        {
            sut.FirstName = "SARAH";
            sut.LastName = "SMITH";
            Assert.Equal("Sarah Smith", sut.FullName,ignoreCase:true);
        }

        [Fact]
        public void CalculateFullNameContainCaseAssertExample()
        {
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";
            Assert.Contains("ah Sm", sut.FullName);
        }
        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]", sut.FullName);
        }
        [Fact]
        public void StartWithDefaultHealth()
        {
            Assert.Equal(100, sut.Health);
        }
        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            Assert.NotEqual(0, sut.Health);
        }


        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            sut.Sleep();

        //     Assert.True(sut.Health>= 101 && sut.Health<=200);
            Assert.InRange(sut.Health,101, 200);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            Assert.Null(sut.Nickname);
        }

        [Fact]
        public void HaveALongBow()
        {
            Assert.Contains("Long Bow", sut.Weapons);
        }

        [Fact]
        public void NotAStaffOfWonder()
        {
            Assert.DoesNotContain("Staff of Wonder", sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKIndOfSword()
        {
            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));// sut.Health);
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            var expecredWeapons = new[]
            {
               "Long Bow",
               "Short Bow",
               "Short Sword"
           };
            
            Assert.Equal(expecredWeapons, sut.Weapons);
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void RaiseSleptEvent()
        {
            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                () => sut.Sleep());

                
         }

        [Fact]
        public void RaaisePropertyChangedEvent()
        {
            Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(10));
        }

    }
}
