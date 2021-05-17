namespace RadonNumberTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
    using UglyStringRandom;
    using Xunit;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    public class RandomStringTest
    {
        private IRandomNumber rn;
        private IRandomString rs;

        private readonly ITestOutputHelper output;

        public RandomStringTest(ITestOutputHelper output)
        {
            this.output = output ?? throw new ArgumentNullException(nameof(output));
            this.rn = new RandomNumber();
            this.rs = new RandomString(this.rn);
        }

        ~RandomStringTest()
        {
            this.rn = null;
            this.rs = null;
        }


        [Fact]
        public void Get_only_upper_string_random()
        {
            string random = this.rs.GetRandom(3, StringDataSet.Upper);

            foreach (var c in random.ToArray())
            {
                StringDataSet.Upper.Contains(c).Should().BeTrue();
            }
        }

        [Fact]
        public void Get_only_lower_string_random()
        {
            string random = this.rs.GetRandom(3, StringDataSet.Lower);

            foreach (var c in random.ToArray())
            {
                StringDataSet.Lower.Contains(c).Should().BeTrue();
            }
        }

        [Fact]
        public void Get_only_number_string_random()
        {
            string random = this.rs.GetRandom(3, StringDataSet.Digits);

            foreach (var c in random.ToArray())
            {
                StringDataSet.Digits.Contains(c).Should().BeTrue();
            }
        }
    }
}
