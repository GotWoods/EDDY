using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("OBI")]
public class OBI_ObligationInformation : EdiX12Segment
{
	[Position(01)]
	public string ObligationTypeCode { get; set; }

	[Position(02)]
	public string Name { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(05)]
	public string FrequencyCode { get; set; }

	[Position(06)]
	public decimal? Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<OBI_ObligationInformation>(this);
		validator.Required(x=>x.ObligationTypeCode);
		validator.Length(x => x.ObligationTypeCode, 2);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
