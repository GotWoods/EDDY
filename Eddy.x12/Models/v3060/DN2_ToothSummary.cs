using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("DN2")]
public class DN2_ToothSummary : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string ToothStatusCode { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DN2_ToothSummary>(this);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.ToothStatusCode);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.ToothStatusCode, 1, 2);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
