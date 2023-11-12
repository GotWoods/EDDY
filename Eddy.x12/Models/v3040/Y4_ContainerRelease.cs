using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("Y4")]
public class Y4_ContainerRelease : EdiX12Segment
{
	[Position(01)]
	public string BookingNumber { get; set; }

	[Position(02)]
	public string BookingNumber2 { get; set; }

	[Position(03)]
	public string ContainerAvailabilityDate { get; set; }

	[Position(04)]
	public string StandardPointLocationCode { get; set; }

	[Position(05)]
	public int? NumberOfContainers { get; set; }

	[Position(06)]
	public string EquipmentType { get; set; }

	[Position(07)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(08)]
	public string LocationQualifier { get; set; }

	[Position(09)]
	public string LocationIdentifier { get; set; }

	[Position(10)]
	public string TypeOfServiceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<Y4_ContainerRelease>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LocationQualifier, x=>x.LocationIdentifier);
		validator.Length(x => x.BookingNumber, 1, 17);
		validator.Length(x => x.BookingNumber2, 1, 17);
		validator.Length(x => x.ContainerAvailabilityDate, 6);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.NumberOfContainers, 1, 4);
		validator.Length(x => x.EquipmentType, 4);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.TypeOfServiceCode, 2);
		return validator.Results;
	}
}
