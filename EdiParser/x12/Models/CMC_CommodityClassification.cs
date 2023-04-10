using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("CMC")]
public class CMC_CommodityClassification : EdiX12Segment
{
	[Position(01)]
	public string CommodityCode { get; set; }

	[Position(02)]
	public string FreightClassCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CMC_CommodityClassification>(this);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.FreightClassCode, 2, 5);
		return validator.Results;
	}
}