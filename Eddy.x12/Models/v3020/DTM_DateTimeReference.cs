using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("DTM")]
public class DTM_DateTimeReference : EdiX12Segment
{
	[Position(01)]
	public string DateTimeQualifier { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Time { get; set; }

	[Position(04)]
	public string TimeCode { get; set; }

	[Position(05)]
	public int? Century { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DTM_DateTimeReference>(this);
		validator.Required(x=>x.DateTimeQualifier);
		validator.AtLeastOneIsRequired(x=>x.Date, x=>x.Time);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 6);
		validator.Length(x => x.TimeCode, 2);
		validator.Length(x => x.Century, 2);
		return validator.Results;
	}
}
