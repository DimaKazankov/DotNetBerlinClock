using BerlinClock.Domain;
using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    internal sealed class WhenCheckingSettingTimeForSecondsRowTest
    {
        [TestCase(00, SecondsColor.Yellow)]
        [TestCase(01, SecondsColor.None)]
        [TestCase(59, SecondsColor.None)]
        public void ThenLamsShouldTurnedOnCorrectlyTest(int seconds, SecondsColor color)
        {
            // Arrange
            const int anyHours = 14;
            const int anyMinutes = 34;
            var clock = new Domain.BerlinClock();
            clock.SetTime(anyHours, anyMinutes, seconds);

            // Act
            clock.SetTime(anyHours, anyMinutes, seconds);

            // Assert
            Assert.That(clock.SecondsRow, Is.EqualTo(color));
        }
    }
}