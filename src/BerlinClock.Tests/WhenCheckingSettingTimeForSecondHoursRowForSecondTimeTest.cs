using BerlinClock.Domain;
using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    internal sealed class WhenCheckingSettingTimeForSecondHoursRowForSecondTimeTest
    {
        [Test]
        public void ThenLamsShouldTurnedOnCorrectlyTest()
        {
            // Arrange
            const int anyMinutes = 34;
            const int anySeconds = 34;
            var clock = new Domain.BerlinClock();
            clock.SetTime(24, anyMinutes, anySeconds);

            // Act
            clock.SetTime(11, anyMinutes, anySeconds);

            // Assert
            Assert.That(clock.SecondHoursRow[0], Is.EqualTo(HoursColor.Red));
            Assert.That(clock.SecondHoursRow[1], Is.EqualTo(HoursColor.None));
            Assert.That(clock.SecondHoursRow[2], Is.EqualTo(HoursColor.None));
            Assert.That(clock.SecondHoursRow[3], Is.EqualTo(HoursColor.None));
        }
    }
}