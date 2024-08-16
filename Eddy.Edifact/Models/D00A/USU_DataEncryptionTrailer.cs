using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("USU")]
public class USU_DataEncryptionTrailer : EdifactSegment
{
	[Position(1)]
	public string LengthOfDataInOctetsOfBits { get; set; }

	[Position(2)]
	public string EncryptionReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<USU_DataEncryptionTrailer>(this);
		validator.Required(x=>x.LengthOfDataInOctetsOfBits);
		validator.Length(x => x.LengthOfDataInOctetsOfBits, 1, 18);
		validator.Length(x => x.EncryptionReferenceNumber, 1, 35);
		return validator.Results;
	}
}
