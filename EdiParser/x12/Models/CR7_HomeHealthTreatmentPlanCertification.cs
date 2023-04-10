using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("CR7")]
public class CR7_HomeHealthTreatmentPlanCertification : EdiX12Segment
{
	[Position(01)]
	public string DisciplineTypeCode { get; set; }

	[Position(02)]
	public int? Number { get; set; }

	[Position(03)]
	public int? Number2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CR7_HomeHealthTreatmentPlanCertification>(this);
		validator.Required(x=>x.DisciplineTypeCode);
		validator.Required(x=>x.Number);
		validator.Required(x=>x.Number2);
		validator.Length(x => x.DisciplineTypeCode, 2);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.Number2, 1, 9);
		return validator.Results;
	}
}
