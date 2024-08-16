using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E027")]
public class E027_InvoiceType : EdifactComponent
{
	[Position(1)]
	public string InvoiceTypeCode { get; set; }

	[Position(2)]
	public string FrequencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E027_InvoiceType>(this);
		validator.Required(x=>x.InvoiceTypeCode);
		validator.Length(x => x.InvoiceTypeCode, 1, 3);
		validator.Length(x => x.FrequencyCode, 1, 3);
		return validator.Results;
	}
}
