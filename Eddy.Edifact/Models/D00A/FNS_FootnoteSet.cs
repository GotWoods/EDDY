using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("FNS")]
public class FNS_FootnoteSet : EdifactSegment
{
	[Position(1)]
	public C783_FootnoteSetIdentification FootnoteSetIdentification { get; set; }

	[Position(2)]
	public C082_PartyIdentificationDetails PartyIdentificationDetails { get; set; }

	[Position(3)]
	public string StatusDescriptionCode { get; set; }

	[Position(4)]
	public string MaintenanceOperationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FNS_FootnoteSet>(this);
		validator.Required(x=>x.FootnoteSetIdentification);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		validator.Length(x => x.MaintenanceOperationCode, 1, 3);
		return validator.Results;
	}
}
