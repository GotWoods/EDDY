using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("W2A")]
public class W2A_EquipmentInformation : EdiX12Segment
{
	[Position(01)]
	public string EquipmentStatusCode { get; set; }

	[Position(02)]
	public string EquipmentInitial { get; set; }

	[Position(03)]
	public string EquipmentNumber { get; set; }

	[Position(04)]
	public int? EquipmentNumberCheckDigit { get; set; }

	[Position(05)]
	public decimal? Weight { get; set; }

	[Position(06)]
	public string WeightQualifier { get; set; }

	[Position(07)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(08)]
	public int? EquipmentLength { get; set; }

	[Position(09)]
	public decimal? Height { get; set; }

	[Position(10)]
	public decimal? Width { get; set; }

	[Position(11)]
	public string EquipmentType { get; set; }

	[Position(12)]
	public string ChassisType { get; set; }

	[Position(13)]
	public string EquipmentOwnerCode { get; set; }

	[Position(14)]
	public string EquipmentOwnerCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W2A_EquipmentInformation>(this);
		validator.Required(x=>x.EquipmentStatusCode);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Weight, x=>x.WeightQualifier);
		validator.Length(x => x.EquipmentStatusCode, 1, 2);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.EquipmentNumberCheckDigit, 1);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.EquipmentLength, 4, 5);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.EquipmentType, 4);
		validator.Length(x => x.ChassisType, 2);
		validator.Length(x => x.EquipmentOwnerCode, 1, 4);
		validator.Length(x => x.EquipmentOwnerCode2, 1, 4);
		return validator.Results;
	}
}
