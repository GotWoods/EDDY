using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("RRE")]
public class RRE_ContractRelatedErrorReporting : EdiX12Segment
{
	[Position(01)]
	public string RejectReasonCode { get; set; }

	[Position(02)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RRE_ContractRelatedErrorReporting>(this);
		validator.AtLeastOneIsRequired(x=>x.RejectReasonCode, x=>x.Description);
		validator.Length(x => x.RejectReasonCode, 2);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
