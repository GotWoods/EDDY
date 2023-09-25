using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("OP")]
public class OP_OtherProgramsAndServices : EdiX12Segment
{
	[Position(01)]
	public string OtherProgramParticipationAndServicesCode { get; set; }

	[Position(02)]
	public string OtherProgramAndServicesFundingSourceCode { get; set; }

	[Position(03)]
	public string Name { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<OP_OtherProgramsAndServices>(this);
		validator.AtLeastOneIsRequired(x=>x.OtherProgramParticipationAndServicesCode, x=>x.Name);
		validator.Length(x => x.OtherProgramParticipationAndServicesCode, 1, 2);
		validator.Length(x => x.OtherProgramAndServicesFundingSourceCode, 1);
		validator.Length(x => x.Name, 1, 35);
		return validator.Results;
	}
}
