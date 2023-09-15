using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("M15")]
public class M15_USCustomsEventsAdvisoryDetails : EdiX12Segment
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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M15_USCustomsEventsAdvisoryDetails>(this);
		validator.Required(x=>x.NotificationEntityQualifier);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Date);
		validator.AtLeastOneIsRequired(x=>x.LocationIdentifier, x=>x.CityName);
		validator.Required(x=>x.Time);
		validator.ARequiresB(x=>x.StateOrProvinceCode, x=>x.CityName);
		validator.Length(x => x.NotificationEntityQualifier, 1, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.SealNumber, 2, 15);
		validator.Length(x => x.ReferenceIdentification2, 1, 30);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
