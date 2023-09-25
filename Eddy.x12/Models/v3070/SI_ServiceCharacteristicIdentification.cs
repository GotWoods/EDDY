using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("SI")]
public class SI_ServiceCharacteristicIdentification : EdiX12Segment
{
	[Position(01)]
	public string AgencyQualifierCode { get; set; }

	[Position(02)]
	public string ServiceCharacteristicsQualifier { get; set; }

	[Position(03)]
	public string ProductServiceID { get; set; }

	[Position(04)]
	public string ServiceCharacteristicsQualifier2 { get; set; }

	[Position(05)]
	public string ProductServiceID2 { get; set; }

	[Position(06)]
	public string ServiceCharacteristicsQualifier3 { get; set; }

	[Position(07)]
	public string ProductServiceID3 { get; set; }

	[Position(08)]
	public string ServiceCharacteristicsQualifier4 { get; set; }

	[Position(09)]
	public string ProductServiceID4 { get; set; }

	[Position(10)]
	public string ServiceCharacteristicsQualifier5 { get; set; }

	[Position(11)]
	public string ProductServiceID5 { get; set; }

	[Position(12)]
	public string ServiceCharacteristicsQualifier6 { get; set; }

	[Position(13)]
	public string ProductServiceID6 { get; set; }

	[Position(14)]
	public string ServiceCharacteristicsQualifier7 { get; set; }

	[Position(15)]
	public string ProductServiceID7 { get; set; }

	[Position(16)]
	public string ServiceCharacteristicsQualifier8 { get; set; }

	[Position(17)]
	public string ProductServiceID8 { get; set; }

	[Position(18)]
	public string ServiceCharacteristicsQualifier9 { get; set; }

	[Position(19)]
	public string ProductServiceID9 { get; set; }

	[Position(20)]
	public string ServiceCharacteristicsQualifier10 { get; set; }

	[Position(21)]
	public string ProductServiceID10 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SI_ServiceCharacteristicIdentification>(this);
		validator.Required(x=>x.AgencyQualifierCode);
		validator.Required(x=>x.ServiceCharacteristicsQualifier);
		validator.Required(x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ServiceCharacteristicsQualifier2, x=>x.ProductServiceID2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ServiceCharacteristicsQualifier3, x=>x.ProductServiceID3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ServiceCharacteristicsQualifier4, x=>x.ProductServiceID4);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ServiceCharacteristicsQualifier5, x=>x.ProductServiceID5);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ServiceCharacteristicsQualifier6, x=>x.ProductServiceID6);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ServiceCharacteristicsQualifier7, x=>x.ProductServiceID7);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ServiceCharacteristicsQualifier8, x=>x.ProductServiceID8);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ServiceCharacteristicsQualifier9, x=>x.ProductServiceID9);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ServiceCharacteristicsQualifier10, x=>x.ProductServiceID10);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.ServiceCharacteristicsQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 48);
		validator.Length(x => x.ServiceCharacteristicsQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 48);
		validator.Length(x => x.ServiceCharacteristicsQualifier3, 2);
		validator.Length(x => x.ProductServiceID3, 1, 48);
		validator.Length(x => x.ServiceCharacteristicsQualifier4, 2);
		validator.Length(x => x.ProductServiceID4, 1, 48);
		validator.Length(x => x.ServiceCharacteristicsQualifier5, 2);
		validator.Length(x => x.ProductServiceID5, 1, 48);
		validator.Length(x => x.ServiceCharacteristicsQualifier6, 2);
		validator.Length(x => x.ProductServiceID6, 1, 48);
		validator.Length(x => x.ServiceCharacteristicsQualifier7, 2);
		validator.Length(x => x.ProductServiceID7, 1, 48);
		validator.Length(x => x.ServiceCharacteristicsQualifier8, 2);
		validator.Length(x => x.ProductServiceID8, 1, 48);
		validator.Length(x => x.ServiceCharacteristicsQualifier9, 2);
		validator.Length(x => x.ProductServiceID9, 1, 48);
		validator.Length(x => x.ServiceCharacteristicsQualifier10, 2);
		validator.Length(x => x.ProductServiceID10, 1, 48);
		return validator.Results;
	}
}
