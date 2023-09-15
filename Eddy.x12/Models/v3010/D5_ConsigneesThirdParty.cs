using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("D5")]
public class D5_ConsigneesThirdParty : EdiX12Segment
{
	[Position(01)]
	public string EntityIdentifierCode { get; set; }

	[Position(02)]
	public string Name30CharacterFormat { get; set; }

	[Position(03)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(04)]
	public string IdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<D5_ConsigneesThirdParty>(this);
		validator.Required(x=>x.EntityIdentifierCode);
		validator.Required(x=>x.Name30CharacterFormat);
		validator.Length(x => x.EntityIdentifierCode, 2);
		validator.Length(x => x.Name30CharacterFormat, 2, 30);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 17);
		return validator.Results;
	}
}
