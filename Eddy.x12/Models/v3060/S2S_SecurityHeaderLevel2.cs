using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060.Composites;

namespace Eddy.x12.Models.v3060;

[Segment("S2S")]
public class S2S_SecurityHeaderLevel2 : EdiX12Segment
{
	[Position(01)]
	public string SecurityType { get; set; }

	[Position(02)]
	public string SecurityOriginatorName { get; set; }

	[Position(03)]
	public string SecurityRecipientName { get; set; }

	[Position(04)]
	public string AuthenticationKeyName { get; set; }

	[Position(05)]
	public string AuthenticationServiceCode { get; set; }

	[Position(06)]
	public C031_EncryptionKeyInformation EncryptionKeyInformation { get; set; }

	[Position(07)]
	public C032_EncryptionServiceInformation EncryptionServiceInformation { get; set; }

	[Position(08)]
	public string LengthOfData { get; set; }

	[Position(09)]
	public string InitializationVector { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S2S_SecurityHeaderLevel2>(this);
		validator.Required(x=>x.SecurityType);
		validator.Required(x=>x.SecurityOriginatorName);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AuthenticationKeyName, x=>x.AuthenticationServiceCode);
		validator.Length(x => x.SecurityType, 2);
		validator.Length(x => x.SecurityOriginatorName, 1, 64);
		validator.Length(x => x.SecurityRecipientName, 1, 64);
		validator.Length(x => x.AuthenticationKeyName, 1, 64);
		validator.Length(x => x.AuthenticationServiceCode, 1);
		validator.Length(x => x.LengthOfData, 1, 18);
		validator.Length(x => x.InitializationVector, 16);
		return validator.Results;
	}
}
