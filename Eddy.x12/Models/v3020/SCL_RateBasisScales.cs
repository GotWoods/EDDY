using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("SCL")]
public class SCL_RateBasisScales : EdiX12Segment
{
	[Position(01)]
	public string RateBasisQualifier { get; set; }

	[Position(02)]
	public string RateBasisNumber { get; set; }

	[Position(03)]
	public string RateBasisNumber2 { get; set; }

	[Position(04)]
	public string LocationQualifier { get; set; }

	[Position(05)]
	public string LocationIdentifier { get; set; }

	[Position(06)]
	public string LocationIdentifier2 { get; set; }

	[Position(07)]
	public string StateOrProvinceCode { get; set; }

	[Position(08)]
	public string TariffAddOnFactor { get; set; }

	[Position(09)]
	public string TariffClassAdjustmentReference { get; set; }

	[Position(10)]
	public string TariffClassAdjustmentReference2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SCL_RateBasisScales>(this);
		validator.Required(x=>x.RateBasisQualifier);
		validator.ARequiresB(x=>x.RateBasisNumber2, x=>x.RateBasisNumber);
		validator.AtLeastOneIsRequired(x=>x.LocationQualifier, x=>x.LocationIdentifier);
		validator.ARequiresB(x=>x.LocationIdentifier2, x=>x.LocationIdentifier);
		validator.Length(x => x.RateBasisQualifier, 1);
		validator.Length(x => x.RateBasisNumber, 1, 6);
		validator.Length(x => x.RateBasisNumber2, 1, 6);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 25);
		validator.Length(x => x.LocationIdentifier2, 1, 25);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.TariffAddOnFactor, 1, 6);
		validator.Length(x => x.TariffClassAdjustmentReference, 1, 6);
		validator.Length(x => x.TariffClassAdjustmentReference2, 1, 6);
		return validator.Results;
	}
}
