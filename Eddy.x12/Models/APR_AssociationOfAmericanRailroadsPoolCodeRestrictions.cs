using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("APR")]
public class APR_AssociationOfAmericanRailroadsPoolCodeRestrictions : EdiX12Segment 
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string AssociationOfAmericanRailroadsAARPoolCode { get; set; }

	[Position(03)]
	public string AssociationOfAmericanRailroadsAARPoolCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<APR_AssociationOfAmericanRailroadsPoolCodeRestrictions>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Required(x=>x.AssociationOfAmericanRailroadsAARPoolCode);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.AssociationOfAmericanRailroadsAARPoolCode, 7);
		validator.Length(x => x.AssociationOfAmericanRailroadsAARPoolCode2, 7);
		return validator.Results;
	}
}
