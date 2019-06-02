using BerlinClock.Domain;
using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    internal sealed class WhenCheckingSettingTimeForSecondMinutesRowTest
    {
        [TestCase(4, MinutesColor.Yellow, MinutesColor.Yellow, MinutesColor.Yellow, MinutesColor.Yellow)]
        [TestCase(16, MinutesColor.Yellow)]
        [TestCase(32, MinutesColor.Yellow, MinutesColor.Yellow)]
        [TestCase(43, MinutesColor.Yellow, MinutesColor.Yellow, MinutesColor.Yellow)]
        [TestCase(59, MinutesColor.Yellow, MinutesColor.Yellow, MinutesColor.Yellow, MinutesColor.Yellow)]
        public void ThenLamsShouldTurnedOnCorrectlyTest(int minutes,
            MinutesColor colorOfFirstLampColor = MinutesColor.None,
            MinutesColor colorOfSecondLampColor = MinutesColor.None,
            MinutesColor colorOfThirdLampColor = MinutesColor.None,
            MinutesColor colorOfForthLampColor = MinutesColor.None)
        {
            // Arrange
            const int anyHours = 14;
            const int anySeconds = 34;
            var clock = new Domain.BerlinClock();

            // Act
            clock.SetTime(anyHours, minutes, anySeconds);

            // Assert
            Assert.That(clock.SecondMinutesRow[0], Is.EqualTo(colorOfFirstLampColor));
            Assert.That(clock.SecondMinutesRow[1], Is.EqualTo(colorOfSecondLampColor));
            Assert.That(clock.SecondMinutesRow[2], Is.EqualTo(colorOfThirdLampColor));
            Assert.That(clock.SecondMinutesRow[3], Is.EqualTo(colorOfForthLampColor));
        }
    }
}