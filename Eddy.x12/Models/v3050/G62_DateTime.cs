using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;
using System;

namespace Eddy.x12.Models.v3050;

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

	[Position(06)]
	public int? Century { get; set; }

    public DateTime GetDateTime()
    {
        var centuryAsString = "";
        if (Century.HasValue)
        {
            if (Century.Value < 10 || Century.Value >= 100)
                throw new InvalidOperationException("Invalid century. Expected a 2 digit century but got " + Century.Value);
            centuryAsString = Century.ToString();
        }

        return x12DateTimeParser.Parse(centuryAsString + Date, Time, SupportedDateFormats.All, SupportedTimeFormats.All);
    }

    public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G62_DateTime>(this);
		validator.AtLeastOneIsRequired(x=>x.DateQualifier, x=>x.TimeQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateQualifier, x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TimeQualifier, x=>x.Time);
		validator.Length(x => x.DateQualifier, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.TimeQualifier, 1, 2);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.TimeCode, 2);
		validator.Length(x => x.Century, 2);
		return validator.Results;
	}
}
