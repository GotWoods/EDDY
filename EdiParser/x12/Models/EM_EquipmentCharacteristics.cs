using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("EM")]
public class EM_EquipmentCharacteristics : EdiX12Segment
{
	[Position(01)]
	public string WeightUnitCode { get; set; }

	[Position(02)]
	public decimal? Weight { get; set; }

	[Position(03)]
	public string VolumeUnitQualifier { get; set; }

	[Position(04)]
	public decimal? Volume { get; set; }

	[Position(05)]
	public string CountryCode { get; set; }

	[Position(06)]
	public string ConstructionTypeCode { get; set; }

	[Position(07)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EM_EquipmentCharacteristics>(this);
		validator.ARequiresB(x=>x.Weight, x=>x.WeightUnitCode);
		validator.ARequiresB(x=>x.Volume, x=>x.VolumeUnitQualifier);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.ConstructionTypeCode, 1, 2);
		validator.Length(x => x.Date, 8);
		return validator.Results;
	}
}
