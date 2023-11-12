using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("CM")]
public class CM_CargoManifest : EdiX12Segment
{
	[Position(01)]
	public string FlightVoyageNumber { get; set; }

	[Position(02)]
	public string PortFunctionCode { get; set; }

	[Position(03)]
	public string PortName { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string BookingNumber { get; set; }

	[Position(06)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(07)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(08)]
	public string Date2 { get; set; }

	[Position(09)]
	public string VesselName { get; set; }

	[Position(10)]
	public string PierNumber { get; set; }

	[Position(11)]
	public string PierName { get; set; }

	[Position(12)]
	public string TerminalName { get; set; }

	[Position(13)]
	public string StateOrProvinceCode { get; set; }

	[Position(14)]
	public string CountryCode { get; set; }

	[Position(15)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CM_CargoManifest>(this);
		validator.ARequiresB(x=>x.Date, x=>x.PortFunctionCode);
		validator.Length(x => x.FlightVoyageNumber, 2, 10);
		validator.Length(x => x.PortFunctionCode, 1);
		validator.Length(x => x.PortName, 2, 24);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.BookingNumber, 1, 17);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.VesselName, 2, 28);
		validator.Length(x => x.PierNumber, 1, 4);
		validator.Length(x => x.PierName, 2, 14);
		validator.Length(x => x.TerminalName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		return validator.Results;
	}
}
