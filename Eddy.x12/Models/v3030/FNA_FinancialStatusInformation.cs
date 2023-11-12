using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("FNA")]
public class FNA_FinancialStatusInformation : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(04)]
	public string DependencyStatusCode { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode4 { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FNA_FinancialStatusInformation>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Required(x=>x.YesNoConditionOrResponseCode2);
		validator.Required(x=>x.YesNoConditionOrResponseCode3);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.DependencyStatusCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode4, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode5, 1);
		return validator.Results;
	}
}
