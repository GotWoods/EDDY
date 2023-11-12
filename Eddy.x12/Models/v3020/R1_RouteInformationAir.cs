using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("R1")]
public class R1_RouteInformationAir : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(03)]
	public string AirportCode { get; set; }

	[Position(04)]
	public string AirCarrierCode { get; set; }

	[Position(05)]
	public string AirportCode2 { get; set; }

	[Position(06)]
	public string AirCarrierCode2 { get; set; }

	[Position(07)]
	public string AirportCode3 { get; set; }

	[Position(08)]
	public string AirCarrierCode3 { get; set; }

	[Position(09)]
	public string AirportCode4 { get; set; }

	[Position(10)]
	public string AirCarrierCode4 { get; set; }

	[Position(11)]
	public string AirportCode5 { get; set; }

	[Position(12)]
	public string AirCarrierCode5 { get; set; }

	[Position(13)]
	public string AirportCode6 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<R1_RouteInformationAir>(this);
		validator.Required(x=>x.AirportCode);
		validator.Required(x=>x.AirCarrierCode);
		validator.Required(x=>x.AirportCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AirCarrierCode2, x=>x.AirportCode3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AirCarrierCode3, x=>x.AirportCode4);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AirCarrierCode4, x=>x.AirportCode5);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AirCarrierCode5, x=>x.AirportCode6);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.AirportCode, 3, 5);
		validator.Length(x => x.AirCarrierCode, 3);
		validator.Length(x => x.AirportCode2, 3, 5);
		validator.Length(x => x.AirCarrierCode2, 3);
		validator.Length(x => x.AirportCode3, 3, 5);
		validator.Length(x => x.AirCarrierCode3, 3);
		validator.Length(x => x.AirportCode4, 3, 5);
		validator.Length(x => x.AirCarrierCode4, 3);
		validator.Length(x => x.AirportCode5, 3, 5);
		validator.Length(x => x.AirCarrierCode5, 3);
		validator.Length(x => x.AirportCode6, 3, 5);
		return validator.Results;
	}
}
