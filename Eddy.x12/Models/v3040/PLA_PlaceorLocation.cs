using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("PLA")]
public class PLA_PlaceOrLocation : EdiX12Segment
{
	[Position(01)]
	public string ActionCode { get; set; }

	[Position(02)]
	public string EntityIdentifierCode { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string Time { get; set; }

	[Position(05)]
	public string MaintenanceReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PLA_PlaceOrLocation>(this);
		validator.Required(x=>x.ActionCode);
		validator.Required(x=>x.EntityIdentifierCode);
		validator.Required(x=>x.Date);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.EntityIdentifierCode, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.MaintenanceReasonCode, 2, 3);
		return validator.Results;
	}
}
