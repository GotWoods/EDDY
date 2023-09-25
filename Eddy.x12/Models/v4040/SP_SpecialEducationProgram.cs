using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4040;

[Segment("SP")]
public class SP_SpecialProgram : EdiX12Segment
{
	[Position(01)]
	public string SpecialProgramCategoryCode { get; set; }

	[Position(02)]
	public decimal? Percent { get; set; }

	[Position(03)]
	public string ProgramParticipationAndServicesCode { get; set; }

	[Position(04)]
	public string InstitutionalGovernanceOrFundingSourceLevelCode { get; set; }

	[Position(05)]
	public string Name { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SP_SpecialProgram>(this);
		validator.AtLeastOneIsRequired(x=>x.SpecialProgramCategoryCode, x=>x.ProgramParticipationAndServicesCode);
		validator.Length(x => x.SpecialProgramCategoryCode, 1, 2);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.ProgramParticipationAndServicesCode, 1, 2);
		validator.Length(x => x.InstitutionalGovernanceOrFundingSourceLevelCode, 1);
		validator.Length(x => x.Name, 1, 60);
		return validator.Results;
	}
}
