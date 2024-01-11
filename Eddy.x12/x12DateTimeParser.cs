using System;
using System.Collections.Generic;

namespace Eddy.x12;

[Flags]
public enum SupportedDateFormats
{
    SixDigit = 1, // yyMMdd
    EightDigit = 2, // yyyyMMdd
    All = SixDigit | EightDigit
}

[Flags]
public enum SupportedTimeFormats
{
    FourDigit = 1, // HHmm
    SixDigit = 2, // HHmmss
    SevenDigit = 4, // HHmmssf
    EightDigit = 8, // HHmmssff
    All = FourDigit | SixDigit | SevenDigit | EightDigit
}

public class TimeZoneInfo2
{
    public string Name { get; set; }
    public TimeZoneInfo2(string name)
    {
        Name = name;
    }

    public DateTimeOffset SetTimezone(DateTime input)
    {
        var tzInfo = TimeZoneInfo.FindSystemTimeZoneById(Name);
        var offset = tzInfo.GetUtcOffset(input);
        return new DateTimeOffset(input.Year, input.Month, input.Day, input.Hour, input.Minute, input.Second, offset);
    }
}

public class x12DateTimeParser
{
    public static DateTimeOffset ConvertToTimeZone(DateTime input, string timeZoneCode)
    {
       

        var timezoneOffsets = new Dictionary<string, TimeZoneInfo2>
        {
            { "AD", new ("Alaskan Standard Time") },
            { "AS", new ("Alaskan Standard Time")},
            { "AT", new ("Alaskan Standard Time") },
            { "CD", new ("Central Standard Time") },
            { "CS", new ("Central Standard Time") },
            { "CT", new ("Central Standard Time") },
            { "ED", new ("Eastern Standard Time") },
            { "ES", new ("Eastern Standard Time") },
            { "ET", new ("Eastern Standard Time") },
            { "GM", new ("GMT Standard Time") },
            { "HD", new ("Hawaiian Standard Time") },
            { "HS", new ("Hawaiian Standard Time") },
            { "HT", new ("Hawaiian Standard Time") },
            //{ "LT", TimeSpan.FromHours(0) },
            { "MD", new ("Mountain Standard Time") },
            { "MS", new ("Mountain Standard Time") },
            { "MT", new ("Mountain Standard Time") },
            { "ND", new ("Newfoundland Standard Time") },
            { "NS", new ("Newfoundland Standard Time") },
            { "NT", new ("Newfoundland Standard Time") },
            { "PD", new ("Pacific Standard Time") },
            { "PS", new ("Pacific Standard Time") },
            { "PT", new ("Pacific Standard Time") },
            { "TD", new ("Atlantic Standard Time") },
            { "TS", new ("Atlantic Standard Time") },
            { "TT",new ("Atlantic Standard Time") },
        };


        var offset = new TimeSpan(); 
        if (timezoneOffsets.TryGetValue(timeZoneCode, out var solver))
        {
            return solver.SetTimezone(input);

        }

        switch (timeZoneCode)
        {
            case "P01": offset = TimeSpan.FromHours(1); break;
            case "P02": offset = TimeSpan.FromHours(2); break;
            case "P03": offset = TimeSpan.FromHours(3); break;
            case "P04": offset = TimeSpan.FromHours(4); break;
            case "P05": offset = TimeSpan.FromHours(5); break;
            case "P06": offset = TimeSpan.FromHours(6); break;
            case "P07": offset = TimeSpan.FromHours(7); break;
            case "P08": offset = TimeSpan.FromHours(8); break;
            case "P09": offset = TimeSpan.FromHours(9); break;
            case "P10": offset = TimeSpan.FromHours(10); break;
            case "P11": offset = TimeSpan.FromHours(11); break;
            case "P12": offset = TimeSpan.FromHours(12); break;
            case "M01": offset = TimeSpan.FromHours(-1); break;
            case "M02": offset = TimeSpan.FromHours(-2); break;
            case "M03": offset = TimeSpan.FromHours(-3); break;
            case "M04": offset = TimeSpan.FromHours(-4); break;
            case "M05": offset = TimeSpan.FromHours(-5); break;
            case "M06": offset = TimeSpan.FromHours(-6); break;
            case "M07": offset = TimeSpan.FromHours(-7); break;
            case "M08": offset = TimeSpan.FromHours(-8); break;
            case "M09": offset = TimeSpan.FromHours(-9); break;
            case "M10": offset = TimeSpan.FromHours(-10); break;
            case "M11": offset = TimeSpan.FromHours(-11); break;
            case "M12": offset = TimeSpan.FromHours(-12); break;
            case "UT": offset = TimeSpan.FromHours(0); break;
            case "LT": throw new InvalidOperationException("LT is not a supported timezone as we don't know if it is the senders local time, the receivers local time, or the locations local time .");
        }

        return new DateTimeOffset(input.Year, input.Month, input.Day, input.Hour, input.Minute, input.Second, offset);
        // var localDateTime = DateTime.SpecifyKind(input, DateTimeKind.Unspecified);
        // var localDateTimeOffset = new DateTimeOffset(localDateTime);
        // var convertedTime = localDateTimeOffset.ToOffset(offset);
        // return convertedTime;
    }

    public static DateTime Parse(string date, string time, SupportedDateFormats dateFormats, SupportedTimeFormats timeFormats)
    {
        var parseString = "";

        if (date.Length == 6 && dateFormats.HasFlag(SupportedDateFormats.SixDigit))
            parseString = "yyMMdd";
        else if (date.Length == 8 && dateFormats.HasFlag(SupportedDateFormats.EightDigit))
            parseString = "yyyyMMdd";
        else
            throw new InvalidOperationException("Unsupported date format.");

        if (time.Length == 4 && timeFormats.HasFlag(SupportedTimeFormats.FourDigit))
            parseString += "HHmm";
        else if (time.Length == 6 && timeFormats.HasFlag(SupportedTimeFormats.SixDigit))
            parseString += "HHmmss";
        else if (time.Length == 7 && timeFormats.HasFlag(SupportedTimeFormats.SevenDigit))
            parseString += "HHmmssf";
        else if (time.Length == 8 && timeFormats.HasFlag(SupportedTimeFormats.EightDigit))
            parseString += "HHmmssff";
        else
            throw new InvalidOperationException("Unsupported time format.");

        return DateTime.ParseExact(date + time, parseString, System.Globalization.CultureInfo.InvariantCulture);
    }

}