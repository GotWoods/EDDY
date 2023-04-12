using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("VEH")]
public class VEH_VehicleInformation : EdiX12Segment
{
	[Position(01)]
	public int? AssignedNumber { get; set; }

	[Position(02)]
	public string VehicleIdentificationNumber { get; set; }

	[Position(03)]
	public int? Year { get; set; }

	[Position(04)]
	public string AgencyQualifierCode { get; set; }

	[Position(05)]
	public string ReferenceIdentification { get; set; }

	[Position(06)]
	public string ReferenceIdentification2 { get; set; }

	[Position(07)]
	public string ReferenceIdentification3 { get; set; }

	[Position(08)]
	public decimal? Length { get; set; }

	[Position(09)]
	public string ReferenceIdentification4 { get; set; }

	[Position(10)]
	public string StateOrProvinceCode { get; set; }

	[Position(11)]
	public string LocationIdentifier { get; set; }

	[Position(12)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(13)]
	public string Amount { get; set; }

	[Position(14)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(15)]
	public string Amount2 { get; set; }

	[Position(16)]
	public string ActionCode { get; set; }

	[Position(17)]
	public string CountryCode { get; set; }

	[Position(18)]
	public string Name { get; set; }

	[Position(19)]
	public string CountryCode2 { get; set; }

	[Position(20)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(21)]
	public string ReferenceIdentification5 { get; set; }

	[Position(22)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(23)]
	public string LoadEmptyStatusCode { get; set; }

	[Position(24)]
	public string ReferenceIdentification6 { get; set; }

	[Position(25)]
	public string ReferenceIdentification7 { get; set; }

	[Position(26)]
	public string CountrySubdivisionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<VEH_VehicleInformation>(this);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.AgencyQualifierCode, x=>x.ReferenceIdentification, x=>x.ReferenceIdentification3);
		validator.ARequiresB(x=>x.ReferenceIdentification, x=>x.AgencyQualifierCode);
		validator.ARequiresB(x=>x.ReferenceIdentification3, x=>x.AgencyQualifierCode);
		validator.ARequiresB(x=>x.StateOrProvinceCode, x=>x.CountryCode);
		validator.OnlyOneOf(x=>x.StateOrProvinceCode, x=>x.CountrySubdivisionCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Name, x=>x.CountryCode2);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.EquipmentDescriptionCode, x=>x.VehicleIdentificationNumber, x=>x.ReferenceIdentification5);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentification5, x=>x.ReferenceIdentificationQualifier);
		validator.ARequiresB(x=>x.CountrySubdivisionCode, x=>x.CountryCode);
		validator.Length(x => x.AssignedNumber, 1, 9);
		validator.Length(x => x.VehicleIdentificationNumber, 1, 30);
		validator.Length(x => x.Year, 4);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.ReferenceIdentification3, 1, 80);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.ReferenceIdentification4, 1, 80);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.Amount2, 1, 15);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.CountryCode2, 2, 3);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.ReferenceIdentification5, 1, 80);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.LoadEmptyStatusCode, 1);
		validator.Length(x => x.ReferenceIdentification6, 1, 80);
		validator.Length(x => x.ReferenceIdentification7, 1, 80);
		validator.Length(x => x.CountrySubdivisionCode, 1, 3);
		return validator.Results;
	}
}
