using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("DED")]
public class DED_Deductions : EdiX12Segment
{
	[Position(01)]
	public string TypeOfDeduction { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string Amount { get; set; }

	[Position(05)]
	public string ReferenceIdentification2 { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(07)]
	public string Name { get; set; }

	[Position(08)]
	public string ReferenceIdentification3 { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DED_Deductions>(this);
		validator.Required(x=>x.TypeOfDeduction);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Amount);
		validator.Required(x=>x.ReferenceIdentification2);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Length(x => x.TypeOfDeduction, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.ReferenceIdentification2, 1, 50);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.ReferenceIdentification3, 1, 50);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		return validator.Results;
	}
}
