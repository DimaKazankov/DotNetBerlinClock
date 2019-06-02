using System;

namespace BerlinClock.Domain
{
    internal sealed class BerlinClock
    {
        public SecondsColor SecondsRow { get; private set; } = SecondsColor.None;

        public HoursColor[] FirstHoursRow { get; } = new HoursColor[4];
        public HoursColor[] SecondHoursRow { get; } = new HoursColor[4];
        public MinutesColor[] FirstMinutesRow { get; } = new MinutesColor[11];
        public MinutesColor[] SecondMinutesRow { get; } = new MinutesColor[4];

        public void SetTime(int hours, int minutes, int seconds)
        {
            if (hours < 0 || hours > 24)
                throw new ArgumentException(nameof(hours));
            if (minutes < 0 || minutes > 60)
                throw new ArgumentException(nameof(minutes));
            if (seconds < 0 || seconds > 60)
                throw new ArgumentException(nameof(seconds));

            ResetTime();

            SecondsRow = seconds % 2 == 0 ? SecondsColor.Yellow : SecondsColor.None;

            for (var i = 0; i < hours / 5; i++)
            {
                FirstHoursRow[i] = HoursColor.Red;
            }

            for (var i = 0; i < hours % 5; i++)
            {
                SecondHoursRow[i] = HoursColor.Red;
            }

            for (var i = 0; i < minutes / 5; i++)
            {
                FirstMinutesRow[i] = (i + 1) % 3 == 0 ? MinutesColor.Red : MinutesColor.Yellow;
            }

            for (var i = 0; i < minutes % 5; i++)
            {
                SecondMinutesRow[i] = MinutesColor.Yellow;
            }
        }

        private void ResetTime()
        {
            for (var i = 0; i < FirstHoursRow.Length; i++)
            {
                FirstHoursRow[i] = HoursColor.None;
            }

            for (var i = 0; i < SecondHoursRow.Length; i++)
            {
                SecondHoursRow[i] = HoursColor.None;
            }

            for (var i = 0; i < FirstMinutesRow.Length; i++)
            {
                FirstMinutesRow[i] = MinutesColor.None;
            }

            for (var i = 0; i < SecondMinutesRow.Length; i++)
            {
                SecondMinutesRow[i] = MinutesColor.None;
            }
        }
    }
}