using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("RT")]
public class RT_RateDestination : EdiX12Segment
{
	[Position(01)]
	public string RateValueQualifier { get; set; }

	[Position(02)]
	public string StandardPointLocationCode { get; set; }

	[Position(03)]
	public string DealerCode { get; set; }

	[Position(04)]
	public string VehicleServiceCode { get; set; }

	[Position(05)]
	public string DistanceQualifier { get; set; }

	[Position(06)]
	public int? TariffDistance { get; set; }

	[Position(07)]
	public string NationalMotorFreightTransportationAssociationLocationName { get; set; }

	[Position(08)]
	public string StateOrProvinceCode { get; set; }

	[Position(09)]
	public string Name { get; set; }

	[Position(10)]
	public string AddressInformation { get; set; }

	[Position(11)]
	public string IdentificationCode { get; set; }

	[Position(12)]
	public string IdentificationCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RT_RateDestination>(this);
		validator.Required(x=>x.RateValueQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DistanceQualifier, x=>x.TariffDistance);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCode, x=>x.IdentificationCodeQualifier);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.DealerCode, 2, 9);
		validator.Length(x => x.VehicleServiceCode, 2, 4);
		validator.Length(x => x.DistanceQualifier, 1);
		validator.Length(x => x.TariffDistance, 1, 5);
		validator.Length(x => x.NationalMotorFreightTransportationAssociationLocationName, 2, 27);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.AddressInformation, 1, 55);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		return validator.Results;
	}
}
