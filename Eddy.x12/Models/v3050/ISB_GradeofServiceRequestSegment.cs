using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("ISB")]
public class ISB_GradeOfServiceRequestSegment : EdiX12Segment
{
	[Position(01)]
	public string GradeOfServiceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ISB_GradeOfServiceRequestSegment>(this);
		validator.Required(x=>x.GradeOfServiceCode);
		validator.Length(x => x.GradeOfServiceCode, 1);
		return validator.Results;
	}
}
