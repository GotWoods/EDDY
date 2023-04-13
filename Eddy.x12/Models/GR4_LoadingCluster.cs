using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("GR4")]
public class GR4_LoadingCluster : EdiX12Segment
{
	[Position(01)]
	public string ConfigurationTypeCode { get; set; }

	[Position(02)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(03)]
	public string EquipmentUseCode { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public string EquipmentInitial { get; set; }

	[Position(06)]
	public string EquipmentNumber { get; set; }

	[Position(07)]
	public string LocationQualifier { get; set; }

	[Position(08)]
	public string LocationIdentifier { get; set; }

	[Position(09)]
	public string CityName { get; set; }

	[Position(10)]
	public string StateOrProvinceCode { get; set; }

	[Position(11)]
	public string CountryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GR4_LoadingCluster>(this);
		validator.Required(x=>x.ConfigurationTypeCode);
		validator.Required(x=>x.EquipmentDescriptionCode);
		validator.Required(x=>x.EquipmentUseCode);
		validator.AtLeastOneIsRequired(x=>x.ReferenceIdentification, x=>x.EquipmentInitial);
		validator.IfOneIsFilled_AllAreRequired(x=>x.EquipmentInitial, x=>x.EquipmentNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LocationQualifier, x=>x.LocationIdentifier);
		validator.AtLeastOneIsRequired(x=>x.LocationIdentifier, x=>x.CityName);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CityName, x=>x.StateOrProvinceCode);
		validator.ARequiresB(x=>x.CountryCode, x=>x.StateOrProvinceCode);
		validator.Length(x => x.ConfigurationTypeCode, 1);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.EquipmentUseCode, 1);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 15);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		return validator.Results;
	}
}
