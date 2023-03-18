using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._210;

public class Date 
{
    public string DateQualifier { get; set; }
    public string TimeQualifer { get; set; }
    public DateTime DateTime { get; set; }

    public bool IncludeSecondsInDateTime{ get; set; }
    public bool IncludeTime { get; set; } = true;
    public string TimeCode { get; set; }
    public static Date From(G62_DateTime input)
    {
        var dates = new Date();
        dates.DateQualifier = input.DateQualifier;
        dates.TimeQualifer = input.TimeQualifier; //I is earliest pickup //K is latest pickup

        //TODO: parse timezone
        //Timezone may be something like PT which we need to convert to -05 for parse exact to work

        var format = "yyyyMMddHHmm";
        var dateAndTime = input.Date + input.Time;
        if (dateAndTime.Length == 14)
        {
            format = "yyyyMMddHHmmss";
            dates.IncludeSecondsInDateTime = true;
        }
        if (dateAndTime.Length == 8 ) //just date only
        {
            format = "yyyyMMdd";
            dates.IncludeTime = false;
        }

            dates.DateTime = System.DateTime.ParseExact(dateAndTime, format, CultureInfo.InvariantCulture);
        dates.TimeCode = input.TimeCode;
        return dates;
    }

    public G62_DateTime ToG62()
    {
        var g62 = new G62_DateTime();
        g62.DateQualifier = DateQualifier;
        g62.TimeQualifier = TimeQualifer;
        g62.Date = DateTime.ToString("yyyyMMdd");

        if (IncludeTime)
        {
            if (IncludeSecondsInDateTime)
                g62.Time = DateTime.ToString("HHmmss");
            else
                g62.Time = DateTime.ToString("HHmm");
            g62.TimeCode = TimeCode;
        }
        return g62;
    }
}