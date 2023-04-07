using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models
{
    [Segment("G62")]
    public class G62_DateTime : EdiX12Segment
    {
        [Position(01)]
        public string DateQualifier { get; set; }

        [Position(02)]
        public string Date { get; set; }

        [Position(03)]
        public string TimeQualifier { get; set; }

        [Position(04)]
        public string Time { get; set; }

        [Position(05)]
        public string TimeCode { get; set; }

        public override ValidationResult Validate()
        {
            var validator = new BasicValidator<G62_DateTime>(this);
            validator.RequiredAorB(x => x.DateQualifier, x => x.TimeQualifier);
            validator.ARequiresB(x => x.DateQualifier, x => x.Date);
            validator.ARequiresB(x => x.TimeQualifier, x => x.Time);



            validator.Length(x => x.DateQualifier, 2);
            validator.Length(x => x.Date, 8);
            validator.Length(x => x.TimeQualifier, 1, 2);
            validator.Length(x => x.Time, 4, 8);
            validator.Length(x => x.TimeCode, 2);
            return validator.Results;
        }


        public DateTime GetDateTime()
        {
            //TODO: parse timezone
            var format = "yyyyMMddHHmm";
            var dateAndTime = Date + Time;

            if (dateAndTime.Length == 16)
            {
                format = "yyyyMMddHHmmssff";
                //dates.IncludeSecondsInDateTime = true;
                //dates.IncludeMillisecondsInDateTime = true;
            }

            if (dateAndTime.Length == 14)
            {
                format = "yyyyMMddHHmmss";
                //dates.IncludeSecondsInDateTime = true;
            }
            if (dateAndTime.Length == 8) //just date only
            {
                format = "yyyyMMdd";
                //dates.IncludeTime = false;
            }

            return DateTime.ParseExact(dateAndTime, format, CultureInfo.InvariantCulture);
            //dates.TimeCode = input.TimeCode;
        }

    }

}
