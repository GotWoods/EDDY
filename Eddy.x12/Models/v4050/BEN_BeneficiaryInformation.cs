using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("BEN")]
public class BEN_BeneficiaryOrOwnerInformation : EdiX12Segment
{
	[Position(01)]
	public string PrimaryOrContingentCode { get; set; }

	[Position(02)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(03)]
	public string IndividualRelationshipCode { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(06)]
	public string TypeOfAccountCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BEN_BeneficiaryOrOwnerInformation>(this);
		validator.Length(x => x.PrimaryOrContingentCode, 1);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.IndividualRelationshipCode, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.TypeOfAccountCode, 2);
		return validator.Results;
	}
}
