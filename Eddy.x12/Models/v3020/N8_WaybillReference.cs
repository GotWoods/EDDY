using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("N8")]
public class N8_WaybillReference : EdiX12Segment
{
	[Position(01)]
	public int? WaybillNumber { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string CrossReferenceTypeCode { get; set; }

	[Position(04)]
	public string EquipmentInitial { get; set; }

	[Position(05)]
	public string EquipmentNumber { get; set; }

	[Position(06)]
	public int? WaybillNumber2 { get; set; }

	[Position(07)]
	public string Date2 { get; set; }

	[Position(08)]
	public string DestinationStation { get; set; }

	[Position(09)]
	public string StateOrProvinceCode { get; set; }

	[Position(10)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(11)]
	public string FreightStationAccountingCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N8_WaybillReference>(this);
		validator.Required(x=>x.WaybillNumber);
		validator.Required(x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WaybillNumber2, x=>x.Date2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DestinationStation, x=>x.StateOrProvinceCode);
		validator.Length(x => x.WaybillNumber, 1, 6);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.CrossReferenceTypeCode, 1);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.WaybillNumber2, 1, 6);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.DestinationStation, 2, 19);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.FreightStationAccountingCode, 1, 5);
		return validator.Results;
	}
}
