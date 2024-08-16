using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("UNP")]
public class UNP_ObjectTrailer : EdifactSegment
{
	[Position(1)]
	public string LengthOfObjectInOctetsOfBits { get; set; }

	[Position(2)]
	public string PackageReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UNP_ObjectTrailer>(this);
		validator.Required(x=>x.LengthOfObjectInOctetsOfBits);
		validator.Required(x=>x.PackageReferenceNumber);
		validator.Length(x => x.LengthOfObjectInOctetsOfBits, 1, 18);
		validator.Length(x => x.PackageReferenceNumber, 1, 35);
		return validator.Results;
	}
}
