using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("Q5")]
public class Q5_StatusDetails : EdiX12Segment
{
	[Position(01)]
	public string StatusCode { get; set; }

	[Position(02)]
	public string StatusDate { get; set; }

	[Position(03)]
	public string StatusTime { get; set; }

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
	public string ReferenceNumberQualifier { get; set; }

	[Position(12)]
	public string ReferenceNumber { get; set; }

	[Position(13)]
	public string DirectionIdentifierCode { get; set; }

	[Position(14)]
	public string ReferenceNumberQualifier2 { get; set; }

	[Position(15)]
	public string ReferenceNumber2 { get; set; }

	[Position(16)]
	public string DirectionIdentifierCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<Q5_StatusDetails>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CityName, x=>x.StateOrProvinceCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.ARequiresB(x=>x.DirectionIdentifierCode, x=>x.ReferenceNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier2, x=>x.ReferenceNumber2);
		validator.ARequiresB(x=>x.DirectionIdentifierCode2, x=>x.ReferenceNumber2);
		validator.Length(x => x.StatusCode, 1, 2);
		validator.Length(x => x.StatusDate, 6);
		validator.Length(x => x.StatusTime, 4);
		validator.Length(x => x.TimeCode, 2);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.DirectionIdentifierCode, 1);
		validator.Length(x => x.ReferenceNumberQualifier2, 2);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.DirectionIdentifierCode2, 1);
		return validator.Results;
	}
}
