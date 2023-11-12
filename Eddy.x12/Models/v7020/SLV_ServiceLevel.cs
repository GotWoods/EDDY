using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7020;

[Segment("SLV")]
public class SLV_ServiceLevel : EdiX12Segment
{
	[Position(01)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(02)]
	public string QuantityQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SLV_ServiceLevel>(this);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Required(x=>x.QuantityQualifier);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.QuantityQualifier, 2);
		return validator.Results;
	}
}
