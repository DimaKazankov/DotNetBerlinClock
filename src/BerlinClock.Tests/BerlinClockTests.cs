using System;
using System.Linq;
using BerlinClock.Domain;
using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    internal sealed class BerlinClockTests
    {
        [Test]
        public void WhenBerlinClockCreatedThenStateIsExpectedTest()
        {
            // Arrange & Act
            var clock = new Domain.BerlinClock();

            // Assert
            Assert.That(clock.FirstHoursRow.Length, Is.EqualTo(4));
            Assert.That(clock.SecondHoursRow.Length, Is.EqualTo(4));
            Assert.That(clock.FirstMinutesRow.Length, Is.EqualTo(11));
            Assert.That(clock.SecondMinutesRow.Length, Is.EqualTo(4));

            Assert.That(clock.FirstHoursRow.Select(a => a), Is.All.EqualTo(HoursColor.None));
            Assert.That(clock.SecondHoursRow.Select(a => a), Is.All.EqualTo(HoursColor.None));
            Assert.That(clock.FirstMinutesRow.Select(a => a), Is.All.EqualTo(MinutesColor.None));
            Assert.That(clock.SecondMinutesRow.Select(a => a), Is.All.EqualTo(MinutesColor.None));
        }

        [TestCase(-1, 10, 10)]
        [TestCase(25, 10, 10)]
        [TestCase(12, -10, 10)]
        [TestCase(12, 61, 10)]
        [TestCase(12, 10, -10)]
        [TestCase(12, 10, 61)]
        public void WhenSetTimeWithWrongInputParamsThenShouldBeExceptionTest(int hours, int minutes, int seconds)
        {
            // Arrange & Act
            var clock = new Domain.BerlinClock();

            // Assert
            Assert.Throws<ArgumentException>(() => clock.SetTime(hours, minutes, seconds));
        }
    }
}