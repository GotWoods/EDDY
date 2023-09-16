using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4040;

[Segment("Q5")]
public class Q5_StatusDetails : EdiX12Segment
{
	[Position(01)]
	public string ShipmentStatusCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Time { get; set; }

	[Position(04)]
	public string TimeCode { get; set; }

	[Position(05)]
	public string StatusReasonCode { get; set; }

	[Position(06)]
	public string CityName { get; set; }

	[Position(07)]
	public string StateOrProvinceCode { get; set; }

	[Position(08)]
	public string CountryCode { get; set; }

	[Position(09)]
	public string EquipmentInitial { get; set; }

	[Position(10)]
	public string EquipmentNumber { get; set; }

	[Position(11)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(12)]
	public string ReferenceIdentification { get; set; }

	[Position(13)]
	public string DirectionIdentifierCode { get; set; }

	[Position(14)]
	public string ReferenceIdentificationQualifier2 { get; set; }

	[Position(15)]
	public string ReferenceIdentification2 { get; set; }

	[Position(16)]
	public string DirectionIdentifierCode2 { get; set; }

	[Position(17)]
	public decimal? Percent { get; set; }

	[Position(18)]
	public string PickUpOrDeliveryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<Q5_StatusDetails>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Time, x=>x.TimeCode);
		validator.ARequiresB(x=>x.StateOrProvinceCode, x=>x.CityName);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.ARequiresB(x=>x.DirectionIdentifierCode, x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier2, x=>x.ReferenceIdentification2);
		validator.ARequiresB(x=>x.DirectionIdentifierCode2, x=>x.ReferenceIdentification2);
		validator.Length(x => x.ShipmentStatusCode, 1, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.TimeCode, 2);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 15);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.DirectionIdentifierCode, 1);
		validator.Length(x => x.ReferenceIdentificationQualifier2, 2, 3);
		validator.Length(x => x.ReferenceIdentification2, 1, 50);
		validator.Length(x => x.DirectionIdentifierCode2, 1);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.PickUpOrDeliveryCode, 1, 2);
		return validator.Results;
	}
}
