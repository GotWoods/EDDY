using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("BSD")]
public class BSD_BreakdownStructureDescription : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string Level { get; set; }

	[Position(05)]
	public string ReferenceNumber2 { get; set; }

	[Position(06)]
	public string BreakdownStructureDetailCode { get; set; }

	[Position(07)]
	public string Level2 { get; set; }

	[Position(08)]
	public string SecurityLevelCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BSD_BreakdownStructureDescription>(this);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.AtLeastOneIsRequired(x=>x.ReferenceNumber, x=>x.Description);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Level, 1, 3);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.BreakdownStructureDetailCode, 2);
		validator.Length(x => x.Level2, 1, 3);
		validator.Length(x => x.SecurityLevelCode, 2);
		return validator.Results;
	}
}
