using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("SHP")]
public class SHP_ShippedReceivedInformation : EdiX12Segment
{
	[Position(01)]
	public string QuantityQualifier { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string DateTimeQualifier { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string Time { get; set; }

	[Position(06)]
	public string Date2 { get; set; }

	[Position(07)]
	public string Time2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SHP_ShippedReceivedInformation>(this);
		validator.ARequiresB(x=>x.QuantityQualifier, x=>x.Quantity);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DateTimeQualifier, x=>x.Date, x=>x.Time);
		validator.ARequiresB(x=>x.Date, x=>x.DateTimeQualifier);
		validator.ARequiresB(x=>x.Time, x=>x.DateTimeQualifier);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.Time2, 4, 8);
		return validator.Results;
	}
}
