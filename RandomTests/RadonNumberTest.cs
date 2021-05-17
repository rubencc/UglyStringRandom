namespace RadonNumberTests
{
    using FluentAssertions;
    using UglyStringRandom;
    using Xunit;

    public class RandomNumberTest
    {
        private IRandomNumber rn;

        public RandomNumberTest()
        {
            this.rn = new RandomNumber();
        }

        ~ RandomNumberTest()
        {
            this.rn = null;
        }

        [Fact]
        public void Get_random_integer()
        {
            int random = this.rn.GetInteger();

            random.Should().NotBe(0);
        }

        [Fact]
        public void Get_list_random_integer()
        {
            var list = this.rn.GetIntegers(2);

            list.Should().NotContain(0);
        }
    }
}
