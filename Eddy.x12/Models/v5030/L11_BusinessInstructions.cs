using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("L11")]
public class L11_BusinessInstructionsAndReferenceNumber : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<L11_BusinessInstructionsAndReferenceNumber>(this);
		validator.AtLeastOneIsRequired(x=>x.ReferenceIdentification, x=>x.Description);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentification, x=>x.ReferenceIdentificationQualifier);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
