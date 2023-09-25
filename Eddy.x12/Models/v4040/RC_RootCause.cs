using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4040;

[Segment("RC")]
public class RC_RootCause : EdiX12Segment
{
	[Position(01)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(02)]
	public string ProductServiceID { get; set; }

	[Position(03)]
	public string Name { get; set; }

	[Position(04)]
	public string AgencyQualifierCode { get; set; }

	[Position(05)]
	public string SourceSubqualifier { get; set; }

	[Position(06)]
	public string CausalPartConditionCode { get; set; }

	[Position(07)]
	public string Description { get; set; }

	[Position(08)]
	public string FreeFormMessageText { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RC_RootCause>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.ARequiresB(x=>x.AgencyQualifierCode, x=>x.CausalPartConditionCode);
		validator.ARequiresB(x=>x.SourceSubqualifier, x=>x.AgencyQualifierCode);
		validator.AtLeastOneIsRequired(x=>x.CausalPartConditionCode, x=>x.Description);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 48);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		validator.Length(x => x.CausalPartConditionCode, 1, 3);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
