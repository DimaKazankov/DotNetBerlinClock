using System;
using System.Text;
using System.Text.RegularExpressions;
using BerlinClock.Domain;

namespace BerlinClock
{
    internal sealed class TimeConverter
    {
        private const string Pattern = @"^(2[0-4]|[01]?[0-9]):([0-5]?[0-9]):([0-5]?[0-9])$";
        private readonly Regex _twentyFourTimeSpanRegex = new Regex(Pattern, RegexOptions.Compiled);

        public string ConvertTime(string time)
        {
            var match = _twentyFourTimeSpanRegex.Match(time);
            if (!match.Success)
                throw new ArgumentException(nameof(time));

            var clock = new Domain.BerlinClock();
            clock.SetTime(match.GroupToInt(1), match.GroupToInt(2), match.GroupToInt(3));

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(clock.SecondsRow == SecondsColor.None ? "O" : "Y");
            stringBuilder.AppendLine(clock.FirstHoursRow,
                                     color => color == HoursColor.None ? "O" : "R");
            stringBuilder.AppendLine(clock.SecondHoursRow,
                                     color => color == HoursColor.None ? "O" : "R");
            stringBuilder.AppendLine(clock.FirstMinutesRow,
                                     color => color == MinutesColor.None
                                                  ? "O"
                                                  : color == MinutesColor.Yellow ? "Y" : "R");
            stringBuilder.Append(clock.SecondMinutesRow,
                                 color => color == MinutesColor.None ? "O" : "Y");
            return stringBuilder.ToString();
        }
    }
}