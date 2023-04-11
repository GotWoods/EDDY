using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("RQS")]
public class RQS_RequestForInformation : EdiX12Segment
{
	[Position(01)]
	public string CodeListQualifierCode { get; set; }

	[Position(02)]
	public string IndustryCode { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(05)]
	public string Description2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RQS_RequestForInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeListQualifierCode, x=>x.IndustryCode);
		validator.AtLeastOneIsRequired(x=>x.IndustryCode, x=>x.Description);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Description2, 1, 80);
		return validator.Results;
	}
}
