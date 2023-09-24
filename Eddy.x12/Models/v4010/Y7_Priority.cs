using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("Y7")]
public class Y7_Priority : EdiX12Segment
{
	[Position(01)]
	public int? Priority { get; set; }

	[Position(02)]
	public int? PriorityCode { get; set; }

	[Position(03)]
	public string PriorityCodeQualifier { get; set; }

	[Position(04)]
	public int? PortCallFileNumber { get; set; }

	[Position(05)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<Y7_Priority>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PriorityCode, x=>x.PriorityCodeQualifier);
		validator.Length(x => x.Priority, 1);
		validator.Length(x => x.PriorityCode, 1);
		validator.Length(x => x.PriorityCodeQualifier, 1);
		validator.Length(x => x.PortCallFileNumber, 4);
		validator.Length(x => x.Date, 8);
		return validator.Results;
	}
}
