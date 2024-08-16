using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("UNO")]
public class UNO_ObjectHeader : EdifactSegment
{
	[Position(1)]
	public string PackageReferenceNumber { get; set; }

	[Position(2)]
	public S020_ReferenceIdentification ReferenceIdentification { get; set; }

	[Position(3)]
	public S021_ObjectTypeIdentification ObjectTypeIdentification { get; set; }

	[Position(4)]
	public S022_StatusOfTheObject StatusOfTheObject { get; set; }

	[Position(5)]
	public S302_DialogueReference DialogueReference { get; set; }

	[Position(6)]
	public S301_StatusOfTransferInteractive StatusOfTransferInteractive { get; set; }

	[Position(7)]
	public S300_DateAndOrTimeOfInitiation DateAndOrTimeOfInitiation { get; set; }

	[Position(8)]
	public string TestIndicator { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UNO_ObjectHeader>(this);
		validator.Required(x=>x.PackageReferenceNumber);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.ObjectTypeIdentification);
		validator.Required(x=>x.StatusOfTheObject);
		validator.Length(x => x.PackageReferenceNumber, 1, 35);
		validator.Length(x => x.TestIndicator, 1);
		return validator.Results;
	}
}
