using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("FNT")]
public class FNT_Footnote : EdifactSegment
{
	[Position(1)]
	public C784_FootnoteIdentification FootnoteIdentification { get; set; }

	[Position(2)]
	public C082_PartyIdentificationDetails PartyIdentificationDetails { get; set; }

	[Position(3)]
	public string StatusDescriptionCode { get; set; }

	[Position(4)]
	public string MaintenanceOperationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FNT_Footnote>(this);
		validator.Required(x=>x.FootnoteIdentification);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		validator.Length(x => x.MaintenanceOperationCoded, 1, 3);
		return validator.Results;
	}
}
