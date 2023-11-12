using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("BSD")]
public class BSD_BreakdownStructureDescription : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string Level { get; set; }

	[Position(05)]
	public string ReferenceIdentification2 { get; set; }

	[Position(06)]
	public string BreakdownStructureDetailCode { get; set; }

	[Position(07)]
	public string Level2 { get; set; }

	[Position(08)]
	public string SecurityLevelCode { get; set; }

	[Position(09)]
	public string CalculationOperationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BSD_BreakdownStructureDescription>(this);
		validator.Required(x=>x.ReferenceIdentificationQualifier);
		validator.AtLeastOneIsRequired(x=>x.ReferenceIdentification, x=>x.Description);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Level, 1, 3);
		validator.Length(x => x.ReferenceIdentification2, 1, 30);
		validator.Length(x => x.BreakdownStructureDetailCode, 2);
		validator.Length(x => x.Level2, 1, 3);
		validator.Length(x => x.SecurityLevelCode, 2);
		validator.Length(x => x.CalculationOperationCode, 1);
		return validator.Results;
	}
}
