using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("SP")]
public class SP_SpecialEducationProgram : EdiX12Segment
{
	[Position(01)]
	public string SpecialEducationProgramParticipationCode { get; set; }

	[Position(02)]
	public string InstructionalSettingCode { get; set; }

	[Position(03)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public decimal? Percent { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SP_SpecialEducationProgram>(this);
		validator.Required(x=>x.SpecialEducationProgramParticipationCode);
		validator.Length(x => x.SpecialEducationProgramParticipationCode, 1, 2);
		validator.Length(x => x.InstructionalSettingCode, 1, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Percent, 1, 10);
		return validator.Results;
	}
}
