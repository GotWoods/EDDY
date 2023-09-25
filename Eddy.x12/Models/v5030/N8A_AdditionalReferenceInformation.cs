using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("N8A")]
public class N8A_AdditionalReferenceInformation : EdiX12Segment
{
	[Position(01)]
	public string WaybillCrossReferenceCode { get; set; }

	[Position(02)]
	public int? WaybillNumber { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public string CityName { get; set; }

	[Position(06)]
	public string StateOrProvinceCode { get; set; }

	[Position(07)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(08)]
	public string FreightStationAccountingCode { get; set; }

	[Position(09)]
	public string EquipmentInitial { get; set; }

	[Position(10)]
	public string EquipmentNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N8A_AdditionalReferenceInformation>(this);
		validator.Length(x => x.WaybillCrossReferenceCode, 2);
		validator.Length(x => x.WaybillNumber, 1, 6);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.FreightStationAccountingCode, 1, 5);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 15);
		return validator.Results;
	}
}
