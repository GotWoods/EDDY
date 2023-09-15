using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4040;

[Segment("G5")]
public class G5_WeightInformation : EdiX12Segment
{
	[Position(01)]
	public string EquipmentInitial { get; set; }

	[Position(02)]
	public string EquipmentNumber { get; set; }

	[Position(03)]
	public int? WaybillNumber { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public decimal? Weight { get; set; }

	[Position(06)]
	public string WeightQualifier { get; set; }

	[Position(07)]
	public int? TareWeight { get; set; }

	[Position(08)]
	public string TareQualifierCode { get; set; }

	[Position(09)]
	public int? WeightAllowance { get; set; }

	[Position(10)]
	public string WeightAllowanceTypeCode { get; set; }

	[Position(11)]
	public decimal? FreightRate { get; set; }

	[Position(12)]
	public string RateValueQualifier { get; set; }

	[Position(13)]
	public string InterchangeTrainIdentification { get; set; }

	[Position(14)]
	public string CommodityCode { get; set; }

	[Position(15)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(16)]
	public string ReferenceIdentification { get; set; }

	[Position(17)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G5_WeightInformation>(this);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WaybillNumber, x=>x.Date);
		validator.Required(x=>x.Weight);
		validator.Required(x=>x.WeightQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TareWeight, x=>x.TareQualifierCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightAllowance, x=>x.WeightAllowanceTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.FreightRate, x=>x.RateValueQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 15);
		validator.Length(x => x.WaybillNumber, 1, 6);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.TareWeight, 3, 8);
		validator.Length(x => x.TareQualifierCode, 1);
		validator.Length(x => x.WeightAllowance, 2, 6);
		validator.Length(x => x.WeightAllowanceTypeCode, 1);
		validator.Length(x => x.FreightRate, 1, 9);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.InterchangeTrainIdentification, 1, 10);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.Date2, 8);
		return validator.Results;
	}
}
