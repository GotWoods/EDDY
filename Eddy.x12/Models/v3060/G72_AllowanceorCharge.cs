using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("G72")]
public class G72_AllowanceOrCharge : EdiX12Segment
{
	[Position(01)]
	public string AllowanceOrChargeCode { get; set; }

	[Position(02)]
	public string AllowanceOrChargeMethodOfHandlingCode { get; set; }

	[Position(03)]
	public string AllowanceOrChargeNumber { get; set; }

	[Position(04)]
	public string ExceptionNumber { get; set; }

	[Position(05)]
	public decimal? AllowanceOrChargeRate { get; set; }

	[Position(06)]
	public decimal? AllowanceOrChargeQuantity { get; set; }

	[Position(07)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(08)]
	public string AllowanceOrChargeTotalAmount { get; set; }

	[Position(09)]
	public decimal? Percent { get; set; }

	[Position(10)]
	public decimal? DollarBasisForPercent { get; set; }

	[Position(11)]
	public string OptionNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G72_AllowanceOrCharge>(this);
		validator.Required(x=>x.AllowanceOrChargeCode);
		validator.Required(x=>x.AllowanceOrChargeMethodOfHandlingCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AllowanceOrChargeQuantity, x=>x.UnitOrBasisForMeasurementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Percent, x=>x.DollarBasisForPercent);
		validator.ARequiresB(x=>x.OptionNumber, x=>x.AllowanceOrChargeNumber);
		validator.Length(x => x.AllowanceOrChargeCode, 1, 3);
		validator.Length(x => x.AllowanceOrChargeMethodOfHandlingCode, 2);
		validator.Length(x => x.AllowanceOrChargeNumber, 1, 16);
		validator.Length(x => x.ExceptionNumber, 1, 16);
		validator.Length(x => x.AllowanceOrChargeRate, 1, 15);
		validator.Length(x => x.AllowanceOrChargeQuantity, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.AllowanceOrChargeTotalAmount, 1, 15);
		validator.Length(x => x.Percent, 1, 6);
		validator.Length(x => x.DollarBasisForPercent, 1, 9);
		validator.Length(x => x.OptionNumber, 1, 20);
		return validator.Results;
	}
}
