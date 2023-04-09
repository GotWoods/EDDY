using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("BA1")]
public class BA1_ExportShipmentIdentifyingInformation : EdiX12Segment 
{
	[Position(01)]
	public string RelatedCompanyIndicationCode { get; set; }

	[Position(02)]
	public string ActionCode { get; set; }

	[Position(03)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(04)]
	public string CountryCode { get; set; }

	[Position(05)]
	public string ReferenceIdentification { get; set; }

	[Position(06)]
	public string PostalCode { get; set; }

	[Position(07)]
	public string CountryCode2 { get; set; }

	[Position(08)]
	public string StateOrProvinceCode { get; set; }

	[Position(09)]
	public string Authority { get; set; }

	[Position(10)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(11)]
	public string LocationIdentifier { get; set; }

	[Position(12)]
	public string VesselName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BA1_ExportShipmentIdentifyingInformation>(this);
		validator.Required(x=>x.RelatedCompanyIndicationCode);
		validator.Required(x=>x.ActionCode);
		validator.Required(x=>x.TransportationMethodTypeCode);
		validator.Required(x=>x.CountryCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Length(x => x.RelatedCompanyIndicationCode, 1);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.PostalCode, 3, 15);
		validator.Length(x => x.CountryCode2, 2, 3);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.Authority, 1, 20);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.VesselName, 2, 50);
		return validator.Results;
	}
}
