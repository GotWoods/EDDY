using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("Y3")]
public class Y3_SpaceConfirmation : EdiX12Segment
{
	[Position(01)]
	public string BookingNumber { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(03)]
	public string SailingDate { get; set; }

	[Position(04)]
	public string ETADate { get; set; }

	[Position(05)]
	public string StandardPointLocationCode { get; set; }

	[Position(06)]
	public string PierName { get; set; }

	[Position(07)]
	public string Date { get; set; }

	[Position(08)]
	public string Time { get; set; }

	[Position(09)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(10)]
	public string TariffServiceCode { get; set; }

	[Position(11)]
	public string TimeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<Y3_SpaceConfirmation>(this);
		validator.Required(x=>x.BookingNumber);
		validator.ARequiresB(x=>x.TransportationMethodTypeCode, x=>x.Time);
		validator.Length(x => x.BookingNumber, 1, 17);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.SailingDate, 6);
		validator.Length(x => x.ETADate, 6);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.PierName, 2, 14);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.TariffServiceCode, 2);
		validator.Length(x => x.TimeCode, 2);
		return validator.Results;
	}
}
