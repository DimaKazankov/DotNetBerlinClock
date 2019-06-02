using BerlinClock.Domain;
using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    internal sealed class WhenCheckingSettingTimeForFirstHoursRowTest
    {
        [TestCase(4)]
        [TestCase(6, HoursColor.Red)]
        [TestCase(12, HoursColor.Red, HoursColor.Red)]
        [TestCase(16, HoursColor.Red, HoursColor.Red, HoursColor.Red)]
        [TestCase(21, HoursColor.Red, HoursColor.Red, HoursColor.Red, HoursColor.Red)]
        public void ThenLamsShouldTurnedOnCorrectlyTest(int hours,
            HoursColor colorOfFirstLampColor = HoursColor.None, HoursColor colorOfSecondLampColor = HoursColor.None,
            HoursColor colorOfThirdLampColor = HoursColor.None, HoursColor colorOfForthLampColor = HoursColor.None)
        {
            // Arrange
            const int anyMinutes = 34;
            const int anySeconds = 34;
            var clock = new Domain.BerlinClock();

            // Act
            clock.SetTime(hours, anyMinutes, anySeconds);

            // Assert
            Assert.That(clock.FirstHoursRow[0], Is.EqualTo(colorOfFirstLampColor));
            Assert.That(clock.FirstHoursRow[1], Is.EqualTo(colorOfSecondLampColor));
            Assert.That(clock.FirstHoursRow[2], Is.EqualTo(colorOfThirdLampColor));
            Assert.That(clock.FirstHoursRow[3], Is.EqualTo(colorOfForthLampColor));
        }
    }
}