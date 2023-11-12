using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("DED")]
public class DED_Deductions : EdiX12Segment
{
	[Position(01)]
	public string TypeOfDeduction { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string Amount { get; set; }

	[Position(05)]
	public string ReferenceNumber2 { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(07)]
	public string Name { get; set; }

	[Position(08)]
	public string ReferenceNumber3 { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DED_Deductions>(this);
		validator.Required(x=>x.TypeOfDeduction);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Amount);
		validator.Required(x=>x.ReferenceNumber2);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Length(x => x.TypeOfDeduction, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Name, 1, 35);
		validator.Length(x => x.ReferenceNumber3, 1, 30);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		return validator.Results;
	}
}
