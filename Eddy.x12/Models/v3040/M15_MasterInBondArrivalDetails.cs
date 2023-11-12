using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("M15")]
public class M15_USCustomsEventsAdvisoryDetails : EdiX12Segment
{
	[Position(01)]
	public string NotificationEntityQualifier { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

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
	public string ReferenceNumber2 { get; set; }

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
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.LocationIdentifier);
		validator.Required(x=>x.Time);
		validator.ARequiresB(x=>x.StateOrProvinceCode, x=>x.CityName);
		validator.Length(x => x.NotificationEntityQualifier, 1, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.SealNumber, 2, 15);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
