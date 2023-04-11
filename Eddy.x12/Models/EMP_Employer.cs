using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("EMP")]
public class EMP_Employer : EdiX12Segment
{
	[Position(01)]
	public string Description { get; set; }

	[Position(02)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(03)]
	public string ProductServiceID { get; set; }

	[Position(04)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(05)]
	public string ReferenceIdentification { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(07)]
	public string Description2 { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(10)]
	public string ReferenceIdentification2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EMP_Employer>(this);
		validator.Required(x=>x.Description);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		return validator.Results;
	}
}
