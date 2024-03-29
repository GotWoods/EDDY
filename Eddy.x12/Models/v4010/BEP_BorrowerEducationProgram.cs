using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("BEP")]
public class BEP_BorrowerEducationProgram : EdiX12Segment
{
	[Position(01)]
	public string ProgramParticipationAndServicesCode { get; set; }

	[Position(02)]
	public string InstructionalSettingCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BEP_BorrowerEducationProgram>(this);
		validator.Required(x=>x.ProgramParticipationAndServicesCode);
		validator.Required(x=>x.InstructionalSettingCode);
		validator.Length(x => x.ProgramParticipationAndServicesCode, 1, 2);
		validator.Length(x => x.InstructionalSettingCode, 1, 2);
		return validator.Results;
	}
}
