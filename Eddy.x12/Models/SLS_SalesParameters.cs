using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("SLS")]
public class SLS_SalesParameters : EdiX12Segment
{
	[Position(01)]
	public string MeasurementQualifier { get; set; }

	[Position(02)]
	public string CurrencyCode { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SLS_SalesParameters>(this);
		validator.Required(x=>x.MeasurementQualifier);
		validator.OnlyOneOf(x=>x.CurrencyCode, x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.MeasurementQualifier, 1, 3);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		return validator.Results;
	}
}
