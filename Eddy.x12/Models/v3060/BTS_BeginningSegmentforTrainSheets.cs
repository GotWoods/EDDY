using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("BTS")]
public class BTS_BeginningSegmentForTrainSheets : EdiX12Segment
{
	[Position(01)]
	public string InterchangeTrainIdentification { get; set; }

	[Position(02)]
	public int? TotalEquipment { get; set; }

	[Position(03)]
	public string EquipmentStatusCode { get; set; }

	[Position(04)]
	public int? TotalEquipment2 { get; set; }

	[Position(05)]
	public string EquipmentStatusCode2 { get; set; }

	[Position(06)]
	public decimal? Weight { get; set; }

	[Position(07)]
	public decimal? Length { get; set; }

	[Position(08)]
	public int? Horsepower { get; set; }

	[Position(09)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(10)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(11)]
	public string ServiceLevelCode { get; set; }

	[Position(12)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BTS_BeginningSegmentForTrainSheets>(this);
		validator.Required(x=>x.InterchangeTrainIdentification);
		validator.Required(x=>x.TotalEquipment);
		validator.Required(x=>x.EquipmentStatusCode);
		validator.Required(x=>x.TotalEquipment2);
		validator.Required(x=>x.EquipmentStatusCode2);
		validator.Required(x=>x.Weight);
		validator.Required(x=>x.Length);
		validator.Required(x=>x.Horsepower);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Length(x => x.InterchangeTrainIdentification, 1, 10);
		validator.Length(x => x.TotalEquipment, 1, 3);
		validator.Length(x => x.EquipmentStatusCode, 1, 2);
		validator.Length(x => x.TotalEquipment2, 1, 3);
		validator.Length(x => x.EquipmentStatusCode2, 1, 2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.Horsepower, 1, 16);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ServiceLevelCode, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
