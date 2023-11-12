using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5040;

[Segment("T6")]
public class T6_TransitInboundRates : EdiX12Segment
{
	[Position(01)]
	public int? AssignedNumber { get; set; }

	[Position(02)]
	public decimal? FreightRate { get; set; }

	[Position(03)]
	public string RateValueQualifier { get; set; }

	[Position(04)]
	public string CityName { get; set; }

	[Position(05)]
	public decimal? FreightRate2 { get; set; }

	[Position(06)]
	public string RateValueQualifier2 { get; set; }

	[Position(07)]
	public string CityName2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<T6_TransitInboundRates>(this);
		validator.Required(x=>x.AssignedNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.FreightRate, x=>x.RateValueQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.FreightRate2, x=>x.RateValueQualifier2);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.FreightRate, 1, 15);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.FreightRate2, 1, 15);
		validator.Length(x => x.RateValueQualifier2, 2);
		validator.Length(x => x.CityName2, 2, 30);
		return validator.Results;
	}
}
