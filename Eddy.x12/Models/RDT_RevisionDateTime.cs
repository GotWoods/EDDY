using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("RDT")]
public class RDT_RevisionDateTime : EdiX12Segment
{
	[Position(01)]
	public string RevisionLevelCode { get; set; }

	[Position(02)]
	public string RevisionValue { get; set; }

	[Position(03)]
	public string DateTimeQualifier { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string Time { get; set; }

	[Position(06)]
	public string TimeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RDT_RevisionDateTime>(this);
		validator.ARequiresB(x=>x.RevisionLevelCode, x=>x.RevisionValue);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DateTimeQualifier, x=>x.Date, x=>x.Time);
		validator.ARequiresB(x=>x.TimeCode, x=>x.Time);
		validator.Length(x => x.RevisionLevelCode, 1);
		validator.Length(x => x.RevisionValue, 1, 30);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.TimeCode, 2);
		return validator.Results;
	}
}
