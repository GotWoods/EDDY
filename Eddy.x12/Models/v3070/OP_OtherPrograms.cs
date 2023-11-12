using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("OP")]
public class OP_OtherProgramsAndServices : EdiX12Segment
{
	[Position(01)]
	public string ProgramParticipationAndServicesCode { get; set; }

	[Position(02)]
	public string ProgramAndServicesFundingSourceCode { get; set; }

	[Position(03)]
	public string Name { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<OP_OtherProgramsAndServices>(this);
		validator.AtLeastOneIsRequired(x=>x.ProgramParticipationAndServicesCode, x=>x.Name);
		validator.Length(x => x.ProgramParticipationAndServicesCode, 1, 2);
		validator.Length(x => x.ProgramAndServicesFundingSourceCode, 1);
		validator.Length(x => x.Name, 1, 60);
		return validator.Results;
	}
}
