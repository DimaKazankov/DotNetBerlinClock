using System;

namespace BerlinClock.Domain
{
    internal sealed class BerlinClock
    {
        public SecondsColor SecondsRow { get; private set; } = SecondsColor.None;
        public HoursColor[] FirstHoursRow { get; private set; } = new HoursColor[4];
        public HoursColor[] SecondHoursRow { get; private set; } = new HoursColor[4];
        public MinutesColor[] FirstMinutesRow { get; private set; } = new MinutesColor[11];
        public MinutesColor[] SecondMinutesRow { get; private set; } = new MinutesColor[4];

        public void SetTime(int hours, int minutes, int seconds)
        {
            SetTime(0, hours, minutes, seconds);
        }

        public void SetTime(int day, int hours, int minutes, int seconds)
        {
            if (hours < 0 || hours > 24)
                throw new ArgumentException(nameof(hours));
            if (minutes < 0 || minutes > 60)
                throw new ArgumentException(nameof(minutes));
            if (seconds < 0 || seconds > 60)
                throw new ArgumentException(nameof(seconds));

            ResetTime();

            SecondsRow = seconds % 2 == 0 ? SecondsColor.Yellow : SecondsColor.None;

            FirstHoursRow.Populate(() => hours / 5, i => HoursColor.Red);
            SecondHoursRow.Populate(() => hours % 5, i => HoursColor.Red);
            FirstMinutesRow.Populate(() => minutes / 5, i => (i + 1) % 3 == 0 ? MinutesColor.Red : MinutesColor.Yellow);
            SecondMinutesRow.Populate(() => minutes % 5, i => MinutesColor.Yellow);
        }

        private void ResetTime()
        {
            SecondsRow = SecondsColor.None;
            FirstHoursRow = new HoursColor[4];
            SecondHoursRow = new HoursColor[4];
            FirstMinutesRow = new MinutesColor[11];
            SecondMinutesRow = new MinutesColor[4];
        }
    }
}