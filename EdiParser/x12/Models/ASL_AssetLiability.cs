using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("ASL")]
public class ASL_AssetLiability : EdiX12Segment 
{
	[Position(01)]
	public string AmountQualifierCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string AssetLiabilityTypeCode { get; set; }

	[Position(04)]
	public string FrequencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ASL_AssetLiability>(this);
		validator.Required(x=>x.AmountQualifierCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.AssetLiabilityTypeCode, 2);
		validator.Length(x => x.FrequencyCode, 1);
		return validator.Results;
	}
}
