using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("CA1")]
public class CA1_RateRequestIdentifier : EdiX12Segment
{
	[Position(01)]
	public int? RateRequestID { get; set; }

	[Position(02)]
	public int? RateResponseSuffix { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CA1_RateRequestIdentifier>(this);
		validator.Required(x=>x.RateRequestID);
		validator.Length(x => x.RateRequestID, 1, 9);
		validator.Length(x => x.RateResponseSuffix, 1, 3);
		return validator.Results;
	}
}
