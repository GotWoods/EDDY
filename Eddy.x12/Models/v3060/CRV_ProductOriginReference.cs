using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("CRV")]
public class CRV_ProductOriginReference : EdiX12Segment
{
	[Position(01)]
	public string NetCostCode { get; set; }

	[Position(02)]
	public string Amount { get; set; }

	[Position(03)]
	public string CountryCode { get; set; }

	[Position(04)]
	public string ProductProcessCharacteristicCode { get; set; }

	[Position(05)]
	public int? Percent { get; set; }

	[Position(06)]
	public string CertificationClauseCode { get; set; }

	[Position(07)]
	public string PreferentialDutyCriteriaCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CRV_ProductOriginReference>(this);
		validator.ARequiresB(x=>x.ProductProcessCharacteristicCode, x=>x.CertificationClauseCode);
		validator.Length(x => x.NetCostCode, 1, 2);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.ProductProcessCharacteristicCode, 2, 3);
		validator.Length(x => x.Percent, 1, 3);
		validator.Length(x => x.CertificationClauseCode, 2, 4);
		validator.Length(x => x.PreferentialDutyCriteriaCode, 1, 2);
		return validator.Results;
	}
}
