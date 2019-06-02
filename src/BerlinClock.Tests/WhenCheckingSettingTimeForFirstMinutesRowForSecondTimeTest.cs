using BerlinClock.Domain;
using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    internal sealed class WhenCheckingSettingTimeForFirstMinutesRowForSecondTimeTest
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
            Assert.That(clock.FirstMinutesRow[0], Is.EqualTo(MinutesColor.Yellow));
            Assert.That(clock.FirstMinutesRow[1], Is.EqualTo(MinutesColor.Yellow));
            Assert.That(clock.FirstMinutesRow[2], Is.EqualTo(MinutesColor.Red));
            Assert.That(clock.FirstMinutesRow[3], Is.EqualTo(MinutesColor.None));
            Assert.That(clock.FirstMinutesRow[4], Is.EqualTo(MinutesColor.None));
            Assert.That(clock.FirstMinutesRow[5], Is.EqualTo(MinutesColor.None));
            Assert.That(clock.FirstMinutesRow[6], Is.EqualTo(MinutesColor.None));
            Assert.That(clock.FirstMinutesRow[7], Is.EqualTo(MinutesColor.None));
            Assert.That(clock.FirstMinutesRow[8], Is.EqualTo(MinutesColor.None));
            Assert.That(clock.FirstMinutesRow[9], Is.EqualTo(MinutesColor.None));
            Assert.That(clock.FirstMinutesRow[10], Is.EqualTo(MinutesColor.None));
        }
    }
}