using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("RTT")]
public class RTT_FreightRate : EdiX12Segment
{
	[Position(01)]
	public string RateValueQualifier { get; set; }

	[Position(02)]
	public decimal? FreightRate { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RTT_FreightRate>(this);
		validator.Required(x=>x.RateValueQualifier);
		validator.Required(x=>x.FreightRate);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.FreightRate, 1, 9);
		return validator.Results;
	}
}
