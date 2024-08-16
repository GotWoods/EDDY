using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("UCM")]
public class UCM_MessagePackageResponse : EdifactSegment
{
	[Position(1)]
	public string MessageReferenceNumber { get; set; }

	[Position(2)]
	public S009_MessageIdentifier MessageIdentifier { get; set; }

	[Position(3)]
	public string ActionCoded { get; set; }

	[Position(4)]
	public string SyntaxErrorCoded { get; set; }

	[Position(5)]
	public string ServiceSegmentTagCoded { get; set; }

	[Position(6)]
	public S011_DataElementIdentification DataElementIdentification { get; set; }

	[Position(7)]
	public string PackageReferenceNumber { get; set; }

	[Position(8)]
	public S020_ReferenceIdentification ReferenceIdentification { get; set; }

	[Position(9)]
	public string SecurityReferenceNumber { get; set; }

	[Position(10)]
	public string SecuritySegmentPosition { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UCM_MessagePackageResponse>(this);
		validator.Required(x=>x.ActionCoded);
		validator.Length(x => x.MessageReferenceNumber, 1, 14);
		validator.Length(x => x.ActionCoded, 1, 3);
		validator.Length(x => x.SyntaxErrorCoded, 1, 3);
		validator.Length(x => x.ServiceSegmentTagCoded, 1, 3);
		validator.Length(x => x.PackageReferenceNumber, 1, 35);
		validator.Length(x => x.SecurityReferenceNumber, 1, 14);
		validator.Length(x => x.SecuritySegmentPosition, 1, 6);
		return validator.Results;
	}
}
