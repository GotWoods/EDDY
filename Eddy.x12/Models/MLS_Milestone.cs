using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("MLS")]
public class MLS_Milestone : EdiX12Segment
{
	[Position(01)]
	public string MilestoneNumberIdentification { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public string WorkStatusCode { get; set; }

	[Position(04)]
	public string ActionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MLS_Milestone>(this);
		validator.Required(x=>x.MilestoneNumberIdentification);
		validator.Length(x => x.MilestoneNumberIdentification, 1, 20);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.WorkStatusCode, 1, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		return validator.Results;
	}
}
