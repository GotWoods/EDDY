using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("DOC")]
public class DOC_DocumentMessageDetails : EdifactSegment
{
	[Position(1)]
	public C002_DocumentMessageName DocumentMessageName { get; set; }

	[Position(2)]
	public C503_DocumentMessageDetails DocumentMessageDetails { get; set; }

	[Position(3)]
	public string CommunicationChannelIdentifierCoded { get; set; }

	[Position(4)]
	public string NumberOfCopiesOfDocumentRequired { get; set; }

	[Position(5)]
	public string NumberOfOriginalsOfDocumentRequired { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DOC_DocumentMessageDetails>(this);
		validator.Required(x=>x.DocumentMessageName);
		validator.Length(x => x.CommunicationChannelIdentifierCoded, 1, 3);
		validator.Length(x => x.NumberOfCopiesOfDocumentRequired, 1, 2);
		validator.Length(x => x.NumberOfOriginalsOfDocumentRequired, 1, 2);
		return validator.Results;
	}
}
