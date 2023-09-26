using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("TRL")]
public class TRL_EquipmentUsageInformation : EdiX12Segment
{
	[Position(01)]
	public string EquipmentStatusCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Time { get; set; }

	[Position(04)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(05)]
	public string RejectReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TRL_EquipmentUsageInformation>(this);
		validator.Required(x=>x.EquipmentStatusCode);
		validator.ARequiresB(x=>x.Time, x=>x.Date);
		validator.Length(x => x.EquipmentStatusCode, 1, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.RejectReasonCode, 2);
		return validator.Results;
	}
}
