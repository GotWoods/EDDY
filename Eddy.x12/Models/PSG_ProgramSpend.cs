using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("PSG")]
public class PSG_ProgramSpend : EdiX12Segment
{
	[Position(01)]
	public string SpendTypeCode { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PSG_ProgramSpend>(this);
		validator.AtLeastOneIsRequired(x=>x.SpendTypeCode, x=>x.Description);
		validator.Length(x => x.SpendTypeCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
