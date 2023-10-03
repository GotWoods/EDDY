using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020.Composites;

[Segment("C032")]
public class C032_EncryptionServiceInformation : EdiX12Component
{
	[Position(00)]
	public string EncryptionServiceCode { get; set; }

	[Position(01)]
	public string AlgorithmID { get; set; }

	[Position(02)]
	public string AlgorithmModeOfOperation { get; set; }

	[Position(03)]
	public string FilterIDCode { get; set; }

	[Position(04)]
	public string VersionIdentifier { get; set; }

	[Position(05)]
	public string CompressionID { get; set; }

	[Position(06)]
	public string VersionIdentifier2 { get; set; }

	[Position(07)]
	public string LengthOfInitializationVector { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C032_EncryptionServiceInformation>(this);
		validator.Required(x=>x.EncryptionServiceCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.FilterIDCode, x=>x.VersionIdentifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CompressionID, x=>x.VersionIdentifier2);
		validator.Length(x => x.EncryptionServiceCode, 1, 3);
		validator.Length(x => x.AlgorithmID, 3);
		validator.Length(x => x.AlgorithmModeOfOperation, 3);
		validator.Length(x => x.FilterIDCode, 3);
		validator.Length(x => x.VersionIdentifier, 1, 30);
		validator.Length(x => x.CompressionID, 3);
		validator.Length(x => x.VersionIdentifier2, 1, 30);
		validator.Length(x => x.LengthOfInitializationVector, 1, 3);
		return validator.Results;
	}
}
