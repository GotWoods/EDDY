using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("USD")]
public class USD_DataEncryptionHeader : EdifactSegment
{
	[Position(1)]
	public string LengthOfDataInOctetsOfBits { get; set; }

	[Position(2)]
	public string EncryptionReferenceNumber { get; set; }

	[Position(3)]
	public string NumberOfPaddingBytes { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<USD_DataEncryptionHeader>(this);
		validator.Required(x=>x.LengthOfDataInOctetsOfBits);
		validator.Length(x => x.LengthOfDataInOctetsOfBits, 1, 18);
		validator.Length(x => x.EncryptionReferenceNumber, 1, 35);
		validator.Length(x => x.NumberOfPaddingBytes, 1, 2);
		return validator.Results;
	}
}
