using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("A1")]
public class A1_Rejection : EdiX12Segment
{
	[Position(01)]
	public string RejectedSetIdentifier { get; set; }

	[Position(02)]
	public string ReferenceDesignator { get; set; }

	[Position(03)]
	public string ErrorFieldData { get; set; }

	[Position(04)]
	public string ErrorConditionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<A1_Rejection>(this);
		validator.Required(x=>x.RejectedSetIdentifier);
		validator.Required(x=>x.ReferenceDesignator);
		validator.Required(x=>x.ErrorConditionCode);
		validator.Length(x => x.RejectedSetIdentifier, 4, 19);
		validator.Length(x => x.ReferenceDesignator, 4, 5);
		validator.Length(x => x.ErrorFieldData, 1, 12);
		validator.Length(x => x.ErrorConditionCode, 1);
		return validator.Results;
	}
}
