using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("CR4")]
public class CR4_EnteralOrParenteralTherapyCertification : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string CertificationTypeCode { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(06)]
	public decimal? Quantity2 { get; set; }

	[Position(07)]
	public string NonVisitCode { get; set; }

	[Position(08)]
	public string UnitOrBasisForMeasurementCode3 { get; set; }

	[Position(09)]
	public decimal? Quantity3 { get; set; }

	[Position(10)]
	public string UnitOrBasisForMeasurementCode4 { get; set; }

	[Position(11)]
	public decimal? Height { get; set; }

	[Position(12)]
	public string UnitOrBasisForMeasurementCode5 { get; set; }

	[Position(13)]
	public decimal? Weight { get; set; }

	[Position(14)]
	public decimal? Quantity4 { get; set; }

	[Position(15)]
	public string Description { get; set; }

	[Position(16)]
	public string NutrientAdministrationMethodCode { get; set; }

	[Position(17)]
	public string NutrientAdministrationTechniqueCode { get; set; }

	[Position(18)]
	public decimal? Quantity5 { get; set; }

	[Position(19)]
	public decimal? Quantity6 { get; set; }

	[Position(20)]
	public string Description2 { get; set; }

	[Position(21)]
	public decimal? Quantity7 { get; set; }

	[Position(22)]
	public decimal? Percent { get; set; }

	[Position(23)]
	public decimal? Quantity8 { get; set; }

	[Position(24)]
	public decimal? Quantity9 { get; set; }

	[Position(25)]
	public decimal? Percent2 { get; set; }

	[Position(26)]
	public decimal? Quantity10 { get; set; }

	[Position(27)]
	public decimal? Percent3 { get; set; }

	[Position(28)]
	public decimal? Quantity11 { get; set; }

	[Position(29)]
	public string Description3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CR4_EnteralOrParenteralTherapyCertification>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode3, x=>x.Quantity3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode4, x=>x.Height);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode5, x=>x.Weight);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.CertificationTypeCode, 1);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.NonVisitCode, 1);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		validator.Length(x => x.Quantity3, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode4, 2);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode5, 2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.Quantity4, 1, 15);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.NutrientAdministrationMethodCode, 1);
		validator.Length(x => x.NutrientAdministrationTechniqueCode, 1);
		validator.Length(x => x.Quantity5, 1, 15);
		validator.Length(x => x.Quantity6, 1, 15);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.Quantity7, 1, 15);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.Quantity8, 1, 15);
		validator.Length(x => x.Quantity9, 1, 15);
		validator.Length(x => x.Percent2, 1, 10);
		validator.Length(x => x.Quantity10, 1, 15);
		validator.Length(x => x.Percent3, 1, 10);
		validator.Length(x => x.Quantity11, 1, 15);
		validator.Length(x => x.Description3, 1, 80);
		return validator.Results;
	}
}
