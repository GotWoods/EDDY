using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("OP")]
public class OP_OtherPrograms : EdiX12Segment
{
	[Position(01)]
	public string OtherProgramParticipationCode { get; set; }

	[Position(02)]
	public string OtherProgramFundingSourceCode { get; set; }

	[Position(03)]
	public string Name { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<OP_OtherPrograms>(this);
		validator.AtLeastOneIsRequired(x=>x.OtherProgramParticipationCode, x=>x.Name);
		validator.Length(x => x.OtherProgramParticipationCode, 1, 2);
		validator.Length(x => x.OtherProgramFundingSourceCode, 1);
		validator.Length(x => x.Name, 1, 35);
		return validator.Results;
	}
}
