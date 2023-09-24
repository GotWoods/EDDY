using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PS_ProtectiveServiceInstructions>(this);
		validator.Required(x=>x.ProtectiveServiceRuleCode);
		validator.Required(x=>x.ProtectiveServiceCode);
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
		return validator.Results;
	}
}
