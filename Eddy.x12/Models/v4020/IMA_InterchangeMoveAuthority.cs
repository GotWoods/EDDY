using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("IMA")]
public class IMA_InterchangeMoveAuthority : EdiX12Segment
{
	[Position(01)]
	public string MovementAuthorityCode { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(03)]
	public string TariffApplicationCode { get; set; }

	[Position(04)]
	public string TariffApplicationCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IMA_InterchangeMoveAuthority>(this);
		validator.Required(x=>x.MovementAuthorityCode);
		validator.Length(x => x.MovementAuthorityCode, 1, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.TariffApplicationCode, 1);
		validator.Length(x => x.TariffApplicationCode2, 1);
		return validator.Results;
	}
}
