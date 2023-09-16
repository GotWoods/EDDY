using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("TAX")]
public class TAX_TaxReference : EdiX12Segment
{
	[Position(01)]
	public string TaxIdentificationNumber { get; set; }

	[Position(02)]
	public string LocationQualifier { get; set; }

	[Position(03)]
	public string LocationIdentifier { get; set; }

	[Position(04)]
	public string LocationQualifier2 { get; set; }

	[Position(05)]
	public string LocationIdentifier2 { get; set; }

	[Position(06)]
	public string LocationQualifier3 { get; set; }

	[Position(07)]
	public string LocationIdentifier3 { get; set; }

	[Position(08)]
	public string LocationQualifier4 { get; set; }

	[Position(09)]
	public string LocationIdentifier4 { get; set; }

	[Position(10)]
	public string LocationQualifier5 { get; set; }

	[Position(11)]
	public string LocationIdentifier5 { get; set; }

	[Position(12)]
	public string TaxExemptCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TAX_TaxReference>(this);
		validator.AtLeastOneIsRequired(x=>x.TaxIdentificationNumber, x=>x.LocationIdentifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LocationQualifier, x=>x.LocationIdentifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LocationQualifier2, x=>x.LocationIdentifier2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LocationQualifier3, x=>x.LocationIdentifier3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LocationQualifier4, x=>x.LocationIdentifier4);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LocationQualifier5, x=>x.LocationIdentifier5);
		validator.Length(x => x.TaxIdentificationNumber, 1, 20);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 25);
		validator.Length(x => x.LocationQualifier2, 1, 2);
		validator.Length(x => x.LocationIdentifier2, 1, 25);
		validator.Length(x => x.LocationQualifier3, 1, 2);
		validator.Length(x => x.LocationIdentifier3, 1, 25);
		validator.Length(x => x.LocationQualifier4, 1, 2);
		validator.Length(x => x.LocationIdentifier4, 1, 25);
		validator.Length(x => x.LocationQualifier5, 1, 2);
		validator.Length(x => x.LocationIdentifier5, 1, 25);
		validator.Length(x => x.TaxExemptCode, 1);
		return validator.Results;
	}
}
