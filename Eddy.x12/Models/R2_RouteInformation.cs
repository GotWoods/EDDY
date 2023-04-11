using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("R2")]
public class R2_RouteInformation : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string RoutingSequenceCode { get; set; }

	[Position(03)]
	public string CityName { get; set; }

	[Position(04)]
	public string StandardPointLocationCode { get; set; }

	[Position(05)]
	public string IntermodalServiceCode { get; set; }

	[Position(06)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(07)]
	public string IntermediateSwitchCarrierCode { get; set; }

	[Position(08)]
	public string IntermediateSwitchCarrierCode2 { get; set; }

	[Position(09)]
	public string InvoiceNumber { get; set; }

	[Position(10)]
	public string Date { get; set; }

	[Position(11)]
	public string FreeFormDescription { get; set; }

	[Position(12)]
	public string TypeOfServiceCode { get; set; }

	[Position(13)]
	public string RouteDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<R2_RouteInformation>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.RoutingSequenceCode);
		validator.ARequiresB(x=>x.IntermediateSwitchCarrierCode2, x=>x.IntermediateSwitchCarrierCode);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.RoutingSequenceCode, 1, 2);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.IntermodalServiceCode, 1, 2);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.IntermediateSwitchCarrierCode, 2, 4);
		validator.Length(x => x.IntermediateSwitchCarrierCode2, 2, 4);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.TypeOfServiceCode, 2);
		validator.Length(x => x.RouteDescription, 1, 35);
		return validator.Results;
	}
}
