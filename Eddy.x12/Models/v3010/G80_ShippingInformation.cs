using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G80")]
public class G80_ShippingInformation : EdiX12Segment
{
	[Position(01)]
	public string StoreNumber { get; set; }

	[Position(02)]
	public string EquipmentNumber { get; set; }

	[Position(03)]
	public int? StopSequenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G80_ShippingInformation>(this);
		validator.Length(x => x.StoreNumber, 1, 10);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.StopSequenceNumber, 1, 2);
		return validator.Results;
	}
}
