using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("UIT")]
public class UIT_UnitDetail : EdiX12Segment
{
	[Position(01)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(02)]
	public decimal? UnitPrice { get; set; }

	[Position(03)]
	public string BasisOfUnitPriceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UIT_UnitDetail>(this);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.ARequiresB(x=>x.BasisOfUnitPriceCode, x=>x.UnitPrice);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.UnitPrice, 1, 14);
		validator.Length(x => x.BasisOfUnitPriceCode, 2);
		return validator.Results;
	}
}
