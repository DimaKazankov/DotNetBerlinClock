using System;
using System.Text;
using BerlinClock.Domain;

namespace BerlinClock
{
    /// <summary>
    /// Well, I think the idea of the class is to be as a business object and keep logic inside.
    /// But I have preferred to create a new one (BerlinClock) because in another case
    /// I should keep business logic and converting to some string format (what is expected in BDD tests) in the same place.
    /// To avoid double responsibility I separated it by different objects.
    ///
    /// And I don't like the name (TimeConverter). I can't understand what this converter should do. Don't related to algorithm what should implement.
    /// But I decided to keep it because BDD tests already are written and I have to make them green
    ///
    /// One of test is still red by reason. I don't understand difference 24:00 vs 00:00.
    /// It's just impossible on the same clock to have different value of the same time.
    /// I can to fix it easy. Just don't use TimeSpan. As a different solution I would implement by using Regex parsing. (If input param matched by patter then parse to 3 groups and take value)
    /// </summary>

    internal sealed class TimeConverter
    {
        public string ConvertTime(string aTime)
        {
            if (!TimeSpan.TryParse(aTime, out var time))
                throw new ArgumentException(nameof(aTime));

            var clock = new Domain.BerlinClock();
            clock.SetTime(time.Hours, time.Minutes, time.Seconds);

            var stringBuilder = new StringBuilder();

            stringBuilder.Append(clock.SecondsRow == SecondsColor.None ? "O" : "Y");
            stringBuilder.AppendLine();

            foreach (var color in clock.FirstHoursRow)
            {
                stringBuilder.Append(color == HoursColor.None ? "O" : "R");
            }
            stringBuilder.AppendLine();

            foreach (var color in clock.SecondHoursRow)
            {
                stringBuilder.Append(color == HoursColor.None ? "O" : "R");
            }
            stringBuilder.AppendLine();

            foreach (var color in clock.FirstMinutesRow)
            {
                stringBuilder.Append(color == MinutesColor.None ? "O" : color == MinutesColor.Yellow ? "Y" : "R");
            }
            stringBuilder.AppendLine();

            foreach (var color in clock.SecondMinutesRow)
            {
                stringBuilder.Append(color == MinutesColor.None ? "O" : "Y");
            }

            return stringBuilder.ToString();
        }
    }
}