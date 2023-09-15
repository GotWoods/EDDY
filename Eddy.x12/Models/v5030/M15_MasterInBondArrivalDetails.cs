using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("M15")]
public class M15_CustomsEventsAdvisoryDetails : EdiX12Segment
{
	[Position(01)]
	public string NotificationEntityQualifier { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string LocationIdentifier { get; set; }

	[Position(05)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(06)]
	public string Time { get; set; }

	[Position(07)]
	public string SealNumber { get; set; }

	[Position(08)]
	public string ReferenceIdentification2 { get; set; }

	[Position(09)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(10)]
	public string CityName { get; set; }

	[Position(11)]
	public string StateOrProvinceCode { get; set; }

	[Position(12)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(13)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(14)]
	public string ReferenceIdentification3 { get; set; }

	[Position(15)]
	public string VesselName { get; set; }

	[Position(16)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(17)]
	public string LocationIdentifier2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M15_CustomsEventsAdvisoryDetails>(this);
		validator.Required(x=>x.NotificationEntityQualifier);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Date);
		validator.AtLeastOneIsRequired(x=>x.LocationIdentifier, x=>x.CityName);
		validator.Required(x=>x.Time);
		validator.ARequiresB(x=>x.StateOrProvinceCode, x=>x.CityName);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification3);
		validator.ARequiresB(x=>x.VesselName, x=>x.TransportationMethodTypeCode);
		validator.Length(x => x.NotificationEntityQualifier, 1, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.SealNumber, 2, 15);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification3, 1, 80);
		validator.Length(x => x.VesselName, 2, 28);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.LocationIdentifier2, 1, 30);
		return validator.Results;
	}
}
