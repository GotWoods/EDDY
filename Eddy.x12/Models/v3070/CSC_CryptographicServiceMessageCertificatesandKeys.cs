using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070.Composites;

namespace Eddy.x12.Models.v3070;

[Segment("CSC")]
public class CSC_CryptographicServiceMessageCertificatesAndKeys : EdiX12Segment
{
	[Position(01)]
	public string CryptographicManagementPurpose { get; set; }

	[Position(02)]
	public string SecurityOriginatorName { get; set; }

	[Position(03)]
	public string SecurityRecipientName { get; set; }

	[Position(04)]
	public C050_CertificateLookUpInformation CertificateLookUpInformation { get; set; }

	[Position(05)]
	public C040_ReferenceIdentifier ReferenceIdentifier { get; set; }

	[Position(06)]
	public string FilterIDCode { get; set; }

	[Position(07)]
	public string VersionIdentifier { get; set; }

	[Position(08)]
	public string LengthOfData { get; set; }

	[Position(09)]
	public C033_SecurityValue SecurityValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CSC_CryptographicServiceMessageCertificatesAndKeys>(this);
		validator.Required(x=>x.CryptographicManagementPurpose);
		validator.Length(x => x.CryptographicManagementPurpose, 3);
		validator.Length(x => x.SecurityOriginatorName, 1, 64);
		validator.Length(x => x.SecurityRecipientName, 1, 64);
		validator.Length(x => x.FilterIDCode, 3);
		validator.Length(x => x.VersionIdentifier, 1, 30);
		validator.Length(x => x.LengthOfData, 1, 18);
		return validator.Results;
	}
}
