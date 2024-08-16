using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("DOC")]
public class DOC_DocumentMessageDetails : EdifactSegment
{
	[Position(1)]
	public C002_DocumentMessageName DocumentMessageName { get; set; }

	[Position(2)]
	public C503_DocumentMessageDetails DocumentMessageDetails { get; set; }

	[Position(3)]
	public string CommunicationMediumTypeCode { get; set; }

	[Position(4)]
	public string DocumentCopiesRequiredQuantity { get; set; }

	[Position(5)]
	public string DocumentOriginalsRequiredQuantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DOC_DocumentMessageDetails>(this);
		validator.Required(x=>x.DocumentMessageName);
		validator.Length(x => x.CommunicationMediumTypeCode, 1, 3);
		validator.Length(x => x.DocumentCopiesRequiredQuantity, 1, 2);
		validator.Length(x => x.DocumentOriginalsRequiredQuantity, 1, 2);
		return validator.Results;
	}
}
