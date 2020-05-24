using FluentAssertions;
using HackerrankChallenges.ChallengesSolutions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChallengesTests
{
    public class ChooseFlaskTests
    {
        [Fact]
        public void Testa()
        {
            var markings = new List<List<int>>();
            var firstElement = new List<int> { 0,3 };
            var firstElement1 = new List<int> { 0,5 };
            var firstElement2 = new List<int> { 0,7 };

            var secondElement = new List<int> { 1,6 };
            var secondElement1 = new List<int> { 1,8 };
            var secondElement2 = new List<int> { 1,9 };

            var thirdElement = new List<int> { 2,3 };
            var thirdElement1 = new List<int> { 2,5 };
            var thirdElement2 = new List<int> { 2,6 };

            markings.Add(firstElement);
            markings.Add(firstElement1);
            markings.Add(firstElement2);

            markings.Add(secondElement);
            markings.Add(secondElement1);
            markings.Add(secondElement2);

            markings.Add(thirdElement);
            markings.Add(thirdElement1);
            markings.Add(thirdElement2);

            var flaskTypes = 3;
            var requirements = new List<int> { 4, 7,6,6 };

            var teste = ChooseFlask.Solution(requirements, flaskTypes, markings);

            teste.Should().Be(0);
        }

        [Fact]
        public void Testa2()
        {
            var markings = new List<List<int>>();
            var firstElement = new List<int> { 0,3 };
            var firstElement1 = new List<int> { 0,5 };
            var firstElement2 = new List<int> { 0,7 };

            var secondElement = new List<int> { 1,6 };
            var secondElement1 = new List<int> { 1,8 };
            var secondElement2 = new List<int> { 1,9 };

            var thirdElement = new List<int> { 2,3 };
            var thirdElement1 = new List<int> { 2,5 };
            var thirdElement2 = new List<int> { 2,6 };

            markings.Add(firstElement);
            markings.Add(firstElement1);
            markings.Add(firstElement2);

            markings.Add(secondElement);
            markings.Add(secondElement1);
            markings.Add(secondElement2);

            markings.Add(thirdElement);
            markings.Add(thirdElement1);
            markings.Add(thirdElement2);

            var flaskTypes = 3;
            var requirements = new List<int> { 20, 30, 30, 50 };

            var teste = ChooseFlask.Solution(requirements, flaskTypes, markings);

            teste.Should().Be(-1);
        }

        [Fact]
        public void Testa3()
        {
            var markings = new List<List<int>>();
            var firstElement = new List<int> { 0,5 };
            var firstElement1 = new List<int> { 0,7 };
            var firstElement2 = new List<int> { 0,10 };

            var secondElement = new List<int> { 1,4 };
            var secondElement1 = new List<int> { 1,10 };

            markings.Add(firstElement);
            markings.Add(firstElement1);
            markings.Add(firstElement2);

            markings.Add(secondElement);
            markings.Add(secondElement1);

            var flaskTypes = 2;
            var requirements = new List<int> { 4,6 };

            var teste = ChooseFlask.Solution(requirements, flaskTypes, markings);

            teste.Should().Be(0);
        }

        [Fact]
        public void Testa4()
        {
            var markings = new List<List<int>>();
            var firstElement = new List<int> { 0, 11 };
            var firstElement1 = new List<int> { 0, 20 };

            var secondElement = new List<int> { 1, 11 };
            var secondElement1 = new List<int> { 1, 17 };

            var thirdElement = new List<int> { 2,12 };
            var thirdElement1 = new List<int> { 2,16 };

            markings.Add(firstElement);
            markings.Add(firstElement1);

            markings.Add(secondElement);
            markings.Add(secondElement1);

            markings.Add(thirdElement);
            markings.Add(thirdElement1);

            var flaskTypes = 3;
            var requirements = new List<int> { 10,15 };

            var teste = ChooseFlask.Solution(requirements, flaskTypes, markings);

            teste.Should().Be(1);
        }
    }
}
