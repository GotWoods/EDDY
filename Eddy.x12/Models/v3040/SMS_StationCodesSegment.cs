using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("SMS")]
public class SMS_StationCodesSegment : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string FreightStationAccountingCode { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string Rule260JunctionCode { get; set; }

	[Position(05)]
	public string PostalCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SMS_StationCodesSegment>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.FreightStationAccountingCode);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.FreightStationAccountingCode, 1, 5);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Rule260JunctionCode, 1, 5);
		validator.Length(x => x.PostalCode, 3, 9);
		return validator.Results;
	}
}
