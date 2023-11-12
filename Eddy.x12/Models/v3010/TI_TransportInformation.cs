using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("TI")]
public class TI_TransportInformation : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(03)]
	public string EquipmentInitial { get; set; }

	[Position(04)]
	public string EquipmentNumber { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string SealStatusCode { get; set; }

	[Position(07)]
	public string CarTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TI_TransportInformation>(this);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.SealStatusCode, 2);
		validator.Length(x => x.CarTypeCode, 4);
		return validator.Results;
	}
}
