using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("U5")]
public class U5_PriorOriginName : EdiX12Segment
{
	[Position(01)]
	public string Name30CharacterFormat { get; set; }

	[Position(02)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(03)]
	public string IdentificationCode { get; set; }

	[Position(04)]
	public string ImportLicenseExpirationDate { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<U5_PriorOriginName>(this);
		validator.Required(x=>x.Name30CharacterFormat);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.Name30CharacterFormat, 2, 30);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 17);
		validator.Length(x => x.ImportLicenseExpirationDate, 6);
		return validator.Results;
	}
}
