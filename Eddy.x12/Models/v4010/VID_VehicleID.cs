using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("VID")]
public class VID_ConveyanceIdentification : EdiX12Segment
{
	[Position(01)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(02)]
	public string EquipmentInitial { get; set; }

	[Position(03)]
	public string EquipmentNumber { get; set; }

	[Position(04)]
	public string SealNumber { get; set; }

	[Position(05)]
	public string SealNumber2 { get; set; }

	[Position(06)]
	public int? EquipmentLength { get; set; }

	[Position(07)]
	public decimal? Height { get; set; }

	[Position(08)]
	public decimal? Width { get; set; }

	[Position(09)]
	public string EquipmentType { get; set; }

	[Position(10)]
	public string LoadEmptyStatusCode { get; set; }

	[Position(11)]
	public string TypeOfServiceCode { get; set; }

	[Position(12)]
	public string LocationIdentifier { get; set; }

	[Position(13)]
	public string StandardCarrierAlphaCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<VID_ConveyanceIdentification>(this);
		validator.Required(x=>x.EquipmentDescriptionCode);
		validator.Required(x=>x.EquipmentNumber);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.SealNumber, 2, 15);
		validator.Length(x => x.SealNumber2, 2, 15);
		validator.Length(x => x.EquipmentLength, 4, 5);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.EquipmentType, 4);
		validator.Length(x => x.LoadEmptyStatusCode, 1);
		validator.Length(x => x.TypeOfServiceCode, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		return validator.Results;
	}
}
