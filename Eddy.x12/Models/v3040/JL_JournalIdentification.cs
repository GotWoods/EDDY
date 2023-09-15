using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("JL")]
public class JL_JournalIdentification : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Time { get; set; }

	[Position(04)]
	public string Name30CharacterFormat { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<JL_JournalIdentification>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Time);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.Name30CharacterFormat, 2, 30);
		return validator.Results;
	}
}
