using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4040;

[Segment("G07")]
public class G07_CarrierInformation : EdiX12Segment
{
	[Position(01)]
	public string EquipmentInitial { get; set; }

	[Position(02)]
	public string EquipmentNumber { get; set; }

	[Position(03)]
	public string SealNumber { get; set; }

	[Position(04)]
	public string SealNumber2 { get; set; }

	[Position(05)]
	public string SealStatusCode { get; set; }

	[Position(06)]
	public decimal? Temperature { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G07_CarrierInformation>(this);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 15);
		validator.Length(x => x.SealNumber, 2, 15);
		validator.Length(x => x.SealNumber2, 2, 15);
		validator.Length(x => x.SealStatusCode, 2);
		validator.Length(x => x.Temperature, 1, 4);
		return validator.Results;
	}
}
