using System;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

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

    public DateTime GetDateTime()
    {
        return x12DateTimeParser.Parse(Date, Time, SupportedDateFormats.SixDigit, SupportedTimeFormats.FourDigit);
    }
	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G62_DateTime>(this);
		validator.Length(x => x.DateQualifier, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.TimeQualifier, 1);
		validator.Length(x => x.Time, 4);
		validator.Length(x => x.TimeCode, 2);
		return validator.Results;
	}
}
