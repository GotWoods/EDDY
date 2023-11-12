using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("AIN")]
public class AIN_Income : EdiX12Segment
{
	[Position(01)]
	public string TypeOfIncomeCode { get; set; }

	[Position(02)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AIN_Income>(this);
		validator.Required(x=>x.TypeOfIncomeCode);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.TypeOfIncomeCode, 2);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
