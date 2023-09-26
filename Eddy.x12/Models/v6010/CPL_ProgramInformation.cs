using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6010;

[Segment("CPL")]
public class CPL_ProgramInformation : EdiX12Segment
{
	[Position(01)]
	public string ProgramTypeCode { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public string ActionCode { get; set; }

	[Position(04)]
	public string ContractDateBasisCode { get; set; }

	[Position(05)]
	public string EntityIdentifierCode { get; set; }

	[Position(06)]
	public string Description2 { get; set; }

	[Position(07)]
	public string ConditionIndicator { get; set; }

	[Position(08)]
	public string ProgramBasisTypeCode { get; set; }

	[Position(09)]
	public string ConditionIndicator2 { get; set; }

	[Position(10)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(11)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(12)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CPL_ProgramInformation>(this);
		validator.Required(x=>x.ProgramTypeCode);
		validator.Required(x=>x.Description);
		validator.Required(x=>x.ActionCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ContractDateBasisCode, x=>x.EntityIdentifierCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ConditionIndicator, x=>x.ProgramBasisTypeCode);
		validator.Length(x => x.ProgramTypeCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.ContractDateBasisCode, 1, 2);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.ConditionIndicator, 2, 3);
		validator.Length(x => x.ProgramBasisTypeCode, 2);
		validator.Length(x => x.ConditionIndicator2, 2, 3);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		return validator.Results;
	}
}
