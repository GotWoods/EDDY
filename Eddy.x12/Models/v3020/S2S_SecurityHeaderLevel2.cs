using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

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
	public string EncryptionKeyName { get; set; }

	[Position(07)]
	public string EncryptionServiceCode { get; set; }

	[Position(08)]
	public string LengthOfDataLOD { get; set; }

	[Position(09)]
	public string InitializationVectorIV { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S2S_SecurityHeaderLevel2>(this);
		validator.Required(x=>x.SecurityType);
		validator.Required(x=>x.SecurityOriginatorName);
		validator.Required(x=>x.SecurityRecipientName);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AuthenticationKeyName, x=>x.AuthenticationServiceCode);
		validator.Length(x => x.SecurityType, 2);
		validator.Length(x => x.SecurityOriginatorName, 4, 16);
		validator.Length(x => x.SecurityRecipientName, 4, 16);
		validator.Length(x => x.AuthenticationKeyName, 1, 16);
		validator.Length(x => x.AuthenticationServiceCode, 1);
		validator.Length(x => x.EncryptionKeyName, 1, 16);
		validator.Length(x => x.EncryptionServiceCode, 1, 3);
		validator.Length(x => x.LengthOfDataLOD, 1, 18);
		validator.Length(x => x.InitializationVectorIV, 16);
		return validator.Results;
	}
}
