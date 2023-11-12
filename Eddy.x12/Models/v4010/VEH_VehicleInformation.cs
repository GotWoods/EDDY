using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

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
	public string ProductDescriptionCode { get; set; }

	[Position(06)]
	public string ProductDescriptionCode2 { get; set; }

	[Position(07)]
	public string ProductDescriptionCode3 { get; set; }

	[Position(08)]
	public decimal? Length { get; set; }

	[Position(09)]
	public string ReferenceIdentification { get; set; }

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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<VEH_VehicleInformation>(this);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.AgencyQualifierCode, x=>x.ProductDescriptionCode, x=>x.ProductDescriptionCode3);
		validator.ARequiresB(x=>x.ProductDescriptionCode, x=>x.AgencyQualifierCode);
		validator.ARequiresB(x=>x.ProductDescriptionCode3, x=>x.AgencyQualifierCode);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.VehicleIdentificationNumber, 1, 25);
		validator.Length(x => x.Year, 4);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.ProductDescriptionCode, 1, 12);
		validator.Length(x => x.ProductDescriptionCode2, 1, 12);
		validator.Length(x => x.ProductDescriptionCode3, 1, 12);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.Amount2, 1, 15);
		validator.Length(x => x.ActionCode, 1, 2);
		return validator.Results;
	}
}
