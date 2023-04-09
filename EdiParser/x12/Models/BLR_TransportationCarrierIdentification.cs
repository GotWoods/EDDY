using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BLR")]
public class BLR_TransportationCarrierIdentification : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Time { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BLR_TransportationCarrierIdentification>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.ARequiresB(x=>x.Time, x=>x.Date);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		return validator.Results;
	}
}
