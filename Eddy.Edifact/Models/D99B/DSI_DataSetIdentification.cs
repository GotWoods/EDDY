using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("DSI")]
public class DSI_DataSetIdentification : EdifactSegment
{
	[Position(1)]
	public C782_DataSetIdentification DataSetIdentification { get; set; }

	[Position(2)]
	public C082_PartyIdentificationDetails PartyIdentificationDetails { get; set; }

	[Position(3)]
	public string StatusDescriptionCode { get; set; }

	[Position(4)]
	public C286_SequenceInformation SequenceInformation { get; set; }

	[Position(5)]
	public string RevisionNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DSI_DataSetIdentification>(this);
		validator.Required(x=>x.DataSetIdentification);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		validator.Length(x => x.RevisionNumber, 1, 6);
		return validator.Results;
	}
}
