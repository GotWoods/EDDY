using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("FNS")]
public class FNS_FootnoteSet : EdifactSegment
{
	[Position(1)]
	public C783_FootnoteSetIdentification FootnoteSetIdentification { get; set; }

	[Position(2)]
	public C082_PartyIdentificationDetails PartyIdentificationDetails { get; set; }

	[Position(3)]
	public string StatusCoded { get; set; }

	[Position(4)]
	public string MaintenanceOperationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FNS_FootnoteSet>(this);
		validator.Required(x=>x.FootnoteSetIdentification);
		validator.Length(x => x.StatusCoded, 1, 3);
		validator.Length(x => x.MaintenanceOperationCoded, 1, 3);
		return validator.Results;
	}
}