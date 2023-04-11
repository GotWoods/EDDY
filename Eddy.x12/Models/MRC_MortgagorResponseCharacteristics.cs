using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("MRC")]
public class MRC_MortgagorResponseCharacteristics : EdiX12Segment
{
	[Position(01)]
	public string EntityIdentifierCode { get; set; }

	[Position(02)]
	public string MortgagorResponseCode { get; set; }

	[Position(03)]
	public string ContactMethodCode { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string DateTimePeriod { get; set; }

	[Position(06)]
	public string ContactMethodCode2 { get; set; }

	[Position(07)]
	public decimal? Quantity2 { get; set; }

	[Position(08)]
	public string ContactMethodCode3 { get; set; }

	[Position(09)]
	public decimal? Quantity3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MRC_MortgagorResponseCharacteristics>(this);
		validator.Required(x=>x.EntityIdentifierCode);
		validator.Required(x=>x.MortgagorResponseCode);
		validator.Required(x=>x.ContactMethodCode);
		validator.Required(x=>x.Quantity);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ContactMethodCode2, x=>x.Quantity2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ContactMethodCode3, x=>x.Quantity3);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.MortgagorResponseCode, 1);
		validator.Length(x => x.ContactMethodCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.ContactMethodCode2, 1);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.ContactMethodCode3, 1);
		validator.Length(x => x.Quantity3, 1, 15);
		return validator.Results;
	}
}
