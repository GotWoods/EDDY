using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("N21")]
public class N21_EquipmentRegistrationDetails : EdiX12Segment
{
	[Position(01)]
	public string EquipmentInitial { get; set; }

	[Position(02)]
	public string EquipmentNumber { get; set; }

	[Position(03)]
	public string EquipmentNumber2 { get; set; }

	[Position(04)]
	public decimal? Weight { get; set; }

	[Position(05)]
	public string WeightUnitCode { get; set; }

	[Position(06)]
	public int? TareWeight { get; set; }

	[Position(07)]
	public string WeightUnitCode2 { get; set; }

	[Position(08)]
	public string TareQualifierCode { get; set; }

	[Position(09)]
	public decimal? Volume { get; set; }

	[Position(10)]
	public string VolumeUnitQualifier { get; set; }

	[Position(11)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(12)]
	public string OwnershipCode { get; set; }

	[Position(13)]
	public int? EquipmentLength { get; set; }

	[Position(14)]
	public decimal? Height { get; set; }

	[Position(15)]
	public decimal? Width { get; set; }

	[Position(16)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(17)]
	public string EquipmentTypeCode { get; set; }

	[Position(18)]
	public string CarTypeCode { get; set; }

	[Position(19)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(20)]
	public int? EquipmentNumberCheckDigit { get; set; }

	[Position(21)]
	public string LocationOnEquipmentCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N21_EquipmentRegistrationDetails>(this);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Weight, x=>x.WeightUnitCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TareWeight, x=>x.WeightUnitCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Volume, x=>x.VolumeUnitQualifier);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 15);
		validator.Length(x => x.EquipmentNumber2, 1, 15);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.TareWeight, 3, 8);
		validator.Length(x => x.WeightUnitCode2, 1);
		validator.Length(x => x.TareQualifierCode, 1);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.OwnershipCode, 1);
		validator.Length(x => x.EquipmentLength, 4, 5);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.EquipmentTypeCode, 4);
		validator.Length(x => x.CarTypeCode, 1, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.EquipmentNumberCheckDigit, 1);
		validator.Length(x => x.LocationOnEquipmentCode, 1, 3);
		return validator.Results;
	}
}
