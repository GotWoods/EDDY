using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("FH")]
public class FH_FamilyHistory : EdiX12Segment
{
	[Position(01)]
	public string IndividualRelationshipCode { get; set; }

	[Position(02)]
	public string QuantityQualifier { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public string CurrentHealthConditionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FH_FamilyHistory>(this);
		validator.Required(x=>x.IndividualRelationshipCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.QuantityQualifier, x=>x.Quantity);
		validator.Length(x => x.IndividualRelationshipCode, 2);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.CurrentHealthConditionCode, 1);
		return validator.Results;
	}
}
