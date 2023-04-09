using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

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

	[Position(13)]
	public string Date { get; set; }

	[Position(14)]
	public string InterchangeTrainIdentification2 { get; set; }

	[Position(15)]
	public int? Number { get; set; }

	[Position(16)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BTS_BeginningSegmentForTrainSheets>(this);
		validator.Required(x=>x.InterchangeTrainIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TotalEquipment, x=>x.EquipmentStatusCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TotalEquipment2, x=>x.EquipmentStatusCode2);
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
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.InterchangeTrainIdentification2, 1, 10);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.Date2, 8);
		return validator.Results;
	}
}
