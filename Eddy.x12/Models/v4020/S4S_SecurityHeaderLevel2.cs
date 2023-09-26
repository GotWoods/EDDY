using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("S4S")]
public class S4S_SecurityHeaderLevel2 : EdiX12Segment
{
	[Position(01)]
	public string SecurityVersionReleaseIdentifierCode { get; set; }

	[Position(02)]
	public string SecurityTypeCode { get; set; }

	[Position(03)]
	public string SecurityOriginatorName { get; set; }

	[Position(04)]
	public string SecurityRecipientName { get; set; }

	[Position(05)]
	public string AuthenticationKeyName { get; set; }

	[Position(06)]
	public string AuthenticationServiceCode { get; set; }

	[Position(07)]
	public C050_CertificateLookUpInformation CertificateLookUpInformation { get; set; }

	[Position(08)]
	public C031_EncryptionKeyInformation EncryptionKeyInformation { get; set; }

	[Position(09)]
	public C032_EncryptionServiceInformation EncryptionServiceInformation { get; set; }

	[Position(10)]
	public string LengthOfData { get; set; }

	[Position(11)]
	public string TransformedData { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S4S_SecurityHeaderLevel2>(this);
		validator.Required(x=>x.SecurityVersionReleaseIdentifierCode);
		validator.Required(x=>x.SecurityTypeCode);
		validator.Required(x=>x.SecurityOriginatorName);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AuthenticationKeyName, x=>x.AuthenticationServiceCode);
		validator.Length(x => x.SecurityVersionReleaseIdentifierCode, 6);
		validator.Length(x => x.SecurityTypeCode, 2);
		validator.Length(x => x.SecurityOriginatorName, 1, 64);
		validator.Length(x => x.SecurityRecipientName, 1, 64);
		validator.Length(x => x.AuthenticationKeyName, 1, 64);
		validator.Length(x => x.AuthenticationServiceCode, 1);
		validator.Length(x => x.LengthOfData, 1, 18);
		validator.Length(x => x.TransformedData, 1, 2147483647);
		return validator.Results;
	}
}
