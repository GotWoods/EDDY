using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("PS")]
public class PS_ProtectiveServiceInstructions : EdiX12Segment
{
	[Position(01)]
	public string ProtectiveServiceRuleCode { get; set; }

	[Position(02)]
	public string ProtectiveServiceCode { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public decimal? Temperature { get; set; }

	[Position(05)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(06)]
	public string FreightStationAccountingCode { get; set; }

	[Position(07)]
	public string CityName { get; set; }

	[Position(08)]
	public string StateOrProvinceCode { get; set; }

	[Position(09)]
	public decimal? Weight { get; set; }

	[Position(10)]
	public string PreCooledRule710Code { get; set; }

	[Position(11)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(12)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(13)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(14)]
	public decimal? Temperature2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PS_ProtectiveServiceInstructions>(this);
		validator.Required(x=>x.ProtectiveServiceRuleCode);
		validator.Required(x=>x.ProtectiveServiceCode);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.UnitOrBasisForMeasurementCode, x=>x.Temperature, x=>x.Temperature2);
		validator.ARequiresB(x=>x.Temperature, x=>x.UnitOrBasisForMeasurementCode);
		validator.ARequiresB(x=>x.Temperature2, x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.ProtectiveServiceRuleCode, 3, 9);
		validator.Length(x => x.ProtectiveServiceCode, 1, 4);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Temperature, 1, 4);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.FreightStationAccountingCode, 1, 5);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.PreCooledRule710Code, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.Temperature2, 1, 4);
		return validator.Results;
	}
}
