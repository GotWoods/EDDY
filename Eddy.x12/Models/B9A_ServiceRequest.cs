using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("B9A")]
public class B9A_ServiceRequest : EdiX12Segment 
{
	[Position(01)]
	public string ServiceRequestCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B9A_ServiceRequest>(this);
		validator.Required(x=>x.ServiceRequestCode);
		validator.Length(x => x.ServiceRequestCode, 2);
		return validator.Results;
	}
}
