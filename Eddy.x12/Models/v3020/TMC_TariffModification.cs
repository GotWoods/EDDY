using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("TMC")]
public class TMC_TariffModification : EdiX12Segment
{
	[Position(01)]
	public string DateTimeQualifier { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Time { get; set; }

	[Position(04)]
	public string TariffModificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TMC_TariffModification>(this);
		validator.Required(x=>x.DateTimeQualifier);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Time);
		validator.Required(x=>x.TariffModificationCode);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 6);
		validator.Length(x => x.TariffModificationCode, 1);
		return validator.Results;
	}
}
