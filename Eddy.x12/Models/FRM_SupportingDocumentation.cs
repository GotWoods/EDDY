using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("FRM")]
public class FRM_SupportingDocumentation : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public decimal? PercentDecimalFormat { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FRM_SupportingDocumentation>(this);
		validator.Required(x=>x.AssignedIdentification);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.PercentDecimalFormat, 1, 6);
		return validator.Results;
	}
}
