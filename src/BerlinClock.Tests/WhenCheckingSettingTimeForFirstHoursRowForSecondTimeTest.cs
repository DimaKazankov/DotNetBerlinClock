using BerlinClock.Domain;
using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    internal sealed class WhenCheckingSettingTimeForFirstHoursRowForSecondTimeTest
    {
        [Test]
        public void ThenLamsShouldTurnedOnCorrectlyTest()
        {
            // Arrange
            const int anyMinutes = 34;
            const int anySeconds = 34;
            var clock = new Domain.BerlinClock();
            clock.SetTime(22, anyMinutes, anySeconds);

            // Act
            clock.SetTime(7, anyMinutes, anySeconds);

            // Assert
            Assert.That(clock.FirstHoursRow[0], Is.EqualTo(HoursColor.Red));
            Assert.That(clock.FirstHoursRow[1], Is.EqualTo(HoursColor.None));
            Assert.That(clock.FirstHoursRow[2], Is.EqualTo(HoursColor.None));
            Assert.That(clock.FirstHoursRow[3], Is.EqualTo(HoursColor.None));
        }
    }
}