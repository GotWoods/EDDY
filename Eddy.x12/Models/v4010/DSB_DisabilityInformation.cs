using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("DSB")]
public class DSB_DisabilityInformation : EdiX12Segment
{
	[Position(01)]
	public string DisabilityTypeCode { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string OccupationCode { get; set; }

	[Position(04)]
	public string WorkIntensityCode { get; set; }

	[Position(05)]
	public string ProductOptionCode { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount { get; set; }

	[Position(07)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(08)]
	public string MedicalCodeValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DSB_DisabilityInformation>(this);
		validator.Required(x=>x.DisabilityTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.MedicalCodeValue);
		validator.Length(x => x.DisabilityTypeCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.OccupationCode, 4, 6);
		validator.Length(x => x.WorkIntensityCode, 1);
		validator.Length(x => x.ProductOptionCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.MedicalCodeValue, 1, 15);
		return validator.Results;
	}
}
