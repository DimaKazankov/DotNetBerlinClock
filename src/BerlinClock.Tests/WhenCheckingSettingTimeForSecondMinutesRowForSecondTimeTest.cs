using BerlinClock.Domain;
using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    internal sealed class WhenCheckingSettingTimeForSecondMinutesRowForSecondTimeTest
    {
        [Test]
        public void ThenLamsShouldTurnedOnCorrectlyTest()
        {
            // Arrange
            const int anyHours = 14;
            const int anySeconds = 34;
            var clock = new Domain.BerlinClock();
            clock.SetTime(anyHours, 59, anySeconds);

            // Act
            clock.SetTime(anyHours, 16, anySeconds);

            // Assert
            Assert.That(clock.SecondMinutesRow[0], Is.EqualTo(MinutesColor.Yellow));
            Assert.That(clock.SecondMinutesRow[1], Is.EqualTo(MinutesColor.None));
            Assert.That(clock.SecondMinutesRow[2], Is.EqualTo(MinutesColor.None));
            Assert.That(clock.SecondMinutesRow[3], Is.EqualTo(MinutesColor.None));
        }
    }
}