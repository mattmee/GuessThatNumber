using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GuessThatNumber
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void TestInputValid() 
        {
            Assert.IsTrue(Program.ValidateInput("50"), "Valid input returned false");
        }

        [Test]
        public void TestInputInvalid()
        {
            Assert.IsFalse(Program.ValidateInput("asdf"), "Invalid input returned true");
            Assert.IsFalse(Program.ValidateInput("mi gato es muy grande!!!"), "Invalid input returned true");
        }

        [Test]
        public void TestTooHigh()
        {
            Program.SetNumberToGuess(50);
            Assert.IsTrue(Program.IsGuessTooHigh(100), "Guess is higher than the number, but program said it was not too high");
            Assert.IsFalse(Program.IsGuessTooLow(100), "Guess is higher than the number, but program said it was too low");
        }

        [Test]
        public void TestTooLow()
        {
            Program.SetNumberToGuess(50);
            Assert.IsFalse(Program.IsGuessTooHigh(1), "Guess is lower than the number, but program said it was too high");
            Assert.IsTrue(Program.IsGuessTooLow(1), "Guess is lower than the number, but program said it was not too low");
        }

        [Test]
        public void TestNumberGuessed()
        {
            Program.SetNumberToGuess(50);
            Assert.IsFalse(Program.IsGuessTooHigh(50), "Guess is the number, but program said it was too high");
            Assert.IsFalse(Program.IsGuessTooLow(50), "Guess is the number, but program said it was too low");
        }

    }
}
