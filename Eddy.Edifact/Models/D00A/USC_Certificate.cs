using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("USC")]
public class USC_Certificate : EdifactSegment
{
	[Position(1)]
	public string CertificateReference { get; set; }

	[Position(2)]
	public S500_SecurityIdentificationDetails SecurityIdentificationDetails { get; set; }

	[Position(3)]
	public string CertificateSyntaxAndVersionCoded { get; set; }

	[Position(4)]
	public string FilterFunctionCoded { get; set; }

	[Position(5)]
	public string OriginalCharacterSetEncodingCoded { get; set; }

	[Position(6)]
	public string CertificateOriginalCharacterSetRepertoireCoded { get; set; }

	[Position(7)]
	public string UserAuthorisationLevel { get; set; }

	[Position(8)]
	public S505_ServiceCharacterForSignature ServiceCharacterForSignature { get; set; }

	[Position(9)]
	public S501_SecurityDateAndTime SecurityDateAndTime { get; set; }

	[Position(10)]
	public string SecurityStatusCoded { get; set; }

	[Position(11)]
	public string RevocationReasonCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<USC_Certificate>(this);
		validator.Length(x => x.CertificateReference, 1, 35);
		validator.Length(x => x.CertificateSyntaxAndVersionCoded, 1, 3);
		validator.Length(x => x.FilterFunctionCoded, 1, 3);
		validator.Length(x => x.OriginalCharacterSetEncodingCoded, 1, 3);
		validator.Length(x => x.CertificateOriginalCharacterSetRepertoireCoded, 1, 3);
		validator.Length(x => x.UserAuthorisationLevel, 1, 35);
		validator.Length(x => x.SecurityStatusCoded, 1, 3);
		validator.Length(x => x.RevocationReasonCoded, 1, 3);
		return validator.Results;
	}
}
