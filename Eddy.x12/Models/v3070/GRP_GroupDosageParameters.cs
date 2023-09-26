using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("GRP")]
public class GRP_GroupDosageParameters : EdiX12Segment
{
	[Position(01)]
	public int? Number { get; set; }

	[Position(02)]
	public string UnitDoseCode { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GRP_GroupDosageParameters>(this);
		validator.Required(x=>x.Number);
		validator.Required(x=>x.UnitDoseCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Date2);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.UnitDoseCode, 1);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Date2, 6);
		return validator.Results;
	}
}
