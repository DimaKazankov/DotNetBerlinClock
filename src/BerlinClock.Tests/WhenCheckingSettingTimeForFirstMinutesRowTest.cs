using BerlinClock.Domain;
using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    internal sealed class WhenCheckingSettingTimeForFirstMinutesRowTest
    {
        [TestCase(4)]
        [TestCase(6, MinutesColor.Yellow)]
        [TestCase(12, MinutesColor.Yellow, MinutesColor.Yellow)]
        [TestCase(16, MinutesColor.Yellow, MinutesColor.Yellow, MinutesColor.Red)]
        [TestCase(21, MinutesColor.Yellow, MinutesColor.Yellow, MinutesColor.Red, MinutesColor.Yellow)]
        [TestCase(25, MinutesColor.Yellow, MinutesColor.Yellow, MinutesColor.Red, MinutesColor.Yellow,
            MinutesColor.Yellow)]
        [TestCase(31, MinutesColor.Yellow, MinutesColor.Yellow, MinutesColor.Red, MinutesColor.Yellow,
            MinutesColor.Yellow, MinutesColor.Red)]
        [TestCase(36, MinutesColor.Yellow, MinutesColor.Yellow, MinutesColor.Red, MinutesColor.Yellow,
            MinutesColor.Yellow, MinutesColor.Red, MinutesColor.Yellow)]
        [TestCase(40, MinutesColor.Yellow, MinutesColor.Yellow, MinutesColor.Red, MinutesColor.Yellow,
            MinutesColor.Yellow, MinutesColor.Red, MinutesColor.Yellow, MinutesColor.Yellow)]
        [TestCase(47, MinutesColor.Yellow, MinutesColor.Yellow, MinutesColor.Red, MinutesColor.Yellow,
            MinutesColor.Yellow, MinutesColor.Red, MinutesColor.Yellow, MinutesColor.Yellow, MinutesColor.Red)]
        [TestCase(52, MinutesColor.Yellow, MinutesColor.Yellow, MinutesColor.Red, MinutesColor.Yellow,
            MinutesColor.Yellow, MinutesColor.Red, MinutesColor.Yellow, MinutesColor.Yellow, MinutesColor.Red,
            MinutesColor.Yellow)]
        [TestCase(58, MinutesColor.Yellow, MinutesColor.Yellow, MinutesColor.Red, MinutesColor.Yellow,
            MinutesColor.Yellow, MinutesColor.Red, MinutesColor.Yellow, MinutesColor.Yellow, MinutesColor.Red,
            MinutesColor.Yellow, MinutesColor.Yellow)]
        public void ThenLamsShouldTurnedOnCorrectlyTest(int minutes,
            MinutesColor colorOfFirstLampColor = MinutesColor.None,
            MinutesColor colorOfSecondLampColor = MinutesColor.None,
            MinutesColor colorOfThirdLampColor = MinutesColor.None,
            MinutesColor colorOfForthLampColor = MinutesColor.None,
            MinutesColor colorOfFifthLampColor = MinutesColor.None,
            MinutesColor colorOfSixthLampColor = MinutesColor.None,
            MinutesColor colorOfSeventhLampColor = MinutesColor.None,
            MinutesColor colorOfEighthLampColor = MinutesColor.None,
            MinutesColor colorOfNinthLampColor = MinutesColor.None,
            MinutesColor colorOfTenthLampColor = MinutesColor.None,
            MinutesColor colorOfEleventhLampColor = MinutesColor.None)
        {
            // Arrange
            const int anyHours = 14;
            const int anySeconds = 34;
            var clock = new Domain.BerlinClock();

            // Act
            clock.SetTime(anyHours, minutes, anySeconds);

            // Assert
            Assert.That(clock.FirstMinutesRow[0], Is.EqualTo(colorOfFirstLampColor));
            Assert.That(clock.FirstMinutesRow[1], Is.EqualTo(colorOfSecondLampColor));
            Assert.That(clock.FirstMinutesRow[2], Is.EqualTo(colorOfThirdLampColor));
            Assert.That(clock.FirstMinutesRow[3], Is.EqualTo(colorOfForthLampColor));
            Assert.That(clock.FirstMinutesRow[4], Is.EqualTo(colorOfFifthLampColor));
            Assert.That(clock.FirstMinutesRow[5], Is.EqualTo(colorOfSixthLampColor));
            Assert.That(clock.FirstMinutesRow[6], Is.EqualTo(colorOfSeventhLampColor));
            Assert.That(clock.FirstMinutesRow[7], Is.EqualTo(colorOfEighthLampColor));
            Assert.That(clock.FirstMinutesRow[8], Is.EqualTo(colorOfNinthLampColor));
            Assert.That(clock.FirstMinutesRow[9], Is.EqualTo(colorOfTenthLampColor));
            Assert.That(clock.FirstMinutesRow[10], Is.EqualTo(colorOfEleventhLampColor));
        }
    }
}