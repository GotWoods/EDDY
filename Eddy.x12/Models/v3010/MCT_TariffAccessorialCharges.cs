using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("MCT")]
public class MCT_TariffAccessorialCharges : EdiX12Segment
{
	[Position(01)]
	public string SpecialChargeCode { get; set; }

	[Position(02)]
	public string TariffValueCode { get; set; }

	[Position(03)]
	public decimal? RangeMinimum { get; set; }

	[Position(04)]
	public decimal? RangeMaximum { get; set; }

	[Position(05)]
	public string RateValueQualifier { get; set; }

	[Position(06)]
	public decimal? SpecialCharge { get; set; }

	[Position(07)]
	public string TariffReferenceFlag { get; set; }

	[Position(08)]
	public string SpecialChargeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MCT_TariffAccessorialCharges>(this);
		validator.Required(x=>x.SpecialChargeCode);
		validator.Length(x => x.SpecialChargeCode, 3);
		validator.Length(x => x.TariffValueCode, 2);
		validator.Length(x => x.RangeMinimum, 1, 10);
		validator.Length(x => x.RangeMaximum, 1, 10);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.SpecialCharge, 1, 7);
		validator.Length(x => x.TariffReferenceFlag, 1);
		validator.Length(x => x.SpecialChargeDescription, 2, 25);
		return validator.Results;
	}
}
